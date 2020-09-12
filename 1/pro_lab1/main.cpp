#include <stdio.h>
#include <stdlib.h>
#include <graphics.h>

int girenler[5][9]= {0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0
                    };

int cikanlar[5][9]= {0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0,
                     0,0,0,0,0,0,0,0,0
                    };

void harfler1()
{
    setcolor(7);
    //Harfler
    outtextxy(30,193,"t");
    outtextxy(188,191,"y");
    outtextxy(106,110,"x");
    outtextxy(106,270,"z");

    outtextxy(80,160,"a");
    outtextxy(130,160,"b");
    outtextxy(80,225,"c");
    outtextxy(130,225,"d");

}

void harita1()
{
    setlinestyle(0,0,3);
    settextstyle(8,HORIZ_DIR,1);
    outtextxy(50,70,"BÝRÝNCÝ YOL:");
    settextstyle(0,HORIZ_DIR,1);
    //dikdörtgen1
    rectangle(10,100,220,300);
    //yollarýn kenarlarý kahverengi oluyor
    setcolor(6);
    setlinestyle(0,0,2);
    //yatay1 yol
    line(20,190,60,190);
    line(20,210,60,210);
    //yatay 2 yol
    line(160,190,200,190);
    line (160,210,200,210);
    //dikey1 yol
    line(100,110,100,150);
    line(120,110,120,150);
    //dikey2 yol
    line(100,250,100,290);
    line(120,250,120,290);

    //Göbeklerin renkleri
    setfillstyle(SOLID_FILL,GREEN);
    setcolor(2);
    pieslice(110,200,0,360,30);
    setcolor(6);
    circle(110,200,30);
    //yan üst kesit 1
    arc(100,190,90,180,40);
    //yan alt kesit 2
    arc(100,210,180,270,40);
    //yan üst kesit 3
    arc (120,190,0,90,40);
    //yan alt kesit 4
    arc(120,210,270,360,40);
    setcolor(7);
    //yollarýn ortasý kesikli çizgi
    setlinestyle(4,3,1);
    line(20,200,60,200);
    line(160,200,200,200);
    line(110,110,110,150);
    line(110,250,110,290);
    arc(110,200,0,360,40);
    setlinestyle(0,0,0);
    harfler1();
}

void xgok()
{
    setlinestyle(0,0,3);
    setcolor(GREEN);
    int w;
    for(w=0; w<36; w++)
    {
        line(110,110,110,110+w);
        delay(10);
    }
    line (110,145,105,140);
    line (110,145,115,140);

    setlinestyle(0,0,0);
}

void xcok()
{
    setlinestyle(0,0,3);
    setcolor(RED);
    int r;
    for(r=0; r<31; r++)
    {
        line(110,145,110,140-r);
        delay(10);
    }
    line (110,110,105,120);
    line (110,110,115,120);

    setlinestyle(0,0,0);
}

void ygok()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(GREEN);
    for(i=0; i<36; i++)
    {
        line(200,200,200-i,200);
        delay(10);
    }
    line(165,200,170,195);
    line(165,200,170,205);
    setlinestyle(0,0,0);
}

void ycok()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(RED);
    for(i=0; i<36; i++)
    {
        line(165,200,165+i,200);
        delay(10);
    }
    line(200,200,195,205);
    line(200,200,195,195);
    setlinestyle(0,0,0);
}

void zgok()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(GREEN);
    for(i=0; i<36; i++)
    {
        line(110,290,110,290-i);
        delay(10);
    }
    line(110,255,105,260);
    line(110,255,115,260);
    setlinestyle(0,0,0);
}

void zcok()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(RED);
    for(i=0; i<36; i++)
    {
        line(110,255,110,255+i);
        delay(10);
    }
    line(110,290,105,285);
    line(110,290,115,285);
    setlinestyle(0,0,0);
}

void tgok()
{
    setlinestyle(0,0,3);
    setcolor(GREEN);
    int i;
    for(i=0; i<36; i++)
    {
        delay(10);
        line(20,200,20+i,200);
    }
    line(55,200,50,195);
    line(55,200,50,205);
    setlinestyle(0,0,0);
}

void tcok()
{
    setlinestyle(0,0,3);
    setcolor(RED);
    int i;
    for(i=0; i<31; i++)
    {
        delay(10);
        line(50,200,50-i,200);
    }
    line(20,200,25,195);
    line(20,200,25,205);
    setlinestyle(0,0,0);
}

void harfler2()
{
    setcolor(7);
    //Harfler
    outtextxy(267,193,"t");
    outtextxy(346,110,"x");
    outtextxy(425,191,"y");
    outtextxy(346,270,"z");

    outtextxy(317,160,"a");
    outtextxy(375,160,"b");
    outtextxy(318,225,"c");
    outtextxy(374,225,"d");
    outtextxy(346,191,"e");
}

void harita2()
{
    setlinestyle(0,0,3);
    settextstyle(8,HORIZ_DIR,1);
    outtextxy(300,70,"ÝKÝNCÝ YOL:");
    settextstyle(0,HORIZ_DIR,1);
    //dikdörtgen2
    rectangle(250,100,460,300);
    setcolor(6);
    setlinestyle(0,0,2);
    //yatay1 yol
    line(260,190,300,190);
    line(260,210,300,210);
    //yatay 2 yol
    line(400,190,440,190);
    line (400,210,440,210);
    //dikey1 yol
    line(340,110,340,150);
    line(360,110,360,150);
    //dikey2 yol
    line(340,250,340,290);
    line(360,250,360,290);
    //yan üst kesit 1
    arc(340,190,90,180,40);
    //yan alt kesit 2
    arc(340,210,180,270,40);
    //yan üst kesit 3
    arc (360,190,0,90,40);
    //yan alt kesit 4
    arc(360,210,270,360,40);
    //orta yarým daireler
    setcolor(6);
    pieslice(350,190,0,180,26);
    pieslice(350,210,180,360,26);
    setcolor(7);

    //kesikli yollar
    setlinestyle(4,3,1);
    line(260,200,300,200);
    line(318,200,391,200);
    line(400,200,440,200);
    line(350,110,350,150);
    arc(350,200,0,360,43);
    line(350,250,350,290);
    harfler2();
}

void xgok2()
{
    setlinestyle(0,0,3);
    setcolor(GREEN);
    int w;
    for(w=0; w<41; w++)
    {
        line(350,110,350,110+w);
        delay(10);
    }
    line (350,150,355,145);
    line (350,150,345,145);

    setlinestyle(0,0,0);
}

void xcok2()
{
    setlinestyle(0,0,3);
    setcolor(RED);
    int r;
    for(r=0; r<36; r++)
    {
        line(350,150,350,150-r);
        delay(10);
    }
    line (350,110,345,120);
    line (350,110,355,120);

    setlinestyle(0,0,0);
}

void ygok2()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(GREEN);
    for(i=0; i<41; i++)
    {
        line(440,200,440-i,200);
        delay(10);
    }
    line(400,200,405,195);
    line(400,200,405,205);
    setlinestyle(0,0,0);
}

void ycok2()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(RED);
    for(i=0; i<41; i++)
    {
        line(400,200,400+i,200);
        delay(10);
    }
    line(440,200,435,195);
    line(440,200,435,205);
    setlinestyle(0,0,0);
}

void zgok2()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(GREEN);
    for(i=0; i<41; i++)
    {
        line(350,290,350,290-i);
        delay(10);
    }
    line(350,250,355,255);
    line(350,250,345,255);
    setlinestyle(0,0,0);
}

void zcok2()
{
    int i;
    setlinestyle(0,0,3);
    setcolor(RED);
    for(i=0; i<41; i++)
    {
        line(350,250,350,250+i);
        delay(10);
    }
    line(350,290,355,285);
    line(350,290,345,285);
    setlinestyle(0,0,0);
}

void tgok2()
{
    setlinestyle(0,0,3);
    setcolor(GREEN);
    int i;
    for(i=0; i<41; i++)
    {
        delay(10);
        line(260,200,260+i,200);
    }
    line(300,200,295,195);
    line(300,200,295,205);
    setlinestyle(0,0,0);
}

