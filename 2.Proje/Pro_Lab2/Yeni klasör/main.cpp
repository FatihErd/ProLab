#include <iostream>
#include<string>
#include<fstream>
#include <sstream>
#include <cstring>
#include <string.h>

using namespace std;

struct Girisler
{
    string giris;
    int deger;
};

struct Cikis
{
    string cikis;
    int deger;
};

struct Kapi
{
    string tur;
    Girisler girisler[3];
    Cikis cikislar;
    int gecikme;
    int girisSayisi;
};

int ve(int a, int b, int c)
{
    if(a==1 && b==1 && c==1)
        return 1;
    else
        return 0;
}

int ve(int a, int b)
{
    if(a==1 && b==1)
        return 1;
    else
        return 0;
}

int veDegil(int a, int b, int c)
{
    if(a==1 && b==1 && c==1)
        return 0;
    else
        return 1;
}

int veDegil(int a, int b)
{
    if(a==1 && b==1)
        return 0;
    else
        return 1;
}

int veya(int a, int b, int c)
{
    if(a==0 && b==0 && c==0)
        return 0;
    else
        return 1;
}

int veya(int a, int b)
{
    if(a==0 && b==0)
        return 0;
    else
        return 1;
}

int veyaDegil(int a, int b, int c)
{
    if(a==0 && b==0 && c==0)
        return 1;
    else
        return 0;
}

int veyaDegil(int a, int b)
{
    if(a==0 && b==0)
        return 1;
    else
        return 0;
}

int ozelVeya(int a, int b, int c)
{
    if((a==0 && b==0 && c==0) || (a==1 && b==1 && c==1))
        return 0;
    else
        return 1;
}

int ozelVeya(int a, int b)
{
    if((a==0 && b==0) || (a==1 && b==1))
        return 0;
    else
        return 1;
}

int degil(int a)
{
    if(a==0)
        return 1;
    else
        return 0;
}

string kelime, kelime2, dosyaYolu, satir, cikisAd, cikisAd2;
Girisler g[20], gKopya[20];
int i=0, indis=0, sayi, bul, say;
Kapi kapi[100];
char harf;

ofstream yazLog("log.txt");
string komut;

void devreYukle();
void ilklendir();
void yukselt();
void dusur();
void listele();
void belliListele();
void simuleEt();
void komutOku();

void kDevreYukle();
void kIlklendir();
void kYukselt();
void kDusur();
void kListele();
void kBelliListele();
void kSimuleEt();

string kucult(string a)
{
    for (size_t i = 0 ; i < a.size() ; ++i)
    {
        char character = tolower(a[i]);
        a[i] = character;
    }
    return a;
}

void atama()
{
    for(int j=0; i>j; j++)      //girislerin olduğu dizi
    {
        for(int f=0; indis>f; f++)  //kapıların olduğu dizi
        {
            if(g[j].giris==kapi[f].cikislar.cikis)
            {
                if(kapi[f].cikislar.deger!=g[j].deger)
                {
                    //cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<g[j].deger<<endl;
                    kapi[f].cikislar.cikis=g[j].deger;
                }
            }

            for(int w=0; w<kapi[f].girisSayisi; w++)
            {
                if(kapi[f].girisler[w].giris==g[j].giris)
                {
                    if(kapi[f].girisler[w].deger!=g[j].deger)
                    {
                        //cout<<ns<<".ns: "<<kapi[f].girisler[w].giris<<" "<<kapi[f].girisler[w].deger<<"->"<<g[j].deger<<endl;
                        kapi[f].girisler[w].deger=g[j].deger;
                    }

                }
            }
        }
    }
}


int main()
{
Basa:
    cout<<"> ";
    getline(cin, komut);
    int buldum = komut.find_first_of(" "); //ilk bosluk bulundu
    bul=buldum;
    string secim(komut, 0, bul);    //komut çekildi cekildi

    //komut daki bosluklari sayiyor
    say=0;
    for(int i=0; i<komut.size(); i++)
    {
        if(komut[i]==' ')
        {
            say++;
        }
    }


    if(secim=="C" || secim=="c")
    {
        yazLog<<"> "<<secim<<"\t";
        yazLog<<"cikis yapildi."<<endl;
        return 0;
    }

    else if(secim=="Y" || secim=="y")
    {
        devreYukle();
    }


    else if(secim=="I" || secim=="i")
    {
        ilklendir();
    }


    else if(secim=="H" || secim=="h")
    {
        yukselt();
    }


    else if(secim=="L" || secim=="l")
    {
        dusur();
    }


    else if(secim=="S" || secim=="s")
    {
        yazLog<<"> "<<komut<<" simule edildi"<<endl;
        simuleEt();
    }


    else if(secim=="G*" || secim=="g*")
    {
        listele();
    }

    else if(secim=="G" || secim=="g")
    {
        belliListele();
    }

    else if(secim=="K" || secim=="k")
    {
        komutOku();
    }

    goto Basa;


    /*for(int a=0; indis>a; a++)
    {
        cout<<"Cikis:"<<kapi[a].cikislar.cikis<<endl<<"tur:"<<kapi[a].tur<<endl<<"gecikme:"<<kapi[a].gecikme<<endl<<"Cikis Degeri:"
            <<kapi[a].cikislar.deger<<endl<<endl;
    }*/




    return 0;
}


void devreYukle()
{

    string dYolu(komut.begin() + bul + 1, komut.end());

    yazLog<<"> "<<komut<<"\t";
    yazLog<<dYolu<<" yuklendi"<<endl;

    ifstream okuDevre1(dYolu.c_str());
    okuDevre1>>kelime;

    if(kelime==".include")
    {
        okuDevre1>>dosyaYolu;
        ifstream okuDevre2(dosyaYolu.c_str());
        okuDevre2>>kelime2;

        if(kelime2==".giris")
        {
            okuDevre2>>kelime2;

            while(kelime2!=".cikis")
            {
                if(kelime2[0]=='#')
                {
                    break;
                }
                g[i].giris=kucult(kelime2);
                i++;
                okuDevre2>>kelime2;
            }
        }

        while(kelime2!=".cikis")
        {
            okuDevre2>>kelime2;
        }

        okuDevre2>>cikisAd2;
        g[i].giris=kucult(cikisAd2);
        i++;
        okuDevre2>>kelime2;


        if(kelime2[0]=='#')
        {
            while(kelime2!=".kapi")
            {
                okuDevre2>>kelime2;
            }
        }

Don2:
        if(kelime2==".kapi")
        {
            okuDevre2>>kelime2;
            kapi[indis].tur=kucult(kelime2);
            while(kelime2!=".kapi")
            {
                okuDevre2>>kapi[indis].girisSayisi;
                okuDevre2>>kelime2;
                kapi[indis].cikislar.cikis=kucult(kelime2);
                for(int q=0; 2>q; q++)
                {
                    okuDevre2>>kelime2;
                    kapi[indis].girisler[q].giris=kucult(kelime2);
                    g[i].giris=kapi[indis].girisler[q].giris;
                    i++;
                }
                okuDevre2>>kapi[indis].gecikme;
                indis++;
                okuDevre2>>kelime2;
                kelime2=kucult(kelime2);
                if(kelime[0]=='#')
                {
                    while(kelime2!=".kapi")
                    {
                        okuDevre2>>kelime2;
                        if(kelime2==".son")
                            goto Devam1;
                    }
                }
                else if(kelime2==".son")
                    goto Devam2;
            }
        }
        if(kelime2==".kapi")
        {
            goto Don2;
        }
Devam2:
        okuDevre2.close();
    }

    if(kelime==".giris")
    {
        okuDevre1>>kelime;
        kelime=kucult(kelime);

        while(kelime!=".cikis")
        {
            if(kelime[0]=='#')
            {
                break;
            }
            g[i].giris=kucult(kelime);
            i++;
            okuDevre1>>kelime;
        }
    }

    while(kelime!=".cikis")
    {
        okuDevre1>>kelime;
    }

    okuDevre1>>cikisAd;
    g[i].giris=kucult(cikisAd);
    i++;
    okuDevre1>>kelime;

    if(kelime[0]=='#')
    {
        while(kelime!=".kapi")
        {
            okuDevre1>>kelime;
        }
    }

Don:
    if(kelime==".kapi")
    {
        okuDevre1>>kelime;
        kapi[indis].tur=kelime;
        while(kelime!=".kapi")
        {
            okuDevre1>>kapi[indis].girisSayisi;
            okuDevre1>>kelime;
            kapi[indis].cikislar.cikis=kucult(kelime);
            for(int q=0; kapi[indis].girisSayisi>q; q++)
            {
                okuDevre1>>kelime;
                kapi[indis].girisler[q].giris=kucult(kelime);
                g[i].giris=kapi[indis].girisler[q].giris;
                i++;
            }
            okuDevre1>>kapi[indis].gecikme;
            indis++;
            okuDevre1>>kelime;
            if(kelime[0]=='#')
            {
                while(kelime!=".kapi")
                {
                    okuDevre1>>kelime;
                    if(kelime==".son")
                        goto Devam1;
                }
            }
            else if(kelime==".son")
                goto Devam1;
        }
    }
    if(kelime==".kapi")
    {
        goto Don;
    }
Devam1:
    okuDevre1.close();
    /*      for(int a=0; indis>a; a++)
      {
          cout<<"Cikis:"<<kapi[a].cikislar.cikis<<endl<<"tur:"<<kapi[a].tur<<endl<<"gecikme:"<<kapi[a].gecikme<<endl<<"Cikis Degeri:"
              <<kapi[a].cikislar.deger<<endl<<endl;
      }*/

}

