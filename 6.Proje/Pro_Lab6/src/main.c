#include <stdint.h>
#include "inc/tm4c123gh6pm.h"
#include <stdbool.h>
#include "inc/hw_types.h"
#include "driverlib/gpio.h"
#include "driverlib/sysctl.h"
#include "driverlib/uart.h"
#include "utils/uartstdio.h"
#include "stdlib.h"

#define RS 1 // PB0
#define RW 2 // PB1
#define EN 4 // PB2
#define BAUDRATE 9600

//txt veri
volatile char str[6][25] = {"20,20,10",
                  	  	  	  "1,su,5,50 Kurus",
							  "2,cay,10,1 TL",
							  "3,kahve,15,1.5 TL",
							  "4,cikolata,50,1.75 TL",
							  "5,biskuvi,100,2 TL"};

volatile char *a[3];
volatile char *s[5];
volatile char *d[5];
volatile char *f[5];
volatile char *g[5];
volatile char *h[5];
volatile char *kelime;

//butonlar
volatile int buton1_25kurus, buton2_50kurus, buton3_1tl, buton4_Bitis;
volatile int buton5_Biskuvi, buton6_Bitis;
volatile int buton7_reset;

//degiskenler
volatile unsigned short atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL, atilanKurus, yatilanTl;
volatile unsigned short verilen25 = 0, verilen50 = 0, verilen1 = 0;

volatile float para, urunlerinToplamFiyati = 0, paraUstu = 0;
volatile unsigned short i=0, j=0, ctrl = 0, rast = 5, yer = 1;
volatile int rastgele = 0;

//siparisleri tutmak icin dizi
volatile unsigned short siparis[5] = { 0, 0, 0, 0, 0 };

//kasadaki para sayysy
// 25, 50, 1TL
volatile unsigned short kasadakiParalar[3];

//Urunler
volatile unsigned short UrunID[5];
volatile unsigned short StokSayisi[5];
volatile float UrunFiyat[5] ;

volatile char UrunAd[5][9];
volatile char UrunDeger[5][5];

/** UART (seri port) ayarini yapan fonksiyon */
void init_UARTstdio() {
	SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOA);
	GPIOPinConfigure(0x00000001);
	GPIOPinConfigure(0x00000401);
	GPIOPinTypeUART(0x40004000, 0x00000001 | 0x00000002);
	UARTConfigSetExpClk(0x40004000, SysCtlClockGet(), BAUDRATE, (UART_CONFIG_WLEN_8 | UART_CONFIG_STOP_ONE | UART_CONFIG_PAR_NONE));
	UARTStdioConfig(0, BAUDRATE, SysCtlClockGet());
}

void StoktanDus(){
	for(i=0; i<5; i++)
	{
		StokSayisi[i] = StokSayisi[i]-siparis[i];
	}
}

void SiparisSifirla(){
	for(i=0; i<5; i++)
	{
		siparis[i] = 0;
	}
}

void init_port_F() {
	volatile unsigned long delay;
	SYSCTL_RCGCGPIO_R |= 0x00000020;
	delay = SYSCTL_RCGCGPIO_R;
	GPIO_PORTF_LOCK_R = 0x4C4F434B;
	GPIO_PORTF_CR_R = 0x01;
	GPIO_PORTF_DIR_R = 0x0E;
	GPIO_PORTF_PUR_R = 0x11;
	GPIO_PORTF_DEN_R = 0x1F;
}

void init_port_E() {
	volatile unsigned long delay;
	SYSCTL_RCGC2_R |= SYSCTL_RCGC2_GPIOE;
	delay = SYSCTL_RCGC2_R;
	GPIO_PORTE_DIR_R |= 0x00;
	GPIO_PORTE_DEN_R |= 0xFF;
}

void init_port_D() {
	volatile unsigned long delay;
	SYSCTL_RCGC2_R |= SYSCTL_RCGC2_GPIOD;
	delay = SYSCTL_RCGC2_R;
	GPIO_PORTD_DIR_R |= 0x0F;
	GPIO_PORTD_AFSEL_R &= ~0x0F;
	GPIO_PORTD_DEN_R |= 0x0F;
}

void delay(int n)
{
	volatile unsigned short x,y;
	for(x=0;x<n;x++)
	{
		for(y=0;y<3180;y++)
		{

		}
	}
}

void delayUs(int n)
{
	volatile unsigned short x,y;
	for (x = 0; x < n; x++)
	{
		for (y = 0; y < 3; y++)
		{

		}
	}
}

void LcdVeriYaz(unsigned char data, unsigned char control)
{
	data &= 0xF0; // son dort bit data
	control &= 0x0F; // ilk dort bit control
	GPIO_PORTB_DATA_R = data | control;
	GPIO_PORTB_DATA_R = data | control | EN;
	delayUs(0);
	GPIO_PORTB_DATA_R = data ;
}

void LcdKomut(unsigned char command)
{
	LcdVeriYaz(command & 0xF0,0);
	LcdVeriYaz(command<<4,0);

	if(command < 4)
	{
		delay(2);
	}
	else
		delayUs(40);
}

void LcdPutChar(unsigned char data)
{
	LcdVeriYaz(data & 0xF0,RS);
	LcdVeriYaz(data <<4,RS);
	delayUs(40);
}

void Lcd_Puts(char* s) {
	while (*s)
		LcdPutChar(*s++);
}

void Lcd_Goto(char x, char y){

	if (x == 1)
		LcdKomut(0x80 + ((y - 1) % 16));
	else
		LcdKomut(0xC0 + ((y - 1) % 16));
}

void LcdEkranTemizle(void){

	LcdKomut(0x01);
	delay(100);
}

void Lcd_Init(void)
{
	SYSCTL_RCGC2_R |= SYSCTL_RCGC2_GPIOB;
	GPIO_PORTB_DIR_R |= 0xFF;
	GPIO_PORTB_DEN_R |= 0XFF;
	LcdKomut(0x28);
	LcdKomut(0x06);
	LcdKomut(0x01);
	LcdKomut(0x0F);
}

/*void FloatAta(char deger[], int in)
{
    short k,l;
    //degilse
    char sonra[3];
    char once[3];
    k=0;
    while(deger[k] != '.')
    {
    	once[k] = deger[k];
        k++;
    }
    //once[k] = '\0';
    k++;
    l=0;
    while(deger[k]!='T')
    {
        sonra[l]=deger[k];
        k++;
        l++;
    }
    sonra[l]='\0';

    if(in == 2)
    {
		if (atoi(sonra) == 5)
			UrunFiyat[in] = (float) (atoi(once) + (atoi(sonra) / 10.0));
		else
			UrunFiyat[in] = (float) (atoi(once) + (atoi(sonra) / 100.0));
    }
    else if(in ==3)
    {
		if (atoi(sonra) == 5)
			UrunFiyat[in] = (float) (atoi(once) + (atoi(sonra) / 10.0));
		else
			UrunFiyat[in] = (float) (atoi(once) + (atoi(sonra) / 100.0));
    }
}*/

void StringOku()
{
    int j;
    char para[6];
    for (i = 0; i < 6; i++)
    {
        kelime = strtok(str[i], " ,");
        if (i == 0)
        {
            for (j = 0; kelime != 0; j++)
            {
                strcpy(a + j, kelime);
                kasadakiParalar[j] = atoi(a + j);
                kelime = strtok(0, " ,");
            }
        }

        if (i == 1)
        {
            for (j = 0; kelime != 0; j++)
            {
                strcpy(s + j, kelime);
                UrunID[0] = atoi(s + 0);
                if(j == 1)
                    strcpy(UrunAd[0], kelime);
                StokSayisi[0] = atoi(s + 2);
                if(j == 3)
                	strcpy(UrunDeger[0], kelime);
                if(j == 4)
                	strcpy(para,s+4);

                /*if(strcmp(para, "Kurus") == 0)
                    //esit
                	UrunFiyat[0] = atoi(s + 3)/100.0;
                else if (strcmp(para, "TL") == 0)
                {
                    //degilse
                	UrunFiyat[0] = atoi(s + 3);
                }*/

                kelime = strtok(0, " ,");
            }
        }

        if (i == 2)
        {
            for (j = 0; kelime != 0; j++)
            {
                strcpy(d + j, kelime);
                UrunID[1] = atoi(d + 0);
                if(j == 1)
                    strcpy(UrunAd[1], kelime);
                StokSayisi[1] = atoi(d + 2);
                if(j == 3)
                	strcpy(UrunDeger[1], kelime);
                if(j == 4)
                	strcpy(para,d+4);

                /*if(strcmp(para, "Kurus") == 0)
                    //esit
                    UrunFiyat[1] = atoi(d+3)/100.0;
                else if (strcmp(para, "TL") == 0)
                {
                    //degilse
                	UrunFiyat[1] = atoi(d+3);
                }*/
                kelime = strtok(0, " ,");
            }
        }

        if (i == 3)
        {
            for (j = 0; kelime != 0; j++)
            {
                strcpy(f + j, kelime);
                UrunID[2] = atoi(f + 0);
                if(j == 1)
                    strcpy(UrunAd[2], kelime);
                //strcpy(UrunAd[2], f + 1);
                StokSayisi[2] = atoi(f + 2);
                if(j == 3)
                	strcpy(UrunDeger[2], kelime);
                if(j == 4)
                	strcpy(para,f+4);

                /*if(strcmp(para, "Kurus") == 0)
                    //esit
                    UrunFiyat[2] = atoi(f+3)/100.0;
                else if (strcmp(para, "TL") == 0)
                {
                    //degilse
                    char deger[8];
                    strcpy(deger,f+3);
                    delay(10);
                    FloatAta(deger,2);
                    init_UARTstdio();
                    UARTprintf("2.Eksikmis: %s --- %d\n",deger, (int)(UrunFiyat[2]*100));
                }*/
                kelime = strtok(0, " ,");
            }
        }

        if (i == 4)
        {
            for (j = 0; kelime != 0; j++)
            {
                strcpy(g + j, kelime);
                UrunID[3] = atoi(g + 0);
                if(j == 1)
                    strcpy(UrunAd[3], kelime);
                StokSayisi[3] = atoi(g + 2);
                if(j == 3)
                	strcpy(UrunDeger[3], kelime);
                if(j == 4)
                	strcpy(para,g+4);

                /*if(strcmp(para, "Kurus") == 0)
                    //esit
                    UrunFiyat[3] = atoi(g+3)/100.0;
                else if (strcmp(para, "TL") == 0)
                {
                    //degilse
                    char deger[8];
                    strcpy(deger,g+3);
                    delay(10);
                    FloatAta(deger,3);
                    init_UARTstdio();
                    UARTprintf("3.Eksikmis: %s --- %d\n",deger, (int)(UrunFiyat[3]*100));
                }*/
                kelime = strtok(0, " ,");
            }
        }

        if (i == 5)
        {
            for (j = 0; kelime != 0; j++)
            {
                strcpy(h + j, kelime);
                UrunID[4] = atoi(h + 0);
                if(j == 1)
                    strcpy(UrunAd[4], h+1);
                StokSayisi[4] = atoi(h + 2);
                if(j == 3)
                	strcpy(UrunDeger[4], kelime);
                if(j == 4)
                	strcpy(para,h+4);

                /*if(strcmp(para, "Kurus") == 0)
                    //esit
                    UrunFiyat[4] = atoi(h+3)/100.0;
                else if (strcmp(para, "TL") == 0)
                {
                    //degilse
                	UrunFiyat[4] = atoi(h+3);
                }*/
                kelime = strtok(0, " ,");
            }
        }
    }

	UrunFiyat[0] = 0.5;
	UrunFiyat[1] = 1;
	UrunFiyat[2] = 1.5;
	UrunFiyat[3] = 1.75;
	UrunFiyat[4] = 2;
}

