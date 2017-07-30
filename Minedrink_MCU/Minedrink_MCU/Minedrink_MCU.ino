/*
 Name:		Minedrink_MCU.ino
 Created:	2017/7/30 20:22:00
 Author:	liute
*/
#include <IRremote.h>
int latchPin = 8;//D8连接74HC595芯片的使能引脚
int clockPin = 3;//D3连接时钟引脚
int dataPin = 9;//D9连接数据引脚
int RECV_Pin = 2;//D2链接红外接收器
IRrecv irrecv(RECV_Pin);
decode_results results;
//代表数字0~9
byte Tab[] = { 0xc0,0xf9,0xa4,0xb0,0x99,0x92,0x82,0xf8,0x80,0x90 };
const int abc = 0;
int lastNumber = 0;

enum IRCommands
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
	irrecv.enableIRIn();
	pinMode(latchPin, OUTPUT);
	pinMode(dataPin, OUTPUT);
	pinMode(clockPin, OUTPUT);
}

void loop()
{
	checkState();
	switch (lastNumber)
	{
	case 0:
		state_Zero();
		break;
	case 1:
		state_One();
		break;
	case 2:
		state_Two();
		break;
	case 3:
		state_Three();
		break;
	}
}
//检查状态并显示对应数字
void checkState() {
	if (irrecv.decode(&results))
	{
		Serial.println(results.value, HEX);//DEC OTC
		switch (results.value)
		{
		case IR_Zero:
			changeNumber(0);
			break;
		case IR_One:
			changeNumber(1);
			break;
		case IR_TWO:
			changeNumber(2);
			break;
		case IR_Three:
			changeNumber(3);
			break;
		default:
			showNumber(lastNumber);
			break;
		}
		irrecv.resume();
	}
}
void state_Zero() {
	while (Serial.available())
		Serial1.write(Serial.read());
	while (Serial1.available())
		Serial.write(Serial1.read());
}
void state_One() {
	Serial.println(">111");
}
void state_Two() {

}
void state_Three() {

}
//记录并改变显示数值
void changeNumber(int nummber) {
	lastNumber = nummber;
	showNumber(lastNumber);
}
//控制LED显示指定数字一定时间
void showNumber(int number) {
	digitalWrite(latchPin, LOW);
	shiftOut(dataPin, clockPin, MSBFIRST, Tab[number]);
	digitalWrite(latchPin, HIGH);
	delay(80);
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