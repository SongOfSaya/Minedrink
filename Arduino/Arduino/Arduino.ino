/*
Name:		Minedrink_MCU.ino
Created:	2017/7/30 20:22:00
Author:	Sora
Email:	Liutengfei833@hotmail.com
*/
#include <Metro.h>
#include <HX711.h>
#include <IRremote.h>
const int ID = 1001;	//此台Arduino的ID
int latchPin = 8;       //D8连接74HC595芯片的使能引脚
int clockPin = 3;       //D3连接时钟引脚
int dataPin = 9;        //D9连接数据引脚
int RECV_Pin = 2;       //D2链接红外接收器
const int colorNum = 12;//此Arduino的标志色
IRrecv irrecv(RECV_Pin);
boolean blinkState = false;	//LED灯是否亮起
decode_results results;		//接收到的红外指令

int modeNumber = 2;			//Arduino的状态值
float Weight_1 = 0;			//一号秤的读数
boolean isConn = false;		//是否成功建立TCP链接
int connTryNum = 0;			//TCP呼叫计数;
int weightSensorsLenth = 1;	//重量传感器的可用数量
String commStr = "";		//通过WIFI接受到的指令
const String name = "主料区";//此Arduino的名称
boolean commStrComplete = false;	//Wifi指令接收是否结束
Metro measureMetro = Metro(500);	//测量计时器,间隔500; 所有计时器应独立使用,单位ms
Metro listerenMetro = Metro(5);		//监听计时器,间隔5
Metro blink1000Metro = Metro(1000);	//LED计时器,间隔1000
Metro interval5Metro = Metro(5);	//泛用型计时器,间隔5
Metro blink250Metro = Metro(250);	//Led计时器,间隔250	
//代表数字0~9
byte Tab[] = { 0xc0,0xf9,0xa4,0xb0,0x99,0x92,0x82,0xf8,0x80,0x90 };
//重量传感器参数,分别为SCK,DT,GapValue,resualt, offset
Hx711_Senor weightSensors[15] = {
	{ 41,43,430,0,8422741 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 },
	{ 0,0,0,0,0 } };
enum IRCommands         //红外指令对照表
{
	IR_Zero = 0xFD30CF,
	IR_One = 0xFD08F7,
	IR_TWO = 0xFD8877,
	IR_Three = 0xFD48B7
};
void setup()
{
	Serial.begin(115200);
	Serial1.begin(115200);
	while (!Serial);
	//delay(100);
	//initSensors();
	Serial.print("毛皮质量=");
	Serial.println(weightSensors[0].dt);
	Init_Hx711();
	irrecv.enableIRIn();
	pinMode(latchPin, OUTPUT);
	pinMode(dataPin, OUTPUT);
	pinMode(clockPin, OUTPUT);
	pinMode(LED_BUILTIN, OUTPUT);
	delay(100);
	Get_Maopi(0);
	commStr.reserve(200);
	Serial.write("欢迎使用");
}