void StringBirlestir()
{
	char buffer[100];
//ilk satır
	itoa(kasadakiParalar[0], buffer, 10);
	strcpy(str[0], buffer);
	strcat(str[0], ",");
	itoa(kasadakiParalar[1], buffer, 10);
	strcat(str[0], buffer);
	strcat(str[0], ",");
	itoa(kasadakiParalar[2], buffer, 10);
	strcat(str[0], buffer);
//2
	itoa(UrunID[0], buffer, 10);
	strcpy(str[1], buffer);
	strcat(str[1], ",");
	strcat(str[1], UrunAd[0]);
	strcat(str[1], ",");
	itoa(StokSayisi[0], buffer, 10);
	strcat(str[1], buffer);
	strcat(str[1], ",");
	if (UrunFiyat[0] < 1.0) {
		//kurustur
		strcat(str[1], UrunDeger[0]);
		strcat(str[1], " Kurus");
	} else {
		//tldir
		strcat(str[1], UrunDeger[0]);
		strcat(str[1], " TL");
	}
//3
	itoa(UrunID[1], buffer, 10);
	strcpy(str[2], buffer);
	strcat(str[2], ",");
	strcat(str[2], UrunAd[1]);
	strcat(str[2], ",");
	itoa(StokSayisi[1], buffer, 10);
	strcat(str[2], buffer);
	strcat(str[2], ",");
	if (UrunFiyat[1] < 1.0) {
		//kurustur
		strcat(str[2], UrunDeger[1]);
		strcat(str[2], " Kurus");
	} else {
		//tldir
		strcat(str[2], UrunDeger[1]);
		strcat(str[2], " TL");
	}
//4
	itoa(UrunID[2], buffer, 10);
	strcpy(str[3], buffer);
	strcat(str[3], ",");
	strcat(str[3], UrunAd[2]);
	strcat(str[3], ",");
	itoa(StokSayisi[2], buffer, 10);
	strcat(str[3], buffer);
	strcat(str[3], ",");
	if (UrunFiyat[2] < 1) {
		//kurustur
		strcat(str[3], UrunDeger[2]);
		strcat(str[3], " Kurus");
	} else {
		//tldir
		strcat(str[3], UrunDeger[2]);
		strcat(str[3], " TL");
	}
//5
	itoa(UrunID[3], buffer, 10);
	strcpy(str[4], buffer);
	strcat(str[4], ",");
	strcat(str[4], UrunAd[3]);
	strcat(str[4], ",");
	itoa(StokSayisi[3], buffer, 10);
	strcat(str[4], buffer);
	strcat(str[4], ",");
	if (UrunFiyat[3] < 1) {
		//kurustur
		strcat(str[4], UrunDeger[3]);
		strcat(str[4], " Kurus");
	} else {
		//tldir

            strcat(str[4], UrunDeger[3]);
            strcat(str[4], " TL");
	}
//6
	itoa(UrunID[4], buffer, 10);
	strcpy(str[5], buffer);
	strcat(str[5], ",");
	strcat(str[5], UrunAd[4]);
	strcat(str[5], ",");
	itoa(StokSayisi[4], buffer, 10);
	strcat(str[5], buffer);
	strcat(str[5], ",");
	if (UrunFiyat[4] < 1) {
		//kurustur
		strcat(str[5], UrunDeger[4]);
		strcat(str[5], " Kurus");
	} else {
		//tldir
		strcat(str[5], UrunDeger[4]);
		strcat(str[5], " TL");
	}
}

void UARTBastirma()
{
	init_UARTstdio();
	delay(100);
	for(i=0; i<6; i++)
	{
		for(j=0; j<25; j++)
		{
			if(str[i][j] == ',')
				UARTprintf(", ");
			else if(str[i][j] == ' ')
				UARTprintf(" ");
			else
				UARTprintf("%c", str[i][j]);
		}
		delay(100);
		UARTprintf("\n");
	}
	UARTprintf("-------------------------------\n");
}

