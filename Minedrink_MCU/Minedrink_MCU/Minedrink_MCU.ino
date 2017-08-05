/*
 Name:		Minedrink_MCU.ino
 Created:	2017/7/30 20:22:00
 Author:	liute
*/
#include <HX711.h>
#include <IRremote.h>
int latchPin = 8;//D8����74HC595оƬ��ʹ������
int clockPin = 3;//D3����ʱ������
int dataPin = 9;//D9������������
int RECV_Pin = 2;//D2���Ӻ��������
int steelyardPinA_1 = 41;//
int steelyardPinA_2 = 42;
IRrecv irrecv(RECV_Pin);
decode_results results;
//��������0~9
byte Tab[] = { 0xc0,0xf9,0xa4,0xb0,0x99,0x92,0x82,0xf8,0x80,0x90 };
const int abc = 0;
int lastNumber = 0;
float Weight_1 = 0;
//����ָ����ձ�
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
	//Serial.println("Welcome to use!");
	//Init_Hx711();
	//irrecv.enableIRIn();
	pinMode(latchPin, OUTPUT);
	pinMode(dataPin, OUTPUT);
	pinMode(clockPin, OUTPUT);

	delay(1000);
	//Get_Maopi();
	Serial.println("setup() OK!");
}

void loop()
{
	showNumber(1);
	/*checkState();
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
	}*/
}
//���״̬����ʾ��Ӧ����
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
//ģʽ0�����ڻ���ģʽ
void state_Zero() {
	while (Serial.available())
		Serial1.write(Serial.read());
	while (Serial1.available())
		Serial.write(Serial1.read());
}
//ģʽ1:����ģʽ
void state_One() {
	Weight_1 = Get_Weight();	//������ڴ������ϵ���������
	float w1 = Weight_1 * 4.44444;
	Serial.print(float(Weight_1 / 1000)*4.44444, 3);	//������ʾ����
	Serial.print(" kg\n");	//��ʾ��λ
	Serial.print("\n");		//��ʾ��λ
	Serial1.print(w1);
	Serial1.print(" g\n");
	Serial1.println("**********************");
	delay(1000);				//��ʱ1s
}
//ģʽ2:
void state_Two() {

}
//ģʽ3:
void state_Three() {

}
//��¼���ı���ʾ��ֵ
void changeNumber(int nummber) {
	lastNumber = nummber;
	showNumber(lastNumber);
}
//����LED��ʾָ������һ��ʱ��
void showNumber(int number) {
	digitalWrite(latchPin, LOW);
	shiftOut(dataPin, clockPin, MSBFIRST, Tab[number]);
	digitalWrite(latchPin, HIGH);
	delay(80);
}


//}
//��ɫ��ť    0xff00|FD00FF
//VOL +       0xfe01|FD807F
//FUNC / STOP 0xfd02|FD40BF
//��2������   0xfb04|FD20DF
//��ͣ��      0xfa05|FDA05F
//��2������   0xf906|FD609F
//��������    0xf708|FD10EF
//VOL -       0xf609|FD906F
//��������    0xf50a|FD50AF
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