void tcok2()
{
    setlinestyle(0,0,3);
    setcolor(RED);
    int i;
    for(i=0; i<41; i++)
    {
        delay(10);
        line(300,200,300-i,200);
    }
    line(260,200,265,195);
    line(260,200,265,205);
    setlinestyle(0,0,0);
}

void tdenxe1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(102,193,175-i,180,30);
        delay(10);
    }
    line(103,165,95,157);
    line(103,165,96,171);
}

void xtentye1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(102,193,90,95+i,30);
        delay(10);
    }

    line (72,193,65,188);
    line (72,193,80,188);
}

void xdenyye1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(120,190,85-i,90,30);
        delay(10);
    }

    line(150,190,155,185);
    line(150,190,140,185);
}

void ydenxe1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(120,190,0,5+i,30);
        delay(10);
    }
    arc(120,190,0,90,30);
    line(120,160,125,165);
    line(120,160,125,155);
}

void ydenzye1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(120,210,355-i,360,30);
        delay(10);
    }
    line(120,239,126,230);
    line(120,239,126,245);
}

void zdenyye1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(120,210,270,275+i,30);
        delay(10);
    }
    line(150,210,155,215);
    line(150,210,140,215);
}

void zdentye1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(100,208,265-i,270,30);
        delay(10);
    }
    line(78,215,70,206);
    line(64,215,70,206);
}

void tdenzye1()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(100,208,180,185+i,30);
        delay(10);
    }

    line(95,230,100,238);
    line(95,243,100,238);
}

void secim1()
{
    setlinestyle(0,0,2);
    char baslangici, yonu;
xtdon:
    printf("a caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='x' &&yonu=='t' || baslangici=='t'&&yonu=='x')
    {
        if(yonu=='x')
        {
            tdenxe1();
            girenler[2][4]=1;
            cikanlar[1][4]=1;
        }
        else
        {
            xtentye1();
            girenler[1][4]=1;
            cikanlar[2][4]=1;
        }
        harfler1();
    }
    else
    {

        goto xtdon;
    }

xydon:
    printf("b caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='x' &&yonu=='y' || baslangici=='y'&&yonu=='x')
    {

        if(yonu=='y')
        {
            xdenyye1();
            girenler[3][5]=1;
            cikanlar[2][5]=1;
        }

        else
        {
            ydenxe1();
            girenler[2][5]=1;
            cikanlar[3][5]=1;
        }
        harfler1();
    }
    else
    {
        goto xydon;
    }

tzdon:
    printf("c caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='t' &&yonu=='z' || baslangici=='z'&&yonu=='t')
    {

        if(yonu=='t')
        {
            zdentye1();
            girenler[1][6]=1;
            cikanlar[4][6]=1;
        }

        else
        {
            tdenzye1();
            girenler[4][6]=1;
            cikanlar[1][6]=1;
        }
        harfler1();
    }
    else
    {
        goto tzdon;
    }

zydon:
    printf("d caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='z' &&yonu=='y' || baslangici=='y'&&yonu=='z')
    {

        if(yonu=='z')
        {
            ydenzye1();
            girenler[4][7]=1;
            cikanlar[3][7]=1;
        }

        else
        {
            zdenyye1();
            girenler[3][7]=1;
            cikanlar[4][7]=1;
        }
        harfler1();
    }
    else
    {
        goto zydon;
    }
}

void tdenxe2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(340,191,175-i,180,30);
        delay(10);
    }
    line(340,160,330,157);
    line(340,160,330,169);
}

void xtentye2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(340,191,90,95+i,30);
        delay(10);
    }
    line(312,191,305,180);
    line(311,190,320,180);
}

void xdenyye2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(360,190,85-i,90,30);
        delay(10);
    }

    line(390,190,380,180);
    line (390,190,395,180);
}

void ydenxe2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(360,190,0,5+i,30);
        delay(10);
    }

    line(360,160,370,155);
    line(360,160,368,168);
}