int main(){
	Lcd_Init();
	LcdKomut(1);
	LcdKomut(0x80);
	delay(500);
	init_port_E();
	init_port_D();
	init_port_F();
	init_UARTstdio();

	UARTBastirma();
	StringOku();

	//tiva ledleri
	SYSCTL_RCGC2_R |= SYSCTL_RCGC2_GPIOF;
	GPIO_PORTF_DIR_R |= 0b00001010;
	GPIO_PORTF_DEN_R |= 0b00001010;

	LcdEkranTemizle();
	delay(100);
	Lcd_Goto(1, 3);
	Lcd_Puts("Para girisi");
	Lcd_Goto(2, 4);
	Lcd_Puts("yapiniz...");

	while (1)
	{
		buton7_reset = GPIO_PORTF_DATA_R & 0b00001;
		//PARA GİRİŞİ
		if (ctrl == 0)
		{
			buton1_25kurus = GPIO_PORTE_DATA_R & 0b00000001;
			buton2_50kurus = GPIO_PORTE_DATA_R & 0b00000010;
			buton3_1tl = GPIO_PORTE_DATA_R & 0b00000100;
			buton4_Bitis = GPIO_PORTE_DATA_R & 0b00001000;
			rastgele++;
			if (buton1_25kurus != 0)
			{
				LcdEkranTemizle();
				delay(100);
				atilan25++;
		    	if(atilan25 < 10)
		    	{
					Lcd_Goto(1, 1);
					LcdPutChar(atilan25 + '0');
					Lcd_Goto(1, 3);
					Lcd_Puts("tane 25 kurus");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
		    	}
		    	else
		    	{
					Lcd_Goto(1, 1);
					LcdPutChar((atilan25/10) + '0');
					LcdPutChar(atilan25-((atilan25/10)*10) + '0');
					Lcd_Goto(1, 4);
					Lcd_Puts("tane 25 kurus");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(100);
		    	}

			}
			if (buton2_50kurus != 0) {
				LcdEkranTemizle();
				delay(100);
				atilan50++;
		    	if(atilan50 < 10)
		    	{
					Lcd_Goto(1, 1);
					LcdPutChar(atilan50 + '0');
					Lcd_Goto(1, 3);
					Lcd_Puts("tane 50 kurus");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
		    	}
		    	else
		    	{
					Lcd_Goto(1, 1);
					LcdPutChar((atilan50/10) + '0');
					LcdPutChar(atilan50-((atilan50/10)*10) + '0');
					Lcd_Goto(1, 4);
					Lcd_Puts("tane 50 kurus");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(100);
		    	}
			}
			if (buton3_1tl != 0) {
				LcdEkranTemizle();
				delay(100);
				atilan1++;
		    	if(atilan1 < 10)
		    	{
					Lcd_Goto(1, 1);
					LcdPutChar(atilan1 + '0');
					Lcd_Goto(1, 3);
					Lcd_Puts("tane 1 TL");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
		    	}
		    	else
		    	{
					Lcd_Goto(1, 1);
					LcdPutChar((atilan1/10) + '0');
					LcdPutChar(atilan1-((atilan1/10)*10) + '0');
					Lcd_Goto(1, 4);
					Lcd_Puts("tane 1 TL");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(100);
		    	}

			}
			if (buton4_Bitis != 0)
			{
				kasadakiParalar[0] = kasadakiParalar[0] + atilan25;
				kasadakiParalar[1] = kasadakiParalar[1] + atilan50;
				kasadakiParalar[2] = kasadakiParalar[2] + atilan1;

				para = atilan1 + (atilan50 * 0.5) + (atilan25 * 0.25);
				LcdEkranTemizle();
				delay(100);

				atilanTL = para / 1;
				atilanKurus = (para - atilanTL) * 100;
				yatilanTl = atilanTL;

				if (atilanTL >= 100 || yatilanTl >= 100) {
					Lcd_Goto(1, yer++);
					LcdPutChar((atilanTL / 100) + '0');
					atilanTL = atilanTL % 100;
				}
				if (atilanTL >= 10 || yatilanTl >= 10) {
					Lcd_Goto(1, yer++);
					LcdPutChar((atilanTL / 10) + '0');
					atilanTL = atilanTL % 10;
				}
				if (atilanTL >= 1 || yatilanTl >= 1) {
					Lcd_Goto(1, yer++);
					LcdPutChar((atilanTL / 1) + '0');
					atilanTL = atilanTL % 1;
				}

				//KURUS
				if (yatilanTl == 0) {
					Lcd_Goto(1, yer++);
					LcdPutChar('0');
				}
				if (atilanKurus != 0) {
					Lcd_Goto(1, yer++);
					LcdPutChar('.');
					if (atilanKurus >= 10) {
						Lcd_Goto(1, yer++);
						LcdPutChar((atilanKurus / 10) + '0');
						atilanKurus = atilanKurus % 10;
					}
					if (atilanKurus >= 1) {
						Lcd_Goto(1, yer++);
						LcdPutChar((atilanKurus / 1) + '0');
						atilanKurus = atilanKurus % 1;
					}
				}
				yer = yer + 2;
				Lcd_Goto(1, yer);
				Lcd_Puts("TL");

				Lcd_Goto(2, 1);
				Lcd_Puts("para attiniz");
				ctrl = 1;
				para = atilan1 + (atilan50 * 0.5) + (atilan25 * 0.25);

				delay(1500);
				LcdEkranTemizle();
				Lcd_Puts("Urun seciniz...");
			}
			 if(buton7_reset == 0 )
			 {
				LcdEkranTemizle();
				Lcd_Puts("Sifirlaniyor...");
				delay(1000);

				//değişkenleri sifirla
				atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
				verilen25 = 0,  verilen50 = 0, verilen1 = 0;
				para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;
				SiparisSifirla();

				LcdEkranTemizle();
				delay(100);
				Lcd_Goto(1, 3);
				Lcd_Puts("Para girisi");
				Lcd_Goto(2, 4);
				Lcd_Puts("yapiniz...");
				StringBirlestir();
				UARTBastirma();
				delay(100);
				ctrl = 0;
			 }
		}

		//Müşteri SEÇİMİ
		if (ctrl == 1)
		{
			rast = rastgele % 4;
			if (rast == 0)
				rast = 4;

			buton1_25kurus = GPIO_PORTE_DATA_R & 0b00000001;
			buton2_50kurus = GPIO_PORTE_DATA_R & 0b00000010;
			buton3_1tl = GPIO_PORTE_DATA_R & 0b00000100;
			buton4_Bitis = GPIO_PORTE_DATA_R & 0b00001000;
			buton5_Biskuvi = GPIO_PORTE_DATA_R & 0b00010000;
			buton6_Bitis = GPIO_PORTE_DATA_R & 0b00100000;

			if (buton1_25kurus != 0)
			{
				LcdEkranTemizle();
				delay(100);
				siparis[0]++;
				if ((StokSayisi[0] - siparis[0] < 0)) {
					Lcd_Goto(1, 1);
					Lcd_Puts("Stoklarda ");
					Lcd_Puts(UrunAd[0]);
					Lcd_Goto(2, 1);
					Lcd_Puts("kalmamistir");
					siparis[0]--;
				}
				else {
			    	if(siparis[0] < 10)
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar(siparis[0] + '0');
						Lcd_Goto(1, 3);
						Lcd_Puts(UrunAd[0]);
						urunlerinToplamFiyati = UrunFiyat[0] + urunlerinToplamFiyati;
			    	}
			    	else
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar((siparis[0]/10) + '0');
						LcdPutChar(siparis[0]-((siparis[0]/10)*10) + '0');
						Lcd_Goto(1, 4);
						Lcd_Puts(UrunAd[0]);
						urunlerinToplamFiyati = UrunFiyat[0] + urunlerinToplamFiyati;
			    	}
				}

				if (urunlerinToplamFiyati > para)
				{
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 1);
					Lcd_Puts("Eksik para");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(1500);
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("PARA IADESI");
					Lcd_Goto(2, 4);
					Lcd_Puts("YAPILIYOR");
					delay(1500);
					//Kasaya eklenen paralar cikartiliyor geri verildiği için
					kasadakiParalar[0] = kasadakiParalar[0] - atilan25;
					kasadakiParalar[1] = kasadakiParalar[1] - atilan50;
					kasadakiParalar[2] = kasadakiParalar[2] - atilan1;
					//değişkenleri sifirla
					atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
					verilen25 = 0,  verilen50 = 0, verilen1 = 0;
					para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;

					SiparisSifirla();
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("Para girisi");
					Lcd_Goto(2, 4);
					Lcd_Puts("yapiniz...");
					delay(100);
					ctrl = 0;
				}
			}
			if (buton2_50kurus != 0) {
				//rastgele=0;
				LcdEkranTemizle();
				delay(100);
				siparis[1]++;
				if ((StokSayisi[1] - siparis[1] < 0)) {
					Lcd_Goto(1, 1);
					Lcd_Puts("Stoklarda ");
					Lcd_Puts(UrunAd[1]);
					Lcd_Goto(2, 1);
					Lcd_Puts("kalmamistir");
					siparis[1]--;
				}
				else {
			    	if(siparis[1] < 10)
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar(siparis[1] + '0');
						Lcd_Goto(1, 3);
						Lcd_Puts(UrunAd[1]);
						urunlerinToplamFiyati = UrunFiyat[1] + urunlerinToplamFiyati;
			    	}
			    	else
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar((siparis[1]/10) + '0');
						LcdPutChar(siparis[1]-((siparis[1]/10)*10) + '0');
						Lcd_Goto(1, 4);
						Lcd_Puts(UrunAd[1]);
						urunlerinToplamFiyati = UrunFiyat[1] + urunlerinToplamFiyati;
			    	}
				}

				if (urunlerinToplamFiyati > para)
				{
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 1);
					Lcd_Puts("Eksik para");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(1500);
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("PARA IADESI");
					Lcd_Goto(2, 4);
					Lcd_Puts("YAPILIYOR");
					delay(1500);
					//Kasaya eklenen paralar cikartiliyor geri verildiği için
					kasadakiParalar[0] = kasadakiParalar[0] - atilan25;
					kasadakiParalar[1] = kasadakiParalar[1] - atilan50;
					kasadakiParalar[2] = kasadakiParalar[2] - atilan1;
					//değişkenleri sifirla
					atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
					verilen25 = 0,  verilen50 = 0, verilen1 = 0;
					para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;

					SiparisSifirla();
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("Para girisi");
					Lcd_Goto(2, 4);
					Lcd_Puts("yapiniz...");
					delay(100);
					ctrl = 0;
				}
			}
			if (buton3_1tl != 0) {
				//rastgele=0;
				LcdEkranTemizle();
				delay(100);
				siparis[2]++;
				if ((StokSayisi[2] - siparis[2] < 0)) {
					Lcd_Goto(1, 1);
					Lcd_Puts("Stoklarda ");
					Lcd_Puts(UrunAd[2]);
					Lcd_Goto(2, 1);
					Lcd_Puts("kalmamistir");
					siparis[2]--;
				}
				else {
			    	if(siparis[2] < 10)
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar(siparis[2] + '0');
						Lcd_Goto(1, 3);
						Lcd_Puts(UrunAd[2]);
						//Lcd_Puts(urunler[2].UrunAd);
						//Lcd_Puts("kahve");
						//Lcd_Puts(uc.UrunAd);
						urunlerinToplamFiyati = UrunFiyat[2] + urunlerinToplamFiyati;
			    	}
			    	else
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar((siparis[2]/10) + '0');
						LcdPutChar(siparis[2]-((siparis[2]/10)*10) + '0');
						Lcd_Goto(1, 4);
						Lcd_Puts(UrunAd[2]);
						urunlerinToplamFiyati = UrunFiyat[2] + urunlerinToplamFiyati;
			    	}
				}

				if (urunlerinToplamFiyati > para)
				{
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 1);
					Lcd_Puts("Eksik para");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(1500);
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("PARA IADESI");
					Lcd_Goto(2, 4);
					Lcd_Puts("YAPILIYOR");
					delay(1500);
					//Kasaya eklenen paralar cikartiliyor geri verildiği için
					kasadakiParalar[0] = kasadakiParalar[0] - atilan25;
					kasadakiParalar[1] = kasadakiParalar[1] - atilan50;
					kasadakiParalar[2] = kasadakiParalar[2] - atilan1;
					//değişkenleri sifirla
					atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
					verilen25 = 0,  verilen50 = 0, verilen1 = 0;
					para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;

					SiparisSifirla();
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("Para girisi");
					Lcd_Goto(2, 4);
					Lcd_Puts("yapiniz...");
					delay(100);
					ctrl = 0;
				}
			}
			if (buton4_Bitis != 0) {
				//rastgele=0;
				LcdEkranTemizle();
				delay(100);
				siparis[3]++;
				if ((StokSayisi[3] - siparis[3] < 0)) {
					Lcd_Goto(1, 1);
					Lcd_Puts("Stokta ");
					Lcd_Puts(UrunAd[3]);
					Lcd_Goto(2, 1);
					Lcd_Puts("kalmamistir");
					siparis[3]--;
				}
				else {
			    	if(siparis[3] < 10)
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar(siparis[3] + '0');
						Lcd_Goto(1, 3);
						Lcd_Puts(UrunAd[3]);
						urunlerinToplamFiyati = UrunFiyat[3] + urunlerinToplamFiyati;
			    	}
			    	else
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar((siparis[3]/10) + '0');
						LcdPutChar(siparis[3]-((siparis[3]/10)*10) + '0');
						Lcd_Goto(1, 4);
						Lcd_Puts(UrunAd[3]);
						urunlerinToplamFiyati = UrunFiyat[3] + urunlerinToplamFiyati;
			    	}
				}

				if (urunlerinToplamFiyati > para)
				{
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 1);
					Lcd_Puts("Eksik para");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(1500);
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("PARA IADESI");
					Lcd_Goto(2, 4);
					Lcd_Puts("YAPILIYOR");
					delay(1500);
					//Kasaya eklenen paralar cikartiliyor geri verildiği için
					kasadakiParalar[0] = kasadakiParalar[0] - atilan25;
					kasadakiParalar[1] = kasadakiParalar[1] - atilan50;
					kasadakiParalar[2] = kasadakiParalar[2] - atilan1;
					//değişkenleri sifirla
					atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
					verilen25 = 0,  verilen50 = 0, verilen1 = 0;
					para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;

					SiparisSifirla();
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("Para girisi");
					Lcd_Goto(2, 4);
					Lcd_Puts("yapiniz...");
					delay(100);
					ctrl = 0;
				}
			}
			if (buton5_Biskuvi != 0) {
				//rastgele=0;
				LcdEkranTemizle();
				delay(100);
				siparis[4]++;
				if ((StokSayisi[4] - siparis[4] < 0)) {
					Lcd_Goto(1, 1);
					Lcd_Puts("Stokta ");
					Lcd_Puts(UrunAd[4]);
					Lcd_Goto(2, 1);
					Lcd_Puts("kalmamistir");
					siparis[4]--;
				}
				else {
			    	if(siparis[4] < 10)
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar(siparis[4] + '0');
						Lcd_Goto(1, 3);
						Lcd_Puts(UrunAd[4]);
						//Lcd_Puts(urunler[4].UrunAd);
						//Lcd_Puts("biskuvi");
						//Lcd_Puts(bes.UrunAd);
						urunlerinToplamFiyati = UrunFiyat[4] + urunlerinToplamFiyati;
			    	}
			    	else
			    	{
						Lcd_Goto(1, 1);
						LcdPutChar((siparis[4]/10) + '0');
						LcdPutChar(siparis[4]-((siparis[4]/10)*10) + '0');
						Lcd_Goto(1, 4);
						Lcd_Puts(UrunAd[3]);
						urunlerinToplamFiyati = UrunFiyat[4] + urunlerinToplamFiyati;
			    	}
				}

				if (urunlerinToplamFiyati > para)
				{
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 1);
					Lcd_Puts("Eksik para");
					Lcd_Goto(2, 1);
					Lcd_Puts("attiniz");
					delay(1500);
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("PARA IADESI");
					Lcd_Goto(2, 4);
					Lcd_Puts("YAPILIYOR");
					delay(1500);
					//Kasaya eklenen paralar cikartiliyor geri verildiği için
					kasadakiParalar[0] = kasadakiParalar[0] - atilan25;
					kasadakiParalar[1] = kasadakiParalar[1] - atilan50;
					kasadakiParalar[2] = kasadakiParalar[2] - atilan1;
					//değişkenleri sifirla
					atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
					verilen25 = 0,  verilen50 = 0, verilen1 = 0;
					para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;

					SiparisSifirla();
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("Para girisi");
					Lcd_Goto(2, 4);
					Lcd_Puts("yapiniz...");
					delay(100);
					ctrl = 0;
				}
			}

			if (buton6_Bitis != 0)
			{
				LcdEkranTemizle();
				delay(100);
				Lcd_Goto(1, 1);
				Lcd_Puts("Islem yapiliyor");
				ctrl = 2;

				delay(1000);
				LcdEkranTemizle();
				Lcd_Goto(1, 8);
				LcdPutChar(rast + '0');
				Lcd_Goto(2, 1);
				Lcd_Puts("sayisi uretildi");
				if (rast == 2) {
					/* PARA SIKIŞTI
					 * KIRMIZI LEDİ YAK
					 * PARA İADESİ YAP
					 */
					GPIO_PORTF_DATA_R |= 0b00000010;
					//Kasaya eklenen paralar cikartiliyor geri verildiği için
					kasadakiParalar[0] = kasadakiParalar[0] - atilan25;
					kasadakiParalar[1] = kasadakiParalar[1] - atilan50;
					kasadakiParalar[2] = kasadakiParalar[2] - atilan1;

					//değişkenleri sifirla
					atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
					verilen25 = 0,  verilen50 = 0, verilen1 = 0;
					para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;
					SiparisSifirla();
					delay(2000);
					LcdEkranTemizle();
					delay(100);
					Lcd_Goto(1, 3);
					Lcd_Puts("Para girisi");
					Lcd_Goto(2, 4);
					Lcd_Puts("yapiniz...");
					GPIO_PORTF_DATA_R &= ~(0b00000010);
					StringBirlestir();
					UARTBastirma();
					delay(100);
					ctrl = 0;
				}
				else if (rast == 1 || rast == 3 || rast == 4) {
					/*YEŞİL LEDİ YAK
					 * PARA ÜSTÜNÜ VER
					 */
					GPIO_PORTF_DATA_R |= 0b00001000;
					delay(700);

					//para üstünün verilmesi
					paraUstu = para - urunlerinToplamFiyati;

				    if(paraUstu>=1 && kasadakiParalar[2]!=0)
				    {
				    	verilen1 = paraUstu/1;
				        //verilecek1 = paraUstu/1;
				        if(kasadakiParalar[2]>=verilen1)
				        {
				            verilen1 = paraUstu/1;
				        }
				        else
				        {
				            verilen1 = kasadakiParalar[2];
				            //verilecek1 = verilecek1 - kasadakiParalar[2];
				        }
				        paraUstu = paraUstu - verilen1;
				    }
				    //50 kurus
				    if(paraUstu>=0.5 && kasadakiParalar[1]!=0)
				    {
				    	verilen50 = paraUstu/0.5;
				        if(kasadakiParalar[1]>=verilen50)
				        {
				            verilen50 = paraUstu/0.5;
				        }
				        else
				        {
				            verilen50 = kasadakiParalar[1];
				            //verilecek50 = verilecek50 - kasadakiParalar[1];
				        }
				        paraUstu = paraUstu - (verilen50*0.5);
				    }
				    //25 kurus
				    if(paraUstu>=0.25 && kasadakiParalar[0]!=0)
				    {
				    	verilen25 = paraUstu/0.25;
				        if(kasadakiParalar[0]>=verilen25)
				        {
				            verilen25 = paraUstu/0.25;;
				        }
				        else
				        {
				            verilen25 = kasadakiParalar[0];
				            //verilecek25 = verilecek25 - kasadakiParalar[0];
				        }
				        paraUstu = paraUstu - (verilen25*0.25);
				    }

				    if(paraUstu == 0)
				    {
						//ürünleri stoktan düşmek
						StoktanDus();

				    	LcdEkranTemizle();
				    	Lcd_Puts("Para ustu");
				    	Lcd_Goto(2, 1);
				    	Lcd_Puts("veriliyor...");
				    	delay(700);

				    	//1 tller
				    	LcdEkranTemizle();
				    	if(verilen1 < 10)
				    	{
							Lcd_Goto(1, 8);
							LcdPutChar(verilen1 + '0');
							Lcd_Goto(2, 3);
							Lcd_Puts("tane 1 TL");
							delay(700);
				    	}
				    	else
				    	{
							Lcd_Goto(1, 7);
							LcdPutChar((verilen1/10) + '0');
							LcdPutChar(verilen1-((verilen1/10)*10) + '0');
							Lcd_Goto(2, 3);
							Lcd_Puts("tane 1 TL");
							delay(700);
				    	}

						kasadakiParalar[2] = kasadakiParalar[2] - verilen1;

						//50kurus
				    	LcdEkranTemizle();
				    	if(verilen50 < 10)
				    	{
							Lcd_Goto(1, 8);
							LcdPutChar(verilen50 + '0');
							Lcd_Goto(2, 2);
							Lcd_Puts("tane 50 kurus");
							delay(700);
				    	}
				    	else
				    	{
							Lcd_Goto(1, 7);
							LcdPutChar((verilen50/10) + '0');
							LcdPutChar(verilen50-((verilen50/10)*10) + '0');
							Lcd_Goto(2, 3);
							Lcd_Puts("tane 50 kurus");
							delay(700);
				    	}

						kasadakiParalar[1] = kasadakiParalar[1] - verilen50;

						//25kurus
				    	LcdEkranTemizle();
				    	if(verilen25 < 10)
				    	{
							Lcd_Goto(1, 8);
							LcdPutChar(verilen25 + '0');
							Lcd_Goto(2, 2);
							Lcd_Puts("tane 25 kurus");
							delay(700);
				    	}
				    	else
				    	{
							Lcd_Goto(1, 7);
							LcdPutChar((verilen25/10) + '0');
							LcdPutChar(verilen25-((verilen25/10)*10) + '0');
							Lcd_Goto(2, 3);
							Lcd_Puts("tane 25 kurus");
							delay(700);
				    	}

						kasadakiParalar[0] = kasadakiParalar[0] - verilen25;

				    	LcdEkranTemizle();
				    	Lcd_Puts("Yeniden devreye");
				    	Lcd_Goto(2, 4);
				    	Lcd_Puts("giriliyor");
				    	delay(1500);
						//değişkenleri sifirla
						atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
						verilen25 = 0,  verilen50 = 0, verilen1 = 0;
						para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;
						SiparisSifirla();

						LcdEkranTemizle();
						delay(100);
						Lcd_Goto(1, 3);
						Lcd_Puts("Para girisi");
						Lcd_Goto(2, 4);
						Lcd_Puts("yapiniz...");
						StringBirlestir();
						UARTBastirma();
						GPIO_PORTF_DATA_R &= ~(0b00001000);
						delay(100);
						ctrl = 0;
				    }
				    else
				    {
				    	/*"Kasada yeterli para yoktur*/
						//ürünleri stoktan düşme
						StoktanDus();
						StringBirlestir();
						UARTBastirma();
				    	LcdEkranTemizle();
				    	Lcd_Puts("Kasada yeterli");
				    	Lcd_Goto(2, 1);
				    	Lcd_Puts("para yoktur");
				    	delay(2000);
						//değişkenleri sifirla
						atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
						verilen25 = 0,  verilen50 = 0, verilen1 = 0;
						para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;
						SiparisSifirla();

						LcdEkranTemizle();
						delay(100);
						Lcd_Goto(1, 3);
						Lcd_Puts("Para girisi");
						Lcd_Goto(2, 4);
						Lcd_Puts("yapiniz...");
						GPIO_PORTF_DATA_R &= ~(0b00001000);
						delay(100);
						ctrl = 0;
				    }
				}
			}
			 if(buton7_reset == 0 )
			 {
				LcdEkranTemizle();
				Lcd_Puts("Sifirlaniyor...");
				delay(1000);

				//Kasaya eklenen paralar cikartiliyor geri verildiği için
				kasadakiParalar[0] = kasadakiParalar[0] - atilan25;
				kasadakiParalar[1] = kasadakiParalar[1] - atilan50;
				kasadakiParalar[2] = kasadakiParalar[2] - atilan1;

				//değişkenleri sifirla
				atilan25 = 0, atilan50 = 0, atilan1 = 0, atilanTL = 0, atilanKurus = 0, yatilanTl = 0;
				verilen25 = 0,  verilen50 = 0, verilen1 = 0;
				para = 0, urunlerinToplamFiyati = 0, paraUstu = 0, yer = 1;
				SiparisSifirla();

				LcdEkranTemizle();
				delay(100);
				Lcd_Goto(1, 3);
				Lcd_Puts("Para girisi");
				Lcd_Goto(2, 4);
				Lcd_Puts("yapiniz...");
				StringBirlestir();
				UARTBastirma();
				delay(100);
				ctrl = 0;
			 }
		}
	}
}