void ilklendir()
{
    yazLog<<"> "<<komut<<"\t";
    yazLog<<"ilklendirildi."<<endl;

    ifstream okuDeger("deger.txt");

    while(!okuDeger.eof())
    {
        okuDeger>>kelime;
        kelime=kucult(kelime);
        okuDeger>>sayi;

        for(int s=0; s<indis; s++)      //Kapylaryn içine giri? çyky? atama
        {
            if(kapi[s].cikislar.cikis==kelime)
            {
                kapi[s].cikislar.deger=sayi;
            }
            for(int w=0; w<kapi[s].girisSayisi; w++)
            {
                if(kapi[s].girisler[w].giris==kelime)
                {
                    kapi[s].girisler[w].deger=sayi;
                }
            }
        }

        for(int j=0; i>j; j++)      //giri? çyky?a de?erlerin atanmasy
        {
            if(g[j].giris==kelime)
            {
                g[j].deger=sayi;
            }
        }
    }
    okuDeger.close();

    //Küçükten büyü?e syralama
    Girisler degistir;
    degistir.giris="zzzz";
    for(int j=0; i>j+1; j++)
    {
        for(int d=j; d<i; d++)
        {
            if(g[j].giris>g[d].giris)
            {
                swap(g[j],g[d]);
            }

        }

        for(int d=j+1; d<i; d++)    //aynylarsa sona atyyor
        {
            if(g[j].giris==g[d].giris)
            {
                g[d]=degistir;
            }
        }
    }

    int sayac=0;
    for(int j=0; i>j; j++)
    {
        if(g[j].giris=="zzzz")
            sayac++;
    }
    i-=sayac;

    for(int j=0; i>j; j++)      //kopyalama
    {
        gKopya[j].giris=g[j].giris;
        gKopya[j].deger=g[j].deger;
        cout<<g[j].giris<<": "<<g[j].deger<<endl;
    }

//kapylaryn küçükten büyü?e syralanmalary

    for(int j=0; j<indis; j++)
    {
        for(int d=j; d<indis; d++)
        {
            if(kapi[j].gecikme>kapi[d].gecikme)
            {
                swap(kapi[j],kapi[d]);
            }

        }
    }
}

void yukselt()
{
    if(say<2)
    {
        yazLog<<"> "<<komut<<"\t girisi yukseltildi."<<endl;
        string icra(komut, bul+1, komut.size()-1);

        for(int j=0; j<i; j++)
        {
            if(icra==g[j].giris)
                g[j].deger=1;
        }
        for(int j=0; i>j; j++)      //giri? çyky?a de?erlerin atanmasy
        {
            cout<<g[j].giris<<": "<<g[j].deger<<endl;
        }

    }
    else
    {
        yazLog<<"> "<<komut<<"\t girisleri yukseltildi."<<endl;
        ofstream yazSatir("satir.txt", ios::out | ios::app);
        yazSatir<<komut<<endl;
        yazSatir.close();
        ifstream okuSatir("satir.txt");
        okuSatir>>satir;

        for(int j=0; say>j; j++)
        {
            okuSatir>>satir;

            for(int j=0; i>j; j++)
            {
                if(satir==g[j].giris)
                {
                    g[j].deger=1;
                }

            }
        }
        okuSatir.close();
        remove("satir.txt");
        for(int j=0; i>j; j++)      //ekrana yazdirma
        {
            cout<<g[j].giris<<": "<<g[j].deger<<endl;
        }

    }

}