void ydenzye2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(360,210,355-i,360,30);
        delay(10);
    }

    line(360,240,365,233);
    line(360,240,365,244);
}

void zdenyye2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(360,210,270,275+i,30);
        delay(10);
    }

    line(389,210,380,220);
    line(389,210,395,220);
}

void zdentye2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(342,213,265-i,270,30);
        delay(10);
    }

    line(312,210,320,220);
    line(312,210,305,220);
}

void tdenzye2()
{
    setcolor(14);
    int i;
    for(i=0; i<85; i++)
    {
        arc(342,213,180,185+i,30);
        delay(10);
    }

    line(342,240,335,246);
    line(342,240,335,236);
}

void tdenyye2()
{
    setcolor(14);
    int i;
    for(i=0; i<80; i++)
    {
        line(310,200,310+i,200);
        delay(10);
    }

    line(390,200,380,190);
    line(390,200,380,210);
}

void ydentye2()
{
    setcolor(14);
    int i;
    for(i=0; i<80; i++)
    {
        line(390-i,200,390,200);
        delay(10);
    }

    line(310,200,320,190);
    line(310,200,320,210);
}

void secim2()
{
    setlinestyle(0,0,2);
    char baslangici, yonu;

xt2don:
    printf("a caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='x' &&yonu=='t' || baslangici=='t'&&yonu=='x')
    {
        if(yonu=='x')
        {
            tdenxe2();
            girenler[2][4]=1;
            cikanlar[1][4]=1;
        }
        else
        {
            xtentye2();
            girenler[1][4]=1;
            cikanlar[2][4]=1;
        }
        harfler2();
    }
    else
    {
        goto xt2don;
    }

xy2don:
    printf("b caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='x' &&yonu=='y' || baslangici=='y'&&yonu=='x')
    {
        if(yonu=='y')
        {
            xdenyye2();
            girenler[3][5]=1;
            cikanlar[2][5]=1;
        }
        else
        {
            ydenxe2();
            girenler[2][5]=1;
            cikanlar[3][5]=1;
        }
        harfler2();
    }
    else
    {
        goto xt2don;
    }

tz2don:
    printf("c caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='t' &&yonu=='z' || baslangici=='z'&&yonu=='t')
    {

        if(yonu=='t')
        {
            zdentye2();
            girenler[1][6]=1;
            cikanlar[4][6]=1;
        }
        else
        {
            tdenzye2();
            girenler[4][6]=1;
            cikanlar[1][6]=1;
        }
        harfler2();
    }
    else
    {
        goto tz2don;
    }

zy2don:
    printf("d caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='z' &&yonu=='y' || baslangici=='y'&&yonu=='z')
    {
        if(yonu=='z')
        {
            ydenzye2();
            girenler[4][7]=1;
            cikanlar[3][7]=1;
        }
        else
        {
            zdenyye2();
            girenler[3][7]=1;
            cikanlar[4][7]=1;
        }
        harfler2();
    }
    else
    {
        goto zy2don;
    }


tydon:
    printf("e caddesinin; \nBaslangic Noktasi: ");
    scanf(" %c",&baslangici);
    printf("Yonu: ");
    scanf(" %c",&yonu);
    if(baslangici=='t' &&yonu=='y' || baslangici=='y'&&yonu=='t')
    {
        if(yonu=='y')
        {
            tdenyye2();
            girenler[3][8]=1;
            cikanlar[1][8]=1;
        }
        else
        {
            ydentye2();
            girenler[1][8]=1;
            cikanlar[3][8]=1;
        }
        harfler2();
    }
    else
    {
        goto tydon;
    }
}


int main()
{

    initwindow(500,500,"Window Text",0,0); // initwindow(500,500,"Pencere Yazýsý",0,0);
    settextstyle(10,HORIZ_DIR,1);
    outtextxy(125,5,"~ TRAFÝK YOLLARI ~");
    harita1();
    harita2();
deger:
    int secim;
    printf("Harita seciniz:");
    scanf(" %d",&secim);
    printf("\n");

    if(secim!=1 && secim!=2)
    {
        printf("Yanlis Secim Lutfen Tekrar Deneyiniz!");
        goto deger;
    }


    delay(1);
    cleardevice();
    if(secim==1)
    {
        outtextxy(150,5,"****TRAFÝK YOLLARI***");
        harita1();
    }
    else if(secim==2)
    {
        outtextxy(150,5,"****TRAFÝK YOLLARI***");
        harita2();
    }

    //x,y,z,t yani ana yollarýn yönlerinin belirlenilmesi ve kontrollerinin yapýlmasý
    char yon;
don:
    int girisler=0,cikislar=0;
    float degerTut, bol;

    printf("Giris yonunu belirtmek icin 'g' harfini, cikis icin ise 'c' harfini kullaniniz.\n");
    printf("Dikkat giris ve cikis yonleri 2'er tane olmak zorundadir.\n");

xyon:
    printf("x yonunu belirleyiniz: ");
    scanf(" %c",&yon);
    if(yon=='g' || yon=='c')
        if(yon=='g')
        {
            girisler++;
            girenler[0][0]=1;
            girenler[2][0]=1;
            if(secim==1)
            {
                xgok();
                harfler1();
            }
            else if(secim==2)
            {
                xgok2();
                harfler2();
            }
        }
        else
        {
            cikanlar[0][0]=1;
            cikanlar[2][0]=1;
            if(secim==1)
            {
                xcok();
                harfler1();
            }
            else if(secim==2)
            {
                xcok2();
                harfler2();
            }
        }
    else
    {
        printf("Yanlis secim, belirtilen degerlerden birini seciniz...\n");
        goto xyon;
    }

yyon:
    printf("y yonunu belirleyiniz: ");
    scanf(" %c",&yon);
    if(yon=='g' || yon=='c')
        if(yon=='g')
        {
            girisler++;
            girenler[0][1]=1;
            girenler[3][1]=1;
            if(secim==1)
            {
                ygok();
                harfler1();
            }
            else if(secim==2)
            {
                ygok2();
                harfler2();
            }

        }
        else
        {
            cikislar++;
            cikanlar[0][1]=1;
            cikanlar[3][1]=1;
            if(secim==1)
            {
                ycok();
                harfler1();
            }
            else if(secim==2)
            {
                ycok2();
                harfler2();
            }
        }

    else
    {
        printf("Yanlis secim, belirtilen degerlerden birini seciniz...\n");
        goto yyon;
    }

zyon:
    printf("z yonunu belirleyiniz: ");
    scanf(" %c",&yon);
    if(yon=='g' || yon=='c')
        if(yon=='g')
        {
            girisler++;
            girenler[0][2]=1;
            girenler[4][2]=1;
            if(secim==1)
            {
                zgok();
                harfler1();
            }
            else if(secim==2)
            {
                zgok2();
                harfler2();
            }
        }
        else
        {
            cikislar++;
            cikanlar[0][2]=1;
            cikanlar[4][2]=1;
            if(secim==1)
            {
                zcok();
                harfler1();
            }
            else if(secim==2)
            {
                zcok2();
                harfler2();
            }
        }

    else
    {
        printf("Yanlis secim, belirtilen degerlerden birini seciniz...\n");
        goto zyon;
    }

tyon:
    printf("t yonunu belirleyiniz: ");
    scanf(" %c",&yon);
    if(yon=='g' || yon=='c')
        if(yon=='g')
        {
            girisler++;
            girenler[0][3]=1;
            girenler[1][3]=1;
            if(secim==1)
            {
                tgok();
                harfler1();
            }
            else if(secim==2)
            {
                tgok2();
                harfler2();
            }
        }
        else
        {
            cikislar++;
            cikanlar[0][3]=1;
            cikanlar[1][3]=1;
            if(secim==1)
            {
                tcok();
                harfler1();
            }
            else if(secim==2)
            {
                tcok2();
                harfler2();
            }

        }

    else
    {
        printf("Yanlis secim, belirtilen degerlerden birini seciniz...\n");
        goto tyon;
    }


    if (girisler>2 || cikislar>2)  //giriþ ve çýkýþ sayýsý 2þerli olmasý gerektiðini söylediði için böyle bir kontrol kullandým
    {
        printf("Hatali giris yaptiniz, lutfen secimlerinizi bastan giriniz.\n");
        for(int i=0; i<=4; i++)
        {
            for(int j=0; j<5; j++)
            {
                girenler[j][i]=0;
                cikanlar[j][i]=0;
            }
        }
        if(secim==1)
        {
            cleardevice();
            harita1();
        }
        else if(secim==2)
        {
            cleardevice();
            harita2();
        }

        goto don;
    }



    printf("\nCadde Yonlerinin Belirlenmesi;\n");
    if(secim==1)
        secim1();
    else
        secim2();



    printf("\nYollarin Degerlerinin Alinmasi;\n");

    char bilinmeyenler[9];
    int bilinmeyen=0,adimlar=0,deger;
    printf("x'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='x';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][0]==1)
            cikanlar[i][0]=deger;
        else if (girenler[i][0]==1)
            girenler[i][0]=deger;
    }

    printf("y'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='y';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][1]==1)
            cikanlar[i][1]=deger;
        else if (girenler[i][1]==1)
        {
            girenler[i][1]=deger;
        }
    }

    printf("z'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='z';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][2]==1)
            cikanlar[i][2]=deger;
        else if (girenler[i][2]==1)
        {

            girenler[i][2]=deger;
        }
    }

    printf("t'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='t';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][3]==1)
            cikanlar[i][3]=deger;
        else if (girenler[i][3]==1)
            girenler[i][3]=deger;
    }

    printf("a'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='a';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][4]==1)
            cikanlar[i][4]=deger;
        else if (girenler[i][4]==1)
            girenler[i][4]=deger;
    }

    printf("b'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='b';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][5]==1)
            cikanlar[i][5]=deger;
        else if (girenler[i][5]==1)
            girenler[i][5]=deger;
    }

    printf("c'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='c';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][6]==1)
            cikanlar[i][6]=deger;
        else if (girenler[i][6]==1)
            girenler[i][6]=deger;
    }

    printf("d'nin degerini giriniz: ");
    scanf("%d",&deger);
    if(deger==-1)
    {
        bilinmeyenler[bilinmeyen]='d';
        bilinmeyen++;
    }
    for(int i=0; i<5; i++)
    {
        if(cikanlar[i][7]==1)
            cikanlar[i][7]=deger;
        else if (girenler[i][7]==1)
            girenler[i][7]=deger;
    }

    if(secim==2)
    {
        printf("e'nin degerini giriniz: ");
        scanf("%d",&deger);
        if(deger==-1)
        {
            bilinmeyenler[bilinmeyen]='e';
            bilinmeyen++;
        }
        for(int i=0; i<5; i++)
        {
            if(cikanlar[i][8]==1)
                cikanlar[i][8]=deger;
            else if (girenler[i][8]==1)
                girenler[i][8]=deger;
        }
    }


    //Girenler ve çýkanlar dizilerinin düzenlenmeleri
    for(int i=0; i<5; i++)
    {
        for(int j=0; j<9; j++)
        {
            if(girenler[i][j]==-1)
                girenler[i][j]=1;
            else if(girenler[i][j]!=0) //Deðer biliniyorsa
            {
                cikanlar[i][j]=(girenler[i][j]*-1);
                girenler[i][j]=0;
            }
            if(cikanlar[i][j]==-1)
            {
                girenler[i][j]=cikanlar[i][j];     //-1 aslýnda 1 karþýya "-1" olarak geçer
                cikanlar[i][j]=0;
            }

        }
    }


    //Çýkanlarýn toplanmalarý satýr satýr
    for(int i=0; i<5; i++)
    {
        for(int j=1; j<9; j++)
        {
            cikanlar[i][0]=cikanlar[i][j]+cikanlar[i][0];
        }
        printf("\n");
    }


    float gauss[5][6];
    int gsutunsayisi=0;

    //Gauss için dizinin hazýrlanmasý
    for(int j=0; j<9; j++)
    {
        int kontrol=0;
        for(int i=0; i<5; i++)
        {
            if(girenler[i][j]==1 || girenler[i][j]==-1)
            {
                kontrol++;
            }
        }

        if(kontrol!=0)
        {
            for(int i=0; i<5; i++)
            {
                gauss[i][gsutunsayisi]=girenler[i][j];
            }
            gsutunsayisi++;
        }

    }

    //Boþ kalan sütunlarý 0 ile dolduruyoruz.
    while(gsutunsayisi<5)
    {
        for(int i=0; i<5; i++)
        {
            gauss[i][gsutunsayisi]=0;
        }
        gsutunsayisi++;
    }

    //Denklemin eþitleri en sol sütuna yazýlýyor.
    for(int i=0; i<5; i++)
    {
        gauss[i][5]=cikanlar[i][0];
    }


    printf("\nGauss Matrisi \n");
    for(int i=0; i<5; i++)
    {
        for(int j=0; j<6; j++)
        {
            printf("%.1f\t",gauss[i][j]);
        }
        printf("\n");
    }
    printf("\n");


    for(int i=0; i<4; i++)
    {

        for(int k=i+1; k<5; k++)
        {

            //negatifse pozitifliyor.
            if(gauss[i][i]==-1)
            {
                printf("%d) %d.satir -1 ile carpildi.\n",++adimlar,i+1);
                for(int j=0; j<6; j++)
                {
                    if(gauss[i][j]!=0)
                    {
                        gauss[i][j]*=-1;
                    }

                }

                for(int i=0; i<5; i++)
                {
                    for(int j=0; j<6; j++)
                    {
                        printf("%.1f\t",gauss[i][j]);
                    }
                    printf("\n");
                }
                printf("\n");
            }



            if(gauss[i][i]!=1)
            {
                if(abs(gauss[k][i])>abs(gauss[i][i]))
                {
                    for(int j=0; j<6; j++)
                    {
                        float temp;
                        temp=gauss[i][j];
                        gauss[i][j]=gauss[k][j];
                        gauss[k][j]=temp;
                    }
                    printf("%d) %d.satir ile %d.satir yer degistirildi.\n",++adimlar,i+1,k+1);

                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }

                if(gauss[i][i]!=1 && gauss[i][i]!=0)
                {
                    float bol;
                    bol=gauss[i][i];
                    printf("%d) %d.satir, %.0f ile bolundu.\n",++adimlar,i+1,bol);
                    for(int j=0; j<6; j++)
                    {
                        if(gauss[i][j]!=0)
                        {
                            gauss[i][j]=gauss[i][j]/bol;
                        }

                    }

                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }
            }
        }


        //alt üçgeni "0" yapma
        for(int k=i+1; k<5; k++)
        {

            if(gauss[k][i]!=0)
            {
                if(gauss[k][i]>0)  //eðer ki üstteki pozitif ise alttakinden üstekini çýkar.
                {
                    if(abs(gauss[k][i])!=abs(gauss[i][i]))
                    {
                        degerTut=gauss[k][i]/gauss[i][i];
                        for(int j=0; j<6; j++)
                        {
                            gauss[k][j]=gauss[k][j]-(gauss[i][j]*degerTut);
                        }
                        printf("%d) %d.satir %.0f ile carpildi ve %d.satirdan cikarildi.\n",++adimlar,i+1,degerTut,k+1);
                    }
                    else
                    {
                        for(int j=0; j<6; j++)
                        {
                            gauss[k][j]=gauss[k][j]-gauss[i][j];
                        }
                        printf("%d) %d.satirdan %d.satir cikarildi.\n",++adimlar,k+1,i+1);
                    }


                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }

                else   //eðer ki üstteki eksili ise toplama iþlemi yap.
                {

                    if(abs(gauss[k][i])!=abs(gauss[i][i]))
                    {
                        degerTut=gauss[k][i]/gauss[i][i];
                        for(int j=0; j<6; j++)
                        {
                            gauss[k][j]=gauss[k][j]+(gauss[i][j]*degerTut);
                        }
                        printf("%d) %d.satir %.0f ile carpildi ve %d.satir toplandi.\n",++adimlar,i+1,degerTut,k+i);
                    }
                    else
                    {
                        for(int j=0; j<6; j++)
                        {
                            gauss[k][j]=gauss[k][j]+gauss[i][j];
                        }
                        printf("%d) %d.satir ile %d.satir toplandi.\n",++adimlar,k+1,i+1);
                    }

                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }
            }
        }
    }



    //Üst üçgeninde sýfýr yapýlmasý
    for(int i=4; i>0; i--)
    {

        if(gauss[i][i]==1)
        {

            for(int k=i-1; k>=0; k--)
            {

                if(gauss[k][i]>0)  //eðer ki alttaki 1 ise alttakinden üstekini çýkar.
                {
                    if(gauss[k][i]!=1)
                    {
                        degerTut=gauss[k][i]/gauss[i][i];
                        for(int j=i; j<6; j++)
                        {
                            gauss[k][j]=gauss[k][j]-(gauss[i][j]*degerTut);
                        }
                        printf("%d) %d.satirdan, %d satir %.0f ile carpilip cikarildi.\n",++adimlar,k+1,i+1,degerTut);
                    }

                    else
                    {
                        for(int j=i; j<6; j++)
                        {
                            gauss[k][j]=gauss[k][j]-gauss[i][j];
                        }
                        printf("%d) %d.satirdan %d.satir cikarildi.\n",++adimlar,k+1,i+1);
                    }


                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }

                else if(gauss[k][i]<0)   //eðer ki alttaki "-1" ise toplama iþlemi yap.
                {
                    for(int j=i; j<6; j++)
                    {
                        gauss[k][j]=gauss[k][j]+gauss[i][j];
                    }
                    printf("%d) %d.satir ile %d.satir toplandi.\n",++adimlar,k+1,i+1);

                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }

                //virgüllü denk gelmesi durumunda
                else if(gauss[k][i]>-1 && gauss[k][i]<0)   //eðer ki alttaki -0.'lý bir deðerse
                {
                    float kat;
                    kat=gauss[i][i]/gauss[k][i];
                    for(int j=i; j<6; j++)
                    {
                        gauss[k][j]=(gauss[k][j]*kat)+gauss[i][j];
                    }
                    printf("%d) %d.satir %0.2f ile carpilip, %d.satir toplandi.\n",++adimlar,k+1,kat,i+1);

                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }

                else if(gauss[k][i]<1 && gauss[k][i]>0)  //eðer ki alttaki 0.'li bir deðer ise
                {
                    float kat;
                    kat=gauss[i][i]/gauss[k][i];
                    for(int j=i; j<6; j++)
                    {
                        gauss[k][j]=(gauss[k][j]*kat)-gauss[i][j];
                    }
                    printf("%d) %d.satir %0.2f ile carpilip, %d.satir cikarildi.\n",++adimlar,k+1,kat,i+1);

                    for(int i=0; i<5; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            printf("%.1f\t",gauss[i][j]);
                        }
                        printf("\n");
                    }
                    printf("\n");
                }

            }
        }
    }


    printf("\nSonuclar;\n");

    //Çözümün olup, olmadýðýnýn kararý ve sonuçlarýn ekrana yazýlmasý
    for(int i=0; i<bilinmeyen; i++)
    {
        int cozum=0;
        if(gauss[i][i]==1)
        {
            for(int j=0; j<5; j++)
            {
                if(gauss[i][j]!=0)
                {
                    cozum++;
                }
            }
            if(cozum>1)
            {
                printf("%c = bulunamadi\n",bilinmeyenler[i]);
            }
            else
            {
                printf("%c = %.1f\n",bilinmeyenler[i],gauss[i][5]);
            }
        }
        else
        {
            printf("%c = bulunamadi\n",bilinmeyenler[i]);
        }
    }


    getch();
    return 0;
}