void loop()
{
	parseCommStr();
	checkState();
	switch (modeNumber)
	{
	case 0:
		state_Zero();
		blinkModelZero();
		break;
	case 1:
		if (measureMetro.check())
			state_One();
		break;
	case 2:
		state_Two();
		break;
	case 3:
		if (interval5Metro.check())
			state_Three();
		break;
	}
}
//处理接收到的wifi指令
void parseCommStr() {
	if (commStrComplete) {
		//是否是有效指令
		if (commStr.startsWith("#"))
		{
			String command = commStr.substring(0, 8);
			String detial = "";
			Serial.println("Command=" + command);
			if (commStr.length() > 8)
			{
				detial = commStr.substring(9, commStr.length());
				Serial.println("Detail=" + detial);
			}
			if (command.equals("#TCPCONN"))
			{
				replyTCPCONN();
			}
			else if (command == "#GETINFO")
			{
				replyGETINFO();
			}
		}
		// clear the string
		commStr = "";
		commStrComplete = false;

	}
}
//接收并处理红外指令
void checkState() {
	if (irrecv.decode(&results))
	{
		Serial.println(results.value, HEX);//DEC OTC
		switch (results.value)
		{
		case IR_Zero:
			if (modeNumber != 0)
				changeNumber(0);
			break;
		case IR_One:
			if (modeNumber != 1)
				changeNumber(1);
			break;
		case IR_TWO:
			if (modeNumber != 2)
				changeNumber(2);
			break;
		case IR_Three:
			if (modeNumber != 3)
				changeNumber(3);
			break;
		default:
			showNumber(modeNumber);
			break;
		}
		irrecv.resume();
	}
}
//模式0：串口互传模式
void state_Zero() {
	while (Serial.available()) {
		Serial1.write(Serial.read());
	}

	while (Serial1.available()) {
		Serial.write(Serial1.read());
	}

}
//模式1:称重模式
void state_One() {
	//{"ID":10, "Mills" : 1243, "Mode" : 1, "Sensors" : [{"ID":1085, "Result" : 123.44}, { "ID":1086,"Result" : 1234.4 }]}
	String resualtStr = "#UPDATEX={\"ID\":";
	resualtStr += ID;
	resualtStr += ",\"Mills\":";
	resualtStr += millis();
	resualtStr += ",\"Mode\":";
	resualtStr += modeNumber;
	resualtStr += ",\"Sensors\":[";
	for (size_t i = 0; i < weightSensorsLenth; i++)
	{
		Get_Weight(i);
		resualtStr += "{\"ID\":";
		resualtStr += weightSensors[i].sck;
		resualtStr += ",\"Result\":";
		resualtStr += weightSensors[i].result;
		if ((weightSensorsLenth - i) > 1)
		{
			resualtStr += "},";
		}
		else
		{
			resualtStr += "}]}";
		}
	}
	Serial.println(resualtStr);
	blinkState = !blinkState;
	digitalWrite(LED_BUILTIN, blinkState);
}
//模式2:主动与TCP Server建立连接
void state_Two() {

	//Serial.flush();
	//Serial1.flush();
	//if (!isConn)//如果未执行过AT指令则执行
	//{
	//	Serial.print("BEGIN TCPCONN");
	//	Serial1.print("+++");
	//	delay(1000);	//延时过小时(100)会出现失灵的情况
	//	Serial1.print("AT+TCPCLICONN=192.168.2.193:8080");
	//	delay(1000);
	//	Serial1.print("AT+EXIT");
	//	delay(1000);
	//	Serial1.println("#TCPOK?");
	//	delay(100);
	//	Serial1.println("XX");
	//	isConn = true;
	//}
	//if (connTryNum < 1000)
	//{
	//	Serial1.println("#TCPCONN");
	//	connTryNum++;
	//	delay(100);
	//}
	//else
	//{
	//	isConn = false;
	//	Serial.println("TCP CON'T CONN");
	//	//changeNumber(0);
	//}
	//
	////if (!isConn && connTryNum < 10) //呼叫10次直到超时或确定链接建立
	////{
	////	Serial1.println("#TCPOK?");
	////	connTryNum++;
	////}
	///*else if (!isConn && connTryNum > 100)
	//{
	//	Serial.println("#TCP CAN'T CONN");
	//}*/
	//while (Serial1.available()) {
	//	int charNum = Serial1.read();
	//	if (charNum == '#')	//接收到指令
	//	{
	//		commStr = "#";
	//		for (size_t i = 0; i < 7; i++)
	//		{
	//			charNum = Serial1.read();
	//			commStr += (char)charNum;
	//		}
	//		Serial.print("commstr = ");
	//		Serial.println(commStr);
	//		if (commStr == "#TCPOK**")
	//		{
	//			isConn = true;
	//			changeNumber(1);
	//		}
	//	}
	//	Serial.write(charNum);
	//	
	//}
}
//模式3:
void state_Three() {
	delay(5);
	//if (isConn || connTryNum != 0)
	//{
	//	Serial.flush();
	//	Serial1.flush();
	//	isConn = false;
	//	connTryNum = 0;
	//	Serial1.print("+++");
	//	delay(1000);	//延时过小时(100)会出现失灵的情况
	//	Serial1.print("AT+REBOOT");
	//	delay(1000);
	//	Serial1.print("AT+EXIT");
	//	Serial.println("Reset Arduino!");
	//	Serial.flush();
	//	Serial1.flush();
	//}
}
void serialEvent() {
	while (Serial.available())
	{
		char charNum = (char)Serial.read();
		commStr += charNum;
		//收到换行符则本条命令接收结束
		if (charNum == '\n')
		{
			commStrComplete = true;
		}
	}
}
//回复指令:#TCPCONN
void replyTCPCONN() {
	Serial.println("#TCPDONE");
}
//回复指令:#GETINIT
void replyGETINFO() {
	//无\格式:{"ID":1001,"NM":"名称","MIS":1234567,"MOD":4,"CO":12,"SS":[{"DT:123,"OFF":134,"GV":1,"DT":41,"SCK":43},{"SID":"W02","OFF":12,"GV":44,"DT":1,"SCK":43}]}
	String replyStr = "#ALLINFO={";
	replyStr += "\"ID\":";
	replyStr += ID;
	/*replyStr += ",\"NM\":\"";
	replyStr += name;*/
	replyStr += ",\"MIS\":";
	replyStr += millis();
	replyStr += ",\"MOD\":";
	replyStr += modeNumber;
	replyStr += ",\"CO\":";
	replyStr += colorNum;
	if (weightSensorsLenth > 0)
	{
		replyStr += ",\"SS\":[";
		for (size_t i = 0; i < weightSensorsLenth; i++)
		{
			replyStr += "{\"DT\":";
			replyStr += weightSensors[i].dt;
			replyStr += ",\"SCK\":";
			replyStr += weightSensors[i].sck;
			replyStr += ",\"OFF\":";
			replyStr += weightSensors[i].offset;
			replyStr += ",\"GV\":";
			replyStr += weightSensors[i].gapValue;
			replyStr += ",\"RES\":";
			replyStr += weightSensors[i].result;
			//如果尚未遍历完所有Sensors
			if (weightSensorsLenth - i > 1)
			{
				replyStr += ",";
			}
			else
			{
				replyStr += "}]}";
			}
		}
	}
	else
	{
		replyStr += "}";
	}
	Serial.println(replyStr);
}
//记录并改变显示数值
void changeNumber(int nummber) {
	String str = "#TOMODEX=";
	str += nummber;
	Serial.println(str);
	modeNumber = nummber;
	showNumber(modeNumber);
	resetAllMetro();
}
//重置所有计时器
void resetAllMetro() {
	measureMetro.reset();
	blink1000Metro.reset();
	blink250Metro.reset();
	listerenMetro.reset();
	interval5Metro.reset();
}
//控制LED显示指定数字一定时间
void showNumber(int number) {
	digitalWrite(latchPin, LOW);
	shiftOut(dataPin, clockPin, MSBFIRST, Tab[number]);
	digitalWrite(latchPin, HIGH);
	//delay(80);
}
//初始化所有传感器的数据
void initSensors() {
	weightSensorsLenth = 1;
	weightSensors[0].sck = 41;
	weightSensors[0].dt = 43;

}
void blinkModelZero() {
	if (blink1000Metro.check()) {
		blinkState = !blinkState;
		digitalWrite(LED_BUILTIN, blinkState);
	}
}
//}
//红色按钮    0xff00|FD00FF
//VOL +       0xfe01|FD807F
//FUNC / STOP 0xfd02|FD40BF
//左2个三角   0xfb04|FD20DF
//暂停键      0xfa05|FDA05F
//右2个三角   0xf906|FD609F
//向下三角    0xf708|FD10EF
//VOL -       0xf609|FD906F
//向上三角    0xf50a|FD50AF
//0           0xf30c|FD30CF
//EQ          0xf20d|FDB04F
//ST / REPT   0xf10e|FD708F
//1           0xef10|FD08F7
//2           0xee11|FD8877
//3           0xed12|FD48B7
//4           0xeb14|FD28D7
//5           0xea15|FDA857
//6           0xe916|FD6897
//7           0xe718|FD18E7
//8           0xe619|FD9867
//9           0xe51a|FD58A7