void dusur()
{
    if(say<2)
    {
        yazLog<<"> "<<komut<<"\t girisi yukseltildi."<<endl;
        string icra(komut, bul+1, komut.size()-1);

        for(int j=0; j<i; j++)
        {
            if(icra==g[j].giris)
                g[j].deger=0;
        }
        for(int j=0; i>j; j++)      //giri? çyky?a de?erlerin atanmasy
        {
            cout<<g[j].giris<<": "<<g[j].deger<<endl;
        }

    }
    else
    {
        yazLog<<"> "<<komut<<"\t girisleri yukseltildi."<<endl;
        ofstream yazSatir("satir.txt", ios::out | ios::app);
        yazSatir<<komut<<endl;
        yazSatir.close();
        ifstream okuSatir("satir.txt");
        okuSatir>>satir;

        for(int j=0; say>j; j++)
        {
            okuSatir>>satir;

            for(int j=0; i>j; j++)
            {
                if(satir==g[j].giris)
                {
                    g[j].deger=0;
                }

            }
        }
        okuSatir.close();
        remove("satir.txt");
        for(int j=0; i>j; j++)      //ekrana yazdirma
        {
            cout<<g[j].giris<<": "<<g[j].deger<<endl;
        }

    }
}

void listele()
{
    yazLog<<"> "<<komut<<"\t listelendi;"<<endl;
    for(int j=0; i>j; j++)
    {
        yazLog<<"  "<<g[j].giris<<": "<<g[j].deger<<endl;
        cout<<g[j].giris<<": "<<g[j].deger<<endl;
    }
}

void belliListele()
{
    if(say<2)
    {
        yazLog<<"> "<<komut<<" listelendi"<<endl;
        string icra(komut, bul+1, komut.size()-1);
        cout<<"---"<<icra<<"---";

        for(int j=0; i>j; j++)
        {
            if(g[j].giris==icra)
            {
                yazLog<<"  "<<g[j].giris<<": "<<g[j].deger<<endl;
                cout<<g[j].giris<<": "<<g[j].deger<<endl;
            }

        }
    }

    else
    {
        yazLog<<"> "<<komut<<"\t listelendi;"<<endl;
        ofstream yazSatir("satir.txt", ios::out | ios::app);
        yazSatir<<komut<<endl;
        yazSatir.close();
        ifstream okuSatir("satir.txt");
        okuSatir>>satir;

        for(int j=0; say>j; j++)
        {
            okuSatir>>satir;

            for(int j=0; i>j; j++)
            {
                if(g[j].giris==satir)
                {
                    yazLog<<"  "<<g[j].giris<<": "<<g[j].deger<<endl;
                    cout<<g[j].giris<<": "<<g[j].deger<<endl;
                }

            }
        }
        okuSatir.close();
        remove("satir.txt");

    }

}

void simuleEt()
{
    cout<<"simuleye girdi"<<endl;
    int ns=0;

    if(cikisAd2!="0")   //degisecek son degeri bilmek icin
    {
        if(cikisAd2>cikisAd)
            cikisAd=cikisAd2;
    }

    atama();

    for(int j=0; i>j; j++)
    {
        if(gKopya[j].deger!=g[j].deger)
        {
            cout<<ns<<".ns: "<<gKopya[j].giris<<" "<<gKopya[j].deger<<"->"<<g[j].deger<<endl;
            yazLog<<" "<<ns<<".ns: "<<gKopya[j].giris<<" "<<gKopya[j].deger<<"->"<<g[j].deger<<endl;
        }
    }
Tekrarla:
    int nsKarsilastirma=0;
NSyeye:
    nsKarsilastirma++;
    ns++;


    for(int f=0; indis>f; f++)
    {

        if(nsKarsilastirma==kapi[f].gecikme)
        {
            if(kapi[f].tur=="AND")
            {
                if(kapi[f].girisSayisi==2)
                {
                    if((ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        kapi[f].cikislar.deger=ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
                else
                {
                    if((ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        kapi[f].cikislar.deger=ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
            }


            else if(kapi[f].tur=="NAND")
            {
                if(kapi[f].girisSayisi==2)
                {
                    if((veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        kapi[f].cikislar.deger=veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
                else
                {
                    if((veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        kapi[f].cikislar.deger=veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
            }


            else if(kapi[f].tur=="OR")
            {
                if(kapi[f].girisSayisi==2)
                {
                    if((veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        kapi[f].cikislar.deger=veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
                else
                {
                    if((veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        kapi[f].cikislar.deger=veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
            }


            else if(kapi[f].tur=="NOR")
            {
                if(kapi[f].girisSayisi==2)
                {
                    if((veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        kapi[f].cikislar.deger=veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
                else
                {
                    if((veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        kapi[f].cikislar.deger=veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
            }


            else if(kapi[f].tur=="XOR")
            {
                if(kapi[f].girisSayisi==2)
                {
                    if((ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger)<<endl;
                        kapi[f].cikislar.deger=ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
                else
                {
                    if((ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))!=kapi[f].cikislar.deger)
                    {
                        yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger)<<endl;
                        kapi[f].cikislar.deger=ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger);

                        for(int j=0; i>j; j++)
                        {
                            if(kapi[f].cikislar.cikis==g[j].giris)
                                g[j].deger=kapi[f].cikislar.deger;
                        }
                        atama();
                    }
                }
            }

            else if(kapi[f].tur=="NOT")
            {
                if(degil(kapi[f].girisler[0].deger)!=kapi[f].cikislar.deger)
                {
                    yazLog<<" "<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<degil(kapi[f].girisler[0].deger)<<endl;
                    cout<<ns<<".ns: "<<kapi[f].cikislar.cikis<<" "<<kapi[f].cikislar.deger<<"->"<<degil(kapi[f].girisler[0].deger)<<endl;
                    kapi[f].cikislar.deger=degil(kapi[f].girisler[0].deger);

                    for(int j=0; i>j; j++)
                    {
                        if(kapi[f].cikislar.cikis==g[j].giris)
                            g[j].deger=kapi[f].cikislar.deger;
                    }
                    atama();
                }
            }
        }
    }


    if(nsKarsilastirma!=kapi[indis-1].gecikme)
    {
        goto NSyeye;
    }

    //Dogruluk kontrolu
    int dogru=0;
    for(int f=0; indis>f; f++)
    {
        if(kapi[f].tur=="AND")
        {
            if(kapi[f].girisSayisi==2)
            {
                if((ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
            else
            {
                if((ve(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }

        }


        else if(kapi[f].tur=="NAND")
        {
            if(kapi[f].girisSayisi==2)
            {
                if((veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
            else
            {
                if((veDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
        }


        else if(kapi[f].tur=="OR")
        {
            if(kapi[f].girisSayisi==2)
            {
                if((veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
            else
            {
                if((veya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
        }


        else if(kapi[f].tur=="NOR")
        {
            if(kapi[f].girisSayisi==2)
            {
                if((veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
            else
            {
                if((veyaDegil(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
        }


        else if(kapi[f].tur=="XOR")
        {
            if(kapi[f].girisSayisi==2)
            {
                if((ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
            else
            {
                if((ozelVeya(kapi[f].girisler[0].deger,kapi[f].girisler[1].deger,kapi[f].girisler[2].deger))==kapi[f].cikislar.deger)
                {
                    dogru++;
                }
            }
        }

        else
        {
            if(degil(kapi[f].girisler[0].deger)==kapi[f].cikislar.deger)
            {
                dogru++;

            }
        }

    }
    if(dogru!=indis)
    {
        goto Tekrarla;
    }
}

void komutOku()
{
    string dYolu(komut.begin() + bul + 1, komut.end());
    yazLog<<"> "<<komut<<" yuklendi"<<endl;

    string dKomutu;
    ifstream dKomutOku(dYolu.c_str());

    while(!dKomutOku.eof())
    {
        dKomutOku>>dKomutu;
komutKarsilastir:
        yazLog<<" "<<dKomutu<<" ";

        if(dKomutu=="Y")
        {
            dKomutOku>>dKomutu;
            yazLog<<dKomutu<<" yuklendi"<<endl;
            ifstream okuDevre1(dKomutu.c_str());
            okuDevre1>>kelime;

            if(kelime==".include")
            {
                okuDevre1>>dosyaYolu;
                yazLog<<" "<<dosyaYolu<<" yuklendi";
                ifstream okuDevre2(dosyaYolu.c_str());
                okuDevre2>>kelime2;

                if(kelime2==".giris")
                {
                    okuDevre2>>kelime2;

                    while(kelime2!=".cikis")
                    {
                        if(kelime2[0]=='#')
                        {
                            break;
                        }
                        g[i].giris=kucult(kelime2);
                        i++;
                        okuDevre2>>kelime2;
                    }
                }

                while(kelime2!=".cikis")
                {
                    okuDevre2>>kelime2;
                }

                okuDevre2>>cikisAd2;
                g[i].giris=kucult(cikisAd2);
                i++;
                okuDevre2>>kelime2;


                if(kelime2[0]=='#')
                {
                    while(kelime2!=".kapi")
                    {
                        okuDevre2>>kelime2;
                    }
                }

Don2:
                if(kelime2==".kapi")
                {
                    okuDevre2>>kelime2;
                    kapi[indis].tur=kucult(kelime2);
                    while(kelime2!=".kapi")
                    {
                        okuDevre2>>kapi[indis].girisSayisi;
                        okuDevre2>>kelime2;
                        kapi[indis].cikislar.cikis=kucult(kelime2);
                        for(int q=0; 2>q; q++)
                        {
                            okuDevre2>>kelime2;
                            kapi[indis].girisler[q].giris=kucult(kelime2);
                            g[i].giris=kapi[indis].girisler[q].giris;
                            i++;
                        }
                        okuDevre2>>kapi[indis].gecikme;
                        indis++;
                        okuDevre2>>kelime2;
                        kelime2=kucult(kelime2);
                        if(kelime[0]=='#')
                        {
                            while(kelime2!=".kapi")
                            {
                                okuDevre2>>kelime2;
                                if(kelime2==".son")
                                    goto Devam1;
                            }
                        }
                        else if(kelime2==".son")
                            goto Devam2;
                    }
                }
                if(kelime2==".kapi")
                {
                    goto Don2;
                }
Devam2:
                okuDevre2.close();
            }

            if(kelime==".giris")
            {
                okuDevre1>>kelime;
                kelime=kucult(kelime);

                while(kelime!=".cikis")
                {
                    if(kelime[0]=='#')
                    {
                        break;
                    }
                    g[i].giris=kucult(kelime);
                    i++;
                    okuDevre1>>kelime;
                }
            }

            while(kelime!=".cikis")
            {
                okuDevre1>>kelime;
            }

            okuDevre1>>cikisAd;
            g[i].giris=kucult(cikisAd);
            i++;
            okuDevre1>>kelime;

            if(kelime[0]=='#')
            {
                while(kelime!=".kapi")
                {
                    okuDevre1>>kelime;
                }
            }

Don:
            if(kelime==".kapi")
            {
                okuDevre1>>kelime;
                kapi[indis].tur=kelime;
                while(kelime!=".kapi")
                {
                    okuDevre1>>kapi[indis].girisSayisi;
                    okuDevre1>>kelime;
                    kapi[indis].cikislar.cikis=kucult(kelime);
                    for(int q=0; kapi[indis].girisSayisi>q; q++)
                    {
                        okuDevre1>>kelime;
                        kapi[indis].girisler[q].giris=kucult(kelime);
                        g[i].giris=kapi[indis].girisler[q].giris;
                        i++;
                    }
                    okuDevre1>>kapi[indis].gecikme;
                    indis++;
                    okuDevre1>>kelime;
                    if(kelime[0]=='#')
                    {
                        while(kelime!=".kapi")
                        {
                            okuDevre1>>kelime;
                            if(kelime==".son")
                                goto Devam1;
                        }
                    }
                    else if(kelime==".son")
                        goto Devam1;
                }
            }
            if(kelime==".kapi")
            {
                goto Don;
            }
Devam1:
            okuDevre1.close();
            cout<<"Y calisti"<<endl;

        }

        else if(dKomutu=="I")
        {
            cout<<"ilklendirildi"<<endl;
            ifstream okuDeger("deger.txt");
            yazLog<<"ilklendirildi"<<endl;

            while(!okuDeger.eof())
            {
                okuDeger>>kelime;
                kelime=kucult(kelime);
                okuDeger>>sayi;
                for(int s=0; s<indis; s++)      //Kapylaryn içine giri? çyky? atama
                {
                    if(kapi[s].cikislar.cikis==kelime)
                    {
                        kapi[s].cikislar.deger=sayi;
                    }
                    for(int w=0; w<kapi[s].girisSayisi; w++)
                    {
                        if(kapi[s].girisler[w].giris==kelime)
                        {
                            kapi[s].girisler[w].deger=sayi;
                        }
                    }
                }

                for(int j=0; i>j; j++)      //giri? çyky?a de?erlerin atanmasy
                {
                    if(g[j].giris==kelime)
                    {
                        g[j].deger=sayi;
                    }
                }
            }
            okuDeger.close();

            //Küçükten büyü?e syralama
            Girisler degistir;
            degistir.giris="zzzz";
            for(int j=0; i>j+1; j++)
            {
                for(int d=j; d<i; d++)
                {
                    if(g[j].giris>g[d].giris)
                    {
                        swap(g[j],g[d]);
                    }

                }

                for(int d=j+1; d<i; d++)    //aynylarsa sona atyyor
                {
                    if(g[j].giris==g[d].giris)
                    {
                        g[d]=degistir;
                    }
                }
            }

            int sayac=0;
            for(int j=0; i>j; j++)
            {
                if(g[j].giris=="zzzz")
                    sayac++;
            }
            i-=sayac;

            for(int j=0; i>j; j++)      //kopyalama
            {
                gKopya[j].giris=g[j].giris;
                gKopya[j].deger=g[j].deger;
                cout<<g[j].giris<<": "<<g[j].deger<<endl;
            }

//kapylaryn küçükten büyü?e syralanmalary

            for(int j=0; j<indis; j++)
            {
                for(int d=j; d<indis; d++)
                {
                    if(kapi[j].gecikme>kapi[d].gecikme)
                    {
                        swap(kapi[j],kapi[d]);
                    }

                }
            }

        }

        else if(dKomutu=="H")
        {
            cout<<"yukseltme calisti"<<endl;
oku1:
            dKomutOku>>dKomutu;
            if(dKomutu=="Y" || dKomutu=="I" || dKomutu=="H" || dKomutu=="L" || dKomutu=="S" || dKomutu=="G" || dKomutu=="G*" || dKomutu=="K" || dKomutu=="C")
            {
                yazLog<<"yukseltildi"<<endl;
                goto komutKarsilastir;

            }
            else
            {
                yazLog<<dKomutu<<" ";
                for(int j=0; j<i; j++)
                {
                    if(dKomutu==g[j].giris)
                        g[j].deger=1;
                }
                goto oku1;
            }

        }

        else if(dKomutu=="L")
        {
            cout<<"dusurme calisti"<<endl;

oku2:
            dKomutOku>>dKomutu;
            if(dKomutu=="Y" || dKomutu=="I" || dKomutu=="H" || dKomutu=="L" || dKomutu=="S" || dKomutu=="G" || dKomutu=="G*" || dKomutu=="K" || dKomutu=="C")
            {
                yazLog<<"dusuruldu"<<endl;
                goto komutKarsilastir;

            }
            else
            {
                yazLog<<dKomutu<<" ";
                for(int j=0; j<i; j++)
                {
                    if(dKomutu==g[j].giris)
                        g[j].deger=0;
                }

                goto oku2;
            }

        }

        else if(dKomutu=="G*")
        {
            yazLog<<"listelendi"<<endl;
            cout<<"listele calisti"<<endl;
            for(int j=0; i>j; j++)
            {
                yazLog<<"   "<<g[j].giris<<": "<<g[j].deger<<endl;
                cout<<g[j].giris<<": "<<g[j].deger<<endl;
            }
        }

        else if(dKomutu=="G")
        {
            cout<<"Belli yerleri listele calisti"<<endl;
oku3:
            dKomutOku>>dKomutu;
            if(dKomutu=="Y" || dKomutu=="I" || dKomutu=="H" || dKomutu=="L" || dKomutu=="S" || dKomutu=="G" || dKomutu=="G*" || dKomutu=="K" || dKomutu=="C")
            {
                yazLog<<"listelendi"<<endl;
                goto komutKarsilastir;

            }
            else
            {
                yazLog<<dKomutu<<" ";
                for(int j=0; j<i; j++)
                {
                    if(dKomutu==g[j].giris)
                    {
                        yazLog<<"  "<<g[j].giris<<": "<<g[j].deger<<endl;
                        cout<<g[j].giris<<": "<<g[j].deger<<endl;
                    }

                }

                goto oku3;
            }

        }

        else if(dKomutu=="S")
        {
            cout<<"simule et calisti"<<endl;
            yazLog<<"simule edildi"<<endl;
            simuleEt();
        }

        if(dKomutu=="C")
        {
            cout<<"cikis yaptik ama cikis yapmayi burada basaramadim"<<endl;
        }
    }
}
