import java.awt.Color;
import java.awt.Graphics;
import java.util.Locale;
import java.util.Scanner;
import javax.swing.JFrame;

public class Main {
	
	public static void main(String[] args){
		
		Scanner scanner = new Scanner(System.in);
		scanner.useLocale(Locale.US);
		
		int[][] matris={{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
						{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};

		System.out.println("Olu�turmak istedi�iniz robot s�n�f�n� se�iniz: ");
		System.out.println("1: Gezgin Robot\n2: Manipulat�r Robot\n3: Hibrit Robot");
		System.out.print("Ana Secim: ");
		int anaSecim = scanner.nextInt();
		while(anaSecim>3 || anaSecim<1)
		{
			System.out.print("Yanl�� se�im, l�tfen tekrar giriniz: ");
			anaSecim = scanner.nextInt();
		}

		if(anaSecim==1)
		{
			int robotSayisi;
			System.out.print("Ka� tane robot olu�turacaks�n�z: ");
			robotSayisi = scanner.nextInt();

			GezginRobot[] robotlar = new GezginRobot[robotSayisi];
			String robot_tipi;
			for (int i = 0; i < robotlar.length; i++) 
			{
				System.out.println("1: Tekerlekli gezgin robot\n2: Paletli gezgin robot\n3: Spider gezgin robot");
				System.out.print("Secim: ");
				int turSecim = scanner.nextInt();
				while(turSecim>3 || turSecim<1)
				{
					System.out.print("Yanl�� se�im, l�tfen tekrar giriniz: ");
					turSecim = scanner.nextInt();
				}
				if(turSecim==1)
				{
					//Tekerlekli
					robotlar[i] = new GezginTekerlekli();
					System.out.println("\nTekerlekli gezgin robot i�in bilgileri giriniz;");
					System.out.print("Motor say�s�: ");
					int motor_sayisi = scanner.nextInt();
					int dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("paletli")) 
								{
									if (((GezginPaletli)robotlar[j]).EngelGecmeSuresiBul() <= motor_sayisi*0.5) {
										System.out.print("Tekerlekli robotlar engeli en h�zl� ge�en robotlard�r!\n"
												+ "Motor say�s�n� tekrar giriniz: ");
										motor_sayisi = scanner.nextInt();
									}
								}
								
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("paletli")) 
								{
									if (((GezginPaletli)robotlar[j]).EngelGecmeSuresiBul() <= motor_sayisi*0.5) {
										dogru++;
									}
								}
							}
						}
					}
					robotlar[i].setMotorSayisi(motor_sayisi);
					
					System.out.print("Ta��yaca�� y�k miktar�: ");
					float yuk_miktari = scanner.nextFloat();
					robotlar[i].setTasiyacagiYukMiktari(yuk_miktari);
					
					robot_tipi = "tekerlekli";
					robotlar[i].setRobotTipi(robot_tipi);
					
					System.out.print("Gezinme h�z�n� giriniz: ");
					float gezinme_hizi = scanner.nextFloat();
					dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("paletli") || (robotlar[j].getRobotTipi()).contains("spider")) 
								{
									if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
										System.out.print("Tekerlekli robotlar en h�zl� robotlard�r!\n"
												+ "Gezinme h�z�n� tekrar giriniz: ");
										gezinme_hizi = scanner.nextFloat();
									}
								}
								
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("paletli") || (robotlar[j].getRobotTipi()).contains("spider")) 
								{
									if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
										dogru++;
									}
								}
							}
						}
					}
					robotlar[i].setGezinmeHizi(gezinme_hizi);
					
					System.out.print("Tekerlek say�s�n� giriniz: ");
					int tekerlek_sayisi = scanner.nextInt();
					((GezginTekerlekli) robotlar[i]).setTekerlekSayisi(tekerlek_sayisi);
					System.out.println(" ");
								
				}
				else if(turSecim==2)
				{
					//Gezgin Paletli
					robotlar[i] = new GezginPaletli();
					System.out.println("\nPaletli gezgin robot i�in bilgileri giriniz;");
					System.out.print("Motor sayisi: ");
					int motor_sayisi = scanner.nextInt();
					int dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("tekerlekli")) 
								{
									if (((GezginTekerlekli)robotlar[j]).EngelGecmeSuresi() >= motor_sayisi*3) {
										System.out.print("Paletli robotlar tekerlekli robotlardan daha h�zl� engel ge�emezler!\n"
												+ "Motor say�s�n� tekrar giriniz: ");
										motor_sayisi = scanner.nextInt();
									}
								}
								
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("tekerlekli")) 
								{
									if (((GezginTekerlekli)robotlar[j]).EngelGecmeSuresi() >= motor_sayisi*3) {
										dogru++;
									}
								}
							}
						}
					}
					robotlar[i].setMotorSayisi(motor_sayisi);
					
					System.out.print("Ta��yaca�� y�k miktar�: ");
					float yuk_miktari = scanner.nextFloat();
					robotlar[i].setTasiyacagiYukMiktari(yuk_miktari);
					
					robot_tipi = "paletli";
					robotlar[i].setRobotTipi(robot_tipi);
					
					System.out.print("Gezinme h�z�n� giriniz: ");
					float gezinme_hizi = scanner.nextFloat();
					dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("spider")) {
									if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
										System.out.print("Paletli robotlar spider robotlardan daha h�zl�d�r!\n"
												+ "Gezinme h�z�n� tekrar giriniz: ");
										gezinme_hizi = scanner.nextFloat();
									}
								}
								else if ((robotlar[j].getRobotTipi()).contains("tekerlekli")) 
								{
									if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) {
										System.out.print("Paletli robotlar tekerlekli robotlardan daha h�zl� olamaz!\n"
												+ "Gezinme h�z�n� tekrar giriniz: ");
										gezinme_hizi = scanner.nextFloat();
									}
								}

							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) 
							{

								if ((robotlar[j].getRobotTipi()).contains("spider")) {
									if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
										dogru++;
									}
								}
								else if ((robotlar[j].getRobotTipi()).contains("tekerlekli")) 
								{
									if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) {
										dogru++;
									}
								}

							}
						}
					}
					robotlar[i].setGezinmeHizi(gezinme_hizi);
									
					System.out.print("Palet say�s�n� giriniz: ");
					int palet_sayisi = scanner.nextInt();
					((GezginPaletli)robotlar[i]).setPaletSayisi(palet_sayisi);
					System.out.println(" ");

				}
				else
				{
					//Gezgin spider
					robotlar[i] = new GezginSpider();
					System.out.println("\nSpider gezgin robot i�in bilgileri giriniz;");
					System.out.print("Motor say�s�: ");
					int motor_sayisi = scanner.nextInt();
					robotlar[i].setMotorSayisi(motor_sayisi);
					
					System.out.print("Ta��yaca�� y�k miktar�: ");
					float yuk_miktari = scanner.nextFloat();
					robotlar[i].setTasiyacagiYukMiktari(yuk_miktari);
					
					robot_tipi = "spider";
					robotlar[i].setRobotTipi(robot_tipi);
					
					System.out.print("Gezinme h�z�n� giriniz: ");
					float gezinme_hizi = scanner.nextFloat();
					int dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("tekerlekli") 
										|| (robotlar[j].getRobotTipi()).contains("paletli")) 
								{
									if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) {
										System.out.print("Spider robotlar di�er robotlardan daha h�zl� olamazlar!\n"
												+ "Gezinme h�z�n� tekrar giriniz: ");
										gezinme_hizi = scanner.nextFloat();
									}
								}
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) {
								
								if ((robotlar[j].getRobotTipi()).contains("tekerlekli") 
										|| (robotlar[j].getRobotTipi()).contains("paletli")) 
								{
									if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) 
									{
										dogru++;
									}
								}
							}
						}
					}
					robotlar[i].setGezinmeHizi(gezinme_hizi);
					
					System.out.print("Bacak say�s�n� giriniz: ");
					int bacak_sayisi = scanner.nextInt();
					((GezginSpider)robotlar[i]).setBacakSayisi(bacak_sayisi);
					System.out.println(" ");
				}
			}
			int kullanilacak=0;
			if(robotSayisi!=1)
			{
				System.out.print("Hangi s�radaki robotu kullanacaks�n�z?...: ");
				kullanilacak = scanner.nextInt();
				kullanilacak -= 1;
			}
			int[] hesaplama = new int[4];
			float sonuc;
			if(robotlar[kullanilacak].getRobotTipi().contains("tekerlekli"))
			{
				hesaplama = engelveRobotYerlestir(robotlar[kullanilacak], matris);
				sonuc=((((GezginTekerlekli)robotlar[kullanilacak]).EngelGecmeSuresi())*hesaplama[0]+robotlar[kullanilacak].getGezinmeHizi()*hesaplama[1]*10);
				System.out.println("Toplam ge�en s�re " + sonuc + " saniye");
			}
			else if(robotlar[kullanilacak].getRobotTipi().contains("paletli"))
			{
				hesaplama = engelveRobotYerlestir(robotlar[kullanilacak], matris);
				sonuc=((((GezginPaletli)robotlar[kullanilacak]).EngelGecmeSuresiBul())*hesaplama[0]+robotlar[kullanilacak].getGezinmeHizi()*hesaplama[1]*10);
				System.out.println("Toplam ge�en s�re " + sonuc + " saniye");
			}
			else
			{
				hesaplama = engelveRobotYerlestir(robotlar[kullanilacak], matris);
				sonuc = (robotlar[kullanilacak].getGezinmeHizi()*hesaplama[1]*10);
				System.out.println("Toplam ge�en s�re " + sonuc + " saniye");
			}
		}
		
		//Manip�lat�r robotlar
		else if(anaSecim==2)
		{
			int robotSayisi;
			System.out.print("Ka� tane robot olu�turacaks�n�z: ");
			robotSayisi = scanner.nextInt();

			ManipulatorRobot[] robotlar = new ManipulatorRobot[robotSayisi];
			String robot_tipi;
			for (int i = 0; i < robotlar.length; i++) 
			{
				System.out.println("1: Paralel manip�lat�r robot\n2: Seri manip�lat�r robot");
				System.out.print("Secim: ");
				int turSecim = scanner.nextInt();
				while(turSecim>2 || turSecim<1)
				{
					System.out.print("Yanl�� se�im, l�tfen tekrar giriniz: ");
					turSecim = scanner.nextInt();
				}
				
				if(turSecim==1)
				{
					//Paralel
					robotlar[i] = new ManipulatorParalel();
					System.out.println("\nParalel manip�lat�r robot i�in bilgileri giriniz;");
					System.out.print("Motor sayisi: ");
					int motor_sayisi = scanner.nextInt();
					robotlar[i].setMotorSayisi(motor_sayisi);
					
					robot_tipi = "paralel";
					robotlar[i].setRobotTipi(robot_tipi);
					
					System.out.print("Y�k ta��ma kapasitesi: ");
					float yuk_tasima = scanner.nextFloat();
					int dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) {
								if ((robotlar[j].getRobotTipi()).contains("seri")) 
								{
									if (robotlar[j].getYukTasimaKapasitesi() >= yuk_tasima) 
									{
										System.out.print("Paletli robotlar en a��r y�k ta��yan robotlard�r!\n"
												+ "Y�k ta��ma kapasitesini giriniz: ");
										yuk_tasima = scanner.nextFloat();
									}
								} 
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) {
								if ((robotlar[j].getRobotTipi()).contains("seri")) 
								{
									if (robotlar[j].getYukTasimaKapasitesi() >= yuk_tasima) 
									{
										dogru++;
									}
								} 
							}
						}
					}
					robotlar[i].setYukTasimaKapasitesi(yuk_tasima);

					System.out.print("Kol uzunlu�u: ");
					float kol_uzunlugu = scanner.nextInt();
					robotlar[i].setKolUzunlugu(kol_uzunlugu);
					
					System.out.print("Ta��ma h�z�n� giriniz: ");
					float tasima_hizi = scanner.nextFloat();
					dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("seri")) 
								{
									if (robotlar[j].getTasimaHizi() >= tasima_hizi) 
									{
										System.out.print("Paralel robotlar seri robotlardan h�zl� y�k ta��yamazlar!\n"
												+ "Y�k ta��ma h�z�n� giriniz: ");
										tasima_hizi = scanner.nextFloat();
									}
								} 
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("seri")) 
								{
									if (robotlar[j].getTasimaHizi() >= tasima_hizi) 
									{
										dogru++;
									}
								} 
							}
						}
					}
					robotlar[i].setTasimaHizi(tasima_hizi);
				}
				else
				{
					//seri
					robotlar[i] = new ManipulatorSeri();
					System.out.println("\nSeri manip�lat�r robot i�in bilgileri giriniz;");
					System.out.print("Motor sayisi: ");
					int motor_sayisi = scanner.nextInt();
					robotlar[i].setMotorSayisi(motor_sayisi);
					
					robot_tipi = "seri";
					robotlar[i].setRobotTipi(robot_tipi);
					
					System.out.print("Y�k ta��ma kapasitesi: ");
					float yuk_tasima = scanner.nextFloat();
					int dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) {
								if ((robotlar[j].getRobotTipi()).contains("paralel")) 
								{
									if (robotlar[j].getYukTasimaKapasitesi() <= yuk_tasima) 
									{
										System.out.print("Seri robotlar paralel robotlardan a��r y�k ta��yamazlar!\n"
												+ "Y�k ta��ma kapasitesini giriniz: ");
										yuk_tasima = scanner.nextFloat();
									}
								}
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) {
								if ((robotlar[j].getRobotTipi()).contains("paralel")) 
								{
									if (robotlar[j].getYukTasimaKapasitesi() <= yuk_tasima) 
									{
										dogru++;
									}
								}
							}
						}
					}
					robotlar[i].setYukTasimaKapasitesi(yuk_tasima);
					
					System.out.print("Kol uzunlu�u: ");
					float kol_uzunlugu = scanner.nextInt();
					robotlar[i].setKolUzunlugu(kol_uzunlugu);
					
					System.out.print("Ta��ma h�z�n� giriniz: ");
					float tasima_hizi = scanner.nextFloat();
					dogru = 1;
					if (i != 0) {
						while (dogru != 0) {
							dogru = 0;
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("paralel")) 
								{
									if (robotlar[j].getTasimaHizi() <= tasima_hizi) 
									{
										System.out.print("Seri robotlar paralel robotlardan yava� y�k ta��yamazlar!\n"
												+ "Y�k ta��ma h�z�n� giriniz: ");
										tasima_hizi = scanner.nextFloat();
									}
								}
							}
							// do�ruluk
							for (int j = i - 1; j >= 0; j--) 
							{
								if ((robotlar[j].getRobotTipi()).contains("paralel")) 
								{
									if (robotlar[j].getTasimaHizi() <= tasima_hizi) 
									{
										dogru++;
									}
								}
							}
						}
					}
					robotlar[i].setTasimaHizi(tasima_hizi);
				}
			}
			int kullanilacak=0;
			if(robotSayisi!=1)
			{
				System.out.print("Hangi s�radaki robotu kullanacaks�n�z?...: ");
				kullanilacak = scanner.nextInt();
				kullanilacak -= 1;
			}
			float hesaplama, sonuc=0;
			if(robotlar[kullanilacak].getRobotTipi().contains("paralel"))
			{
				hesaplama = manipulatorYerlestir(robotlar[kullanilacak], matris);
				sonuc = (robotlar[kullanilacak].getTasimaHizi()*10*hesaplama);
				System.out.println("Toplam ge�en s�re " + sonuc + " saniye");
			}
			else if(robotlar[kullanilacak].getRobotTipi().contains("seri"))
			{
				hesaplama = manipulatorYerlestir(robotlar[kullanilacak], matris);
				sonuc = (robotlar[kullanilacak].getTasimaHizi()*10*hesaplama);
				System.out.println("Toplam ge�en s�re " + sonuc + " saniye");
			}
		
		}
		
		if(anaSecim==3)
		{
			int robotSayisi;
			System.out.print("Ka� tane robot olu�turacaks�n�z: ");
			robotSayisi = scanner.nextInt();

			HibritRobot[] robotlar = new HibritRobot[robotSayisi];
			String robot_tipi;
			for (int i = 0; i < robotlar.length; i++) {
				System.out.println("1: Tekerlekli-Seri\n2: Tekerlekli-Paralel\n3: Paletli-Seri");
				System.out.println("4: Paletli-Paralel\n5: Spider-Seri\n6: Spider-Paralel");
				System.out.print("Secim: ");
				int turSecim = scanner.nextInt();
				while(turSecim<1 || turSecim>6)
				{
					System.out.print("Yanl�� se�im, l�tfen tekrar giriniz: ");
					turSecim = scanner.nextInt();
				}
				robotlar[i] = new HibritRobot();

				if (turSecim == 1)
				{
					System.out.println("\nTekerli-Seri robot i�in bilgileri giriniz;");
					robot_tipi = "tekerlekli-seri";
				}	
				else if (turSecim == 2)
				{
					System.out.println("\nTekerli-Paralel robot i�in bilgileri giriniz;");
					robot_tipi = "tekerlekli-paralel";
				}	
				else if (turSecim == 3)
				{
					System.out.println("\nPaletli-Seri robot i�in bilgileri giriniz;");
					robot_tipi = "paletli-seri";
				}
				else if (turSecim == 4)
				{
					System.out.println("\nPaletli-Paralel robot i�in bilgileri giriniz;");
					robot_tipi = "paletli-paralel";
				}	
				else if (turSecim == 5)
				{
					System.out.println("\nSpider-Seri robot i�in bilgileri giriniz;");
					robot_tipi = "spider-seri";
				}	
				else
				{
					System.out.println("\nSpider-Paralel robot i�in bilgileri giriniz;");
					robot_tipi = "spider-paralel";
				}
					
				robotlar[i].setRobotTipi(robot_tipi);
				
				System.out.print("Motor say�s�: ");
				int motor_sayisi = scanner.nextInt();
				int dogru = 1;
				if (i != 0) {
					while (dogru != 0) {
						dogru = 0;
						for (int j = i - 1; j >= 0; j--) 
						{
							if ((robotlar[j].getRobotTipi()).contains("paletli") && robotlar[i].getRobotTipi().contains("tekerlekli")) 
							{
								if (robotlar[j].EngelGecmeSuresiBul() <= motor_sayisi*0.5) {
									System.out.print("Tekerlekli robotlar engeli en h�zl� ge�en robotlard�r!\n"
											+ "Motor say�s�n� tekrar giriniz: ");
									motor_sayisi = scanner.nextInt();
								}
							}
							if((robotlar[j].getRobotTipi()).contains("tekerlekli") && robotlar[i].getRobotTipi().contains("paletli"))
							{
								if (robotlar[j].EngelGecmeSuresiBul() >= motor_sayisi*3) {
									System.out.print("Paletli robotlar engeli tekerlekli robotlardan daha h�zl� ge�emezler!\n"
											+ "Motor say�s�n� tekrar giriniz: ");
									motor_sayisi = scanner.nextInt();
								}
							}
							
						}
						// do�ruluk
						for (int j = i - 1; j >= 0; j--) 
						{
							if ((robotlar[j].getRobotTipi()).contains("paletli")) 
							{
								if (robotlar[j].EngelGecmeSuresiBul() <= motor_sayisi*0.5) {
									dogru++;
								}
							}
							if((robotlar[j].getRobotTipi()).contains("tekerlekli") && robotlar[i].getRobotTipi().contains("paletli"))
							{
								if (robotlar[j].EngelGecmeSuresiBul() >= motor_sayisi*3) {
									System.out.print("Paletli robotlar engeli tekerlekli robotlardan daha h�zl� ge�emezler!\n"
											+ "Motor say�s�n� tekrar giriniz: ");
									dogru++;
								}
							}
						}
					}
				}
				robotlar[i].setMotorSayisi(motor_sayisi);

				System.out.print("Gezinme h�z�n� giriniz: ");
				float gezinme_hizi = scanner.nextFloat();
				dogru = 1;
				if (i != 0) {
					while (dogru != 0) {
						dogru = 0;
						for (int j = i - 1; j >= 0; j--) {
							if (robot_tipi.contains("tekerlekli") && ((robotlar[j].getRobotTipi()).contains("paletli") 
									|| (robotlar[j].getRobotTipi()).contains("spider"))) {
								if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
									System.out.print("Tekerlekli robotlar en h�zl� robotlard�r!\n"
											+ "Gezinme h�z�n� tekrar giriniz: ");
									gezinme_hizi = scanner.nextFloat();
								}
							}
							if ((robot_tipi.contains("paletli")) && (robotlar[j].getRobotTipi()).contains("spider")) {
								if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
									System.out.print("Paletli robotlar spider robotlardan daha h�zl�d�r!\n"
											+ "Gezinme h�z�n� tekrar giriniz: ");
									gezinme_hizi = scanner.nextFloat();
								}
							}
							if ((robot_tipi.contains("paletli")) && (robotlar[j].getRobotTipi()).contains("tekerlekli")) 
							{
								if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) {
									System.out.print("Paletli robotlar tekerlekli robotlardan daha h�zl� olamaz!\n"
											+ "Gezinme h�z�n� tekrar giriniz: ");
									gezinme_hizi = scanner.nextFloat();
								}
							}
							if ((robot_tipi.contains("spider")) && ((robotlar[j].getRobotTipi()).contains("tekerlekli") 
									|| (robotlar[j].getRobotTipi()).contains("paletli"))) 
							{
								if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) {
									System.out.print("Spider robotlar di�er robotlardan daha h�zl� olamazlar!\n"
											+ "Gezinme h�z�n� tekrar giriniz: ");
									gezinme_hizi = scanner.nextFloat();
								}
							}
						}
						// do�ruluk
						for (int j = i - 1; j >= 0; j--) {
							if (robot_tipi.contains("tekerlekli") && ((robotlar[j].getRobotTipi()).contains("paletli") 
									|| (robotlar[j].getRobotTipi()).contains("spider"))) {
								if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
									dogru++;
								}
							}
							if ((robot_tipi.contains("paletli")) && (robotlar[j].getRobotTipi()).contains("spider")) {
								if (robotlar[j].getGezinmeHizi() <= gezinme_hizi) {
									dogru++;
								}
							}
							if ((robot_tipi.contains("paletli")) && (robotlar[j].getRobotTipi()).contains("tekerlekli")) 
							{
								if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) {
									dogru++;
								}
							}
							if ((robot_tipi.contains("spider")) && ((robotlar[j].getRobotTipi()).contains("tekerlekli") 
									|| (robotlar[j].getRobotTipi()).contains("paletli"))) 
							{
								if (robotlar[j].getGezinmeHizi() >= gezinme_hizi) 
								{
									dogru++;
								}
							}
						}
					}
				}
				robotlar[i].setGezinmeHizi(gezinme_hizi);

				// paralel seriden a��r olamaz
				System.out.print("Y�k ta��ma kapasitesini giriniz: ");
				float yuk_tasima_kapasitesi = scanner.nextFloat();
				dogru = 1;
				if (i != 0) {
					while (dogru != 0) {
						dogru = 0;
						for (int j = i - 1; j >= 0; j--) {
							if (robot_tipi.contains("paralel") && ((robotlar[j].getRobotTipi()).contains("seri"))) 
							{
								if (robotlar[j].getYukTasimaKapasitesi() >= yuk_tasima_kapasitesi) 
								{
									System.out.print("Paletli robotlar en a��r y�k ta��yan robotlard�r!\n"
											+ "Y�k ta��ma kapasitesini giriniz: ");
									yuk_tasima_kapasitesi = scanner.nextFloat();
								}
							} 
							else if (robot_tipi.contains("seri") && ((robotlar[j].getRobotTipi()).contains("paralel")))  
							{
								if (robotlar[j].getYukTasimaKapasitesi() <= yuk_tasima_kapasitesi) 
								{
									System.out.print("Seri robotlar paralel robotlardan a��r y�k ta��yamazlar!\n"
											+ "Y�k ta��ma kapasitesini giriniz: ");
									yuk_tasima_kapasitesi = scanner.nextFloat();
								}
							}
						}
						// do�ruluk
						for (int j = i - 1; j >= 0; j--) {
							if (robot_tipi.contains("paralel") && ((robotlar[j].getRobotTipi()).contains("seri"))) 
							{
								if (robotlar[j].getYukTasimaKapasitesi() >= yuk_tasima_kapasitesi) 
								{
									dogru++;
								}
							} 
							else if (robot_tipi.contains("seri") && ((robotlar[j].getRobotTipi()).contains("paralel")))   
							{
								if (robotlar[j].getYukTasimaKapasitesi() <= yuk_tasima_kapasitesi) 
								{
									dogru++;
								}
							}
						}
					}
				}
				robotlar[i].setYukTasimaKapasitesi(yuk_tasima_kapasitesi);

				// Seri robotlar en h�zl� y�k ta��yan robotlard�r.
				System.out.print("Y�k ta��ma h�z�n� giriniz: ");
				float yuk_tasima_hizi = scanner.nextFloat();
				dogru = 1;
				if (i != 0) {
					while (dogru != 0) {
						dogru = 0;
						for (int j = i - 1; j >= 0; j--) 
						{
							if (robot_tipi.contains("paralel") && ((robotlar[j].getRobotTipi()).contains("seri"))) 
							{
								if (robotlar[j].getTasimaHizi() >= yuk_tasima_hizi) 
								{
									System.out.print("Paralel robotlar seri robotlardan h�zl� y�k ta��yamazlar!\n"
											+ "Y�k ta��ma h�z�n� giriniz: ");
									yuk_tasima_hizi = scanner.nextFloat();
								}
							} 
							else if (robot_tipi.contains("seri") && ((robotlar[j].getRobotTipi()).contains("paralel")))  
							{
								if (robotlar[j].getTasimaHizi() <= yuk_tasima_hizi) 
								{
									System.out.print("Seri robotlar paralel robotlardan yava� y�k ta��yamazlar!\n"
											+ "Y�k ta��ma h�z�n� giriniz: ");
									yuk_tasima_hizi = scanner.nextFloat();
								}
							}
						}
						// do�ruluk
						for (int j = i - 1; j >= 0; j--) 
						{
							if (robot_tipi.contains("paralel") && ((robotlar[j].getRobotTipi()).contains("seri"))) 
							{
								if (robotlar[j].getTasimaHizi() >= yuk_tasima_hizi) 
								{
									dogru++;
								}
							} 
							else if (robot_tipi.contains("seri") && ((robotlar[j].getRobotTipi()).contains("paralel")))  
							{
								if (robotlar[j].getTasimaHizi() <= yuk_tasima_hizi) 
								{
									dogru++;
								}
							}
						}
					}
				}
				robotlar[i].setTasimaHizi(yuk_tasima_hizi);

				if ((robotlar[i].getRobotTipi()).contains("tekerlekli"))
					System.out.print("Tekerlek say�s�n� giriniz: ");
				else if ((robotlar[i].getRobotTipi()).contains("paletli"))
					System.out.print("Palet say�s�n� giriniz: ");
				else
					System.out.print("Bacak say�s�n� giriniz: ");
				int uzuv_sayisi = scanner.nextInt();
				robotlar[i].setUzuvSayisi(uzuv_sayisi);

				System.out.print("Kol uzunlu�unu giriniz: ");
				float kol_uzunlugu = scanner.nextFloat();
				robotlar[i].setKolUzunlugu(kol_uzunlugu);

				System.out.print("Sabitlenme s�resini giriniz: ");
				float sabitlenme = scanner.nextFloat();
				robotlar[i].setSabitlenmeSuresi(sabitlenme);

				System.out.print("Y�k ge�i� s�resini giriniz: ");
				float gecis = scanner.nextFloat();
				robotlar[i].setYukGecisSuresi(gecis);

				System.out.print("Ta��yaca�� y�k miktar�n� giriniz: ");
				float tasiyacagi_yuk = scanner.nextFloat();
				while (tasiyacagi_yuk > robotlar[i].getYukTasimaKapasitesi()) 
				{
					System.out
							.println("Ta��yaca�� y�k miktar� ta��ma kapasitesini ge�emez!");
					System.out.println("Ta��ma miktar� maks: "
							+ robotlar[i].getYukTasimaKapasitesi());
					System.out.print("Ta��yaca�� y�k miktar�n� giriniz: ");
					tasiyacagi_yuk = scanner.nextFloat();
				}
				robotlar[i].setTasiyacagiYukMiktari(tasiyacagi_yuk);
			}

			/*for (int k = 0; k < robotlar.length; k++) {
				System.out.println(robotlar[k].getMotorSayisi()
						+ "Ta��yaca�� y�k: "
						+ robotlar[k].getTasiyacagiYukMiktari()
						+ "robot tipi: " + robotlar[k].getRobotTipi()
						+ "Gezinme H�z�: " + robotlar[k].getGezinmeHizi()
						+ "ta��ma kapasitesi: "
						+ robotlar[k].getYukTasimaKapasitesi()
						+ "Ta��ma h�z�: " + robotlar[k].getTasimaHizi()
						+ "Kol uzunlu�u: " + robotlar[k].getKolUzunlugu()
						+ " Sabitlenme: " + robotlar[k].getSabitlenmeSuresi()
						+ " Yuk geci�: " + robotlar[k].getYukGecisSuresi()
						+ "\nEngelden ge�me: "
						+ robotlar[k].EngelGecmeSuresiBul());
			}*/
			int kullanilacak=0;
			if(robotSayisi!=1)
			{
				System.out.print("Hangi s�radaki robotu kullanacaks�n�z?...: ");
				kullanilacak = scanner.nextInt();
				kullanilacak -= 1;
			}

			hibritHarita(robotlar[kullanilacak],matris);

		}
	}
	
	public static int[] engelveRobotYerlestir(Robot robot, int[][] yol){
		
		Scanner scanner = new Scanner(System.in);
		scanner.useLocale(Locale.US);
		int[] donecek = new int[4];//0.engel sayisi
		
		System.out.print("Ka� tane engel koyacaks�n�z: ");
		int engelSayisi = scanner.nextInt();
		while(engelSayisi!=0)
		{
			int[] xdizi=new int[engelSayisi];
			int[] ydizi=new int[engelSayisi];
			Izgaralar �zgara=new Izgaralar(xdizi,ydizi);
			�zgara.setSize(800, 800);
			�zgara.setVisible(true);
				
			String engelKoordinat;
			for(int i=0; i<engelSayisi; i++)
			{
				System.out.print(i+1 + ". (x,y): ");
				if(i==0){
					engelKoordinat = scanner.nextLine();
					engelKoordinat = scanner.nextLine();
				}
				else
					engelKoordinat = scanner.nextLine();
				
	        	int virgulKonumu=0;
	        	for(int j=0;j<engelKoordinat.length();j++){
	        		String harf=engelKoordinat.substring(j, j+1);
	           
	        		if(harf.equals(",")){
	        			virgulKonumu=j;
	        		}
	        	}

	        	String engelxKoordinat = (engelKoordinat.substring(0,virgulKonumu)).toString();
	        	xdizi[i]=Integer.parseInt(engelxKoordinat);

	        	String engelyKoordinat=(engelKoordinat.substring(virgulKonumu+1, engelKoordinat.length())).toString();
	        	ydizi[i]=Integer.parseInt(engelyKoordinat);
	        	�zgara.repaint();
				
				while((xdizi[i]>20 || ydizi[i]>20) || (xdizi[i]<1 || ydizi[i]<1)){
						System.out.println("Hatal� de�er veya de�erler girdiniz.\n"
								+ "Girdi�iniz de�erler 20'den b�y�k, 1'den k���k olamaz\n"
								+ "Tekrar giriniz...");
						System.out.print(i+1 + "(x,y): ");
						engelKoordinat = scanner.nextLine();
			        	virgulKonumu=0;
			        	for(int k=0; k<engelKoordinat.length(); k++){
			        		String harf=engelKoordinat.substring(k, k+1);
			           
			        		if(harf.equals(",")){
			        			virgulKonumu=k;
			        		}
			        	}
			        	engelxKoordinat = (engelKoordinat.substring(0,virgulKonumu)).toString();
			        	xdizi[i]=Integer.parseInt(engelxKoordinat);

			        	engelyKoordinat=(engelKoordinat.substring(virgulKonumu+1, engelKoordinat.length())).toString();
			        	ydizi[i]=Integer.parseInt(engelyKoordinat);		        	
				}
				
				yol[(ydizi[i]-1)][(xdizi[i]-1)]=1;				
				�zgara.setDizix(xdizi);
				�zgara.setDiziy(ydizi);
			}

	        int xilk, yilk;
	        while(true){		
	        	int hata=0;
	        	System.out.print("Robotu konumland�rmak istedi�iniz yeri belirleyiniz(x,y): ");
	        	String robotKoordinat = scanner.nextLine();
	        	int virgulKonumu=0;
	        	for(int i=0;i<robotKoordinat.length();i++){
	        		String harf=robotKoordinat.substring(i, i+1);
	           
	        		if(harf.equals(",")){
	        			virgulKonumu=i;
	        		}
	        	}
	        	String xKoordinati = (robotKoordinat.substring(0,virgulKonumu)).toString();
	        	xilk=Integer.parseInt(xKoordinati);

	        	String yKoordinati=(robotKoordinat.substring(virgulKonumu+1, robotKoordinat.length())).toString();
	        	yilk=Integer.parseInt(yKoordinati);
	        	�zgara.repaint();
	        	while(xilk>=21 || yilk>=21 || xilk<=0 || yilk<=0)
	        	{
	        		System.out.println("Robotu harita d���na konumland�ramazs�n�z! L�tfen tekrar deneyiniz...");
	        		hata=1;
	        		break;
	        	}
	        	
	    		for(int i=0; i<engelSayisi; i++){
	    			if(xdizi[i]==xilk && ydizi[i]==yilk){
	    				System.out.println("Engel �zerine robot konumland�ramazs�n�z! L�tfen tekrar deneyiniz...");
	    				hata=1;
	    				break;
	    			}
	    		}
	    		if(hata==0)
	    			break;
	        }
			
			�zgara.setyRobot(yilk);
			�zgara.setxRobot(xilk);			
					
			donecek[0]=0;
			donecek[1]=0;
			donecek[2]=xilk;
			donecek[3]=yilk;
			String yon;
			System.out.println("Robotu ilerletmek istedi�iniz y�n� veya y�nleri giriniz...\n"
					+ "(�rnek: 1 sa�a, 2 sola, 3 ileri, 4 geri gibi...)");
			
			while(true){
				System.out.print("Y�n: ");
				yon = scanner.nextLine();
				
	        	int boslukKonum=0;
	        	for(int i=0;i<yon.length();i++){
	        		String harf=yon.substring(i, i+1);
	           
	        		if(harf.equals(" ")){
	        			boslukKonum=i;
	        		}
	        	}

	        	String gidilecekDeger = (yon.substring(0,boslukKonum)).toString();
	        	int mesafe=Integer.parseInt(gidilecekDeger);
	        	String yonBilgisi=(yon.substring(boslukKonum+1, yon.length())).toString();

	        	int birsey, kontrol=0;
	        	if(yonBilgisi.equals("sa�a"))
	        	{
	    			if((robot.getRobotTipi().contains("spider")))
	    			{
	    				if(xilk+mesafe >= 21)
	    				{
	    					birsey=(xilk+mesafe-1)-(Math.abs(19-(xilk+mesafe-1)));
	    					System.out.println(birsey);
	    					
	        				for(int j=xilk-1; j<=birsey; j++)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	    					//haritadan ��kmadan �nce engel var m� kontrol�
	        				for(int j=xilk-1; j<=(xilk+mesafe-1); j++)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    			}
	    			if(xilk+mesafe >= 21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}

	    			else if(yol[yilk-1][xilk+mesafe-1]==1)
	    			{
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}
	        		
	        		donecek[1]+=mesafe;
	        		for(int j=xilk-1; j<=(xilk+mesafe-1); j++)
	        		{
						if(yol[yilk-1][j]==1)
						{
							donecek[0]++;
						}
	        		}

	        		xilk+=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        		    
	        	else if(yonBilgisi.equals("sola"))
	        	{
	    			if((robot.getRobotTipi()).contains("spider"))
	    			{
	      				if(xilk-mesafe<=0)
	    				{
	    					birsey=(xilk-mesafe)-(0-(xilk-mesafe));
	    					
	        				for(int j=xilk-1; j>=birsey; j--)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	        				for(int j=xilk-1; j>=(xilk-mesafe-1); j--)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    			}
	    			if(xilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}

	    			else if(yol[yilk-1][xilk-mesafe-1]==1){
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}
	        		    
	        		donecek[1]+=mesafe;
	        		for(int j=xilk-1; j>=(xilk-mesafe-1); j--)
	        		{
						if(yol[yilk-1][j]==1)
						{
							donecek[0]++;
						}
	        		}
	        		
	        		xilk-=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	
	        	else if(yonBilgisi.equals("ileri"))
	        	{
	    			if((robot.getRobotTipi()).contains("spider"))
	    			{
	      				if(yilk+mesafe>=21)
	    				{
	    					birsey=(yilk+mesafe-1)-(Math.abs(19-(yilk+mesafe-1)));
	    					
	        				for(int j=yilk-1; j<=birsey; j++)
	        				{
	        					if(yol[j][xilk-1]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	    					for(int j=yilk-1; j<=(yilk+mesafe-1); j++)
	    					{
	    						if(yol[j][xilk-1]==1)
	    						{
	    							System.out.println("Spider robot engelden ge�emez!");
	    							kontrol++;
	    							break;
	    						}
	    					}
	        				if (kontrol!=0)
	        					break;
	    				}
	    			}
	    			if(yilk+mesafe>=21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	    			else if(yol[yilk+mesafe-1][xilk-1]==1){
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}
	        		
	        		donecek[1]+=mesafe;
	        		for(int j=yilk-1; j<=(yilk+mesafe-1); j++)
	        		{
						if(yol[j][xilk-1]==1)
						{
							donecek[0]++;
						}
	        		}
	        	
	        		yilk+=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	
	        	else
	        	{
	        		//geri gitmek i�in	        		
	    			if((robot.getRobotTipi()).contains("spider"))
	    			{
	    				if(yilk-mesafe<=0)
	    				{
	    					birsey=(yilk-mesafe)+(0-(yilk-mesafe));
	    					System.out.println(birsey);
	        				for(int j=(yilk-1); j>=birsey; j--)
	        				{
	        					if(yol[j][xilk-1]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	    					for(int j=(yilk-1); j>=(yilk-mesafe-1); j--)
	    					{
	    						if(yol[j][xilk-1]==1)
	    						{
	    							System.out.println("Spider robot engelden ge�emez!");
	    							kontrol++;
	    							break;
	    						}
	    					}
	        				if (kontrol!=0)
	        					break;
	    				}
	    			}
	    			if(yilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	       			else if(yol[yilk-mesafe-1][xilk-1]==1)
	       			{
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}
	        		
	        		donecek[1]+=mesafe;
	        		for(int j=(yilk-1); j>=(yilk-mesafe-1); j--)
	        		{
						if(yol[j][xilk-1]==1)
						{
							donecek[0]++;
						}
	        		}
	      
	        		yilk-=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();      	
	        	}	        	       	
			}
			
			/*System.out.println("Engel: " + donecek[0]);
			System.out.println("Yol: " + donecek[1]);
			System.out.println("X: " + donecek[2]);
			System.out.println("Y: " + donecek[3]);*/
			�zgara.setSonX(donecek[2]);
			�zgara.setSonY(donecek[3]);	
			�zgara.repaint();		
			break;		
		}
		
		if(engelSayisi==0)
		{
			Izgaralar2 �zgara=new Izgaralar2();
			�zgara.setSize(800, 800);
			�zgara.setVisible(true);
			
			int xilk, yilk, l=0;
			String robotKoordinat;
	        while(true){	
	        	int hata=0;
	        	System.out.print("Robotu konumland�rmak istedi�iniz yeri belirleyiniz(x,y): ");
	        	if(l==0){
		        	robotKoordinat = scanner.nextLine();
	        	}
	        	robotKoordinat = scanner.nextLine();
	        	int virgulKonumu=0;
	        	for(int i=0;i<robotKoordinat.length();i++){
	        		String harf=robotKoordinat.substring(i, i+1);
	           
	        		if(harf.equals(",")){
	        			virgulKonumu=i;
	        		}
	        	}
	        	String xKoordinati = (robotKoordinat.substring(0,virgulKonumu)).toString();
	        	xilk=Integer.parseInt(xKoordinati);

	        	String yKoordinati=(robotKoordinat.substring(virgulKonumu+1, robotKoordinat.length())).toString();
	        	yilk=Integer.parseInt(yKoordinati);
	        	
	        	�zgara.repaint();
	        	
	        	if(xilk>=21 || xilk<1 || yilk<1 || yilk>=21)
	        	{
	        		System.out.println("Robotu harita d���n� konumland�ramazs�n�z!");
	        		hata=1;
	        	}
	        	if(hata==0)	
	    			break;
	        }
			
			�zgara.setyRobot(yilk);
			�zgara.setxRobot(xilk);
						
			donecek[0]=0;
			donecek[1]=0;
			donecek[2]=xilk;
			donecek[3]=yilk;
			String yon;
			System.out.println("Robotu ilerletmek istedi�iniz y�n� veya y�nleri giriniz...\n"
					+ "(�rnek: 1 sa�a, 2 sola, 3 ileri, 4 geri gibi...)");
			
			while(true){
				System.out.print("Y�n: ");
				yon = scanner.nextLine();
				
	        	int boslukKonum=0;
	        	for(int i=0;i<yon.length();i++){
	        		String harf=yon.substring(i, i+1);
	           
	        		if(harf.equals(" ")){
	        			boslukKonum=i;
	        		}
	        	}

	        	String gidilecekDeger = (yon.substring(0,boslukKonum)).toString();
	        	int mesafe=Integer.parseInt(gidilecekDeger);
	        	System.out.println("mesafe: " + mesafe);

	        	String yonBilgisi=(yon.substring(boslukKonum+1, yon.length())).toString();
	        	System.out.println("Y�n bilgisi: " + yonBilgisi);
	        	
	        	if(yonBilgisi.equals("sa�a"))
	        	{
	    			if(xilk+mesafe >= 21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	        		
	        		donecek[1]+=mesafe;
	        		xilk+=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	        	
	        	else if(yonBilgisi.equals("sola"))
	        	{	    	
	    			if(xilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	    			
	        		donecek[1]+=mesafe;
	        		xilk-=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	
	        	else if(yonBilgisi.equals("ileri"))
	        	{
	    			if(yilk+mesafe>=21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	        		
	        		donecek[1]+=mesafe;
	        		yilk+=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	
	        	else
	        	{
	        		//geri gitmek i�in        		
	    			if(yilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	        		
	        		donecek[1]+=mesafe;
	        		yilk-=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();     		
	        	}	        	       	
			}
			
			/*System.out.println("Engel: " +donecek[0]);
			System.out.println("Yol: " + donecek[1]);
			System.out.println("X: " + donecek[2]);
			System.out.println("Y: " + donecek[3]);*/			
			�zgara.setSonX(donecek[2]);
			�zgara.setSonY(donecek[3]);
			�zgara.repaint();
		}
		
		return donecek;	
	}
		
	public static float manipulatorYerlestir(ManipulatorRobot robot, int[][]yol)
	{	
		float donecek=0;
		Scanner scanner = new Scanner(System.in);
		scanner.useLocale(Locale.US);
		
		Izgaralar2 �zgara=new Izgaralar2();
		�zgara.setSize(800, 800);
		�zgara.setVisible(true);
		
		int xilk, yilk;
		String robotKoordinat;
        while(true){
        	int hata=0;
        	System.out.print("Robotu konumland�rmak istedi�iniz yeri belirleyiniz(x,y): ");
        	robotKoordinat = scanner.nextLine();
        	int virgulKonumu=0;
        	for(int i=0;i<robotKoordinat.length();i++){
        		String harf=robotKoordinat.substring(i, i+1);
           
        		if(harf.equals(",")){
        			virgulKonumu=i;
        		}
        	}
        	String xKoordinati = (robotKoordinat.substring(0,virgulKonumu)).toString();
        	xilk=Integer.parseInt(xKoordinati);

        	String yKoordinati=(robotKoordinat.substring(virgulKonumu+1, robotKoordinat.length())).toString();
        	yilk=Integer.parseInt(yKoordinati);
        	�zgara.repaint();
           	
        	if(xilk>21 || xilk<1 || yilk<1 || yilk>21)
        	{
        		System.out.println("Robotu harita d���n� konumland�ramazs�n�z!");
        		hata=1;
        	}
        	if(hata==0)	
    			break;
        }
		
		�zgara.setManiSabitY(yilk);
		�zgara.setManiSabitX(xilk);

		int xson=xilk;
		int yson=yilk;
		
		System.out.print("Ta��mak istedi�iniz y�k miktar�n� giriniz: ");
		float tasinacak_yuk;
		
		while(true)
		{
			int hata=0;
			tasinacak_yuk = scanner.nextFloat();
			if(tasinacak_yuk>robot.getYukTasimaKapasitesi())
			{
				System.out.print("Kapasitesinden fazla y�k ta��yamaz, l�tfen tekrar giriniz: ");
				hata=1;
			}
			if (hata==0)
				break;
		}
		
		String yon;
		System.out.println("Y�k� ilerletmek istedi�iniz y�n� veya y�nleri giriniz...\n"
					+ "(�rnek: 1 sa�a, 2 sola, 3 ileri, 4 geri gibi...)");
		int l=1;
		
		while(true){
			System.out.print("Y�n: ");
			if(l==1)
			{
				yon = scanner.nextLine();
				l++;
			}
				
			yon = scanner.nextLine();
			
        	int boslukKonum=0;
        	for(int i=0;i<yon.length();i++){
        		String harf=yon.substring(i, i+1);
           
        		if(harf.equals(" ")){
        			boslukKonum=i;
        		}
        	}

        	String gidilecekDeger = (yon.substring(0,boslukKonum)).toString();
        	int mesafe=Integer.parseInt(gidilecekDeger);
        	String yonBilgisi=(yon.substring(boslukKonum+1, yon.length())).toString();

       		if(yonBilgisi.equals("sa�a"))
          	{
           		if(yilk==yson)
           		{
           			if(Math.abs(xilk-(xson+mesafe))*10>robot.getKolUzunlugu())
           			{
                   		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(xilk-(xson+mesafe))*10);
                   		break;
           			}
           		}
           		//hipoten�s hesaplatma
           		else if(Math.pow((xilk-(xson+mesafe))*10, 2)+Math.pow((yilk-yson)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
           		{
               		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((xilk-(xson+mesafe))*10, 2)+Math.pow((yilk-yson)*10, 2)));
               		break;
           		}
       			if(xson+mesafe >= 21)
           		{
           			System.out.println("Haritadan d��ar�ya ��k�lamaz!");
               		�zgara.setSonX(xson);
               		�zgara.setSonY(yson);
                   	�zgara.repaint();
               		return donecek;
           		}
            		

           		xson+=mesafe;    
        		�zgara.setSonX(xson);
        		�zgara.setSonY(yson);
        		�zgara.repaint();

           		/*if(yilk==yson)
       				donecek = Math.abs(xilk - xson);
       			else if (xilk == xson)
       				donecek = Math.abs(yilk-yson);
       			else
       				donecek = (float) Math.sqrt((Math.pow(Math.abs(xilk-xson),2)+Math.pow(Math.abs(yilk-yson),2)));
           		 */
				donecek += mesafe;
           		/*System.out.println("Robot Konumu: " + xson + "," + yson);
           		System.out.println("Yol: " + donecek);         */ 		
           	}
            	          	
           	else if(yonBilgisi.equals("sola"))
           	{
           		if(yilk==yson)
           		{
           			if(Math.abs(xilk-(xson-mesafe))*10>robot.getKolUzunlugu())
           			{
                   		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(xilk-(xson-mesafe))*10);
                   		break;
           			}
           		}
           		//hipoten�s hesaplatma
           		else if(Math.pow((xilk-(xson-mesafe))*10, 2)+Math.pow((yson-yilk)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
           		{
               		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((xilk-(xson-mesafe))*10, 2)+Math.pow((yson-yilk)*10, 2)));
               		break;
           		}
       			if(xson-mesafe<=0)
           		{
           			System.out.println("Haritadan d��ar�ya ��k�lamaz!");
               		�zgara.setSonX(xson);
               		�zgara.setSonY(yson);
                   	�zgara.repaint();
               		return donecek;
           		}
           		
           		xson-=mesafe;
        		�zgara.setSonX(xson);
        		�zgara.setSonY(yson);
        		�zgara.repaint();
       			/*if(yilk==yson)
       				donecek = Math.abs(xilk-xson);
       			else if (xilk == xson)
       				donecek = Math.abs(yilk-yson);
       			else
       				donecek = (float) Math.sqrt((Math.pow(Math.abs(xilk-xson),2)+Math.pow(Math.abs(yilk-yson),2)));
       			 */
				donecek += mesafe;
           		/*System.out.println("Robot Konumu: " + xson + "," + yson);
           		System.out.println("Yol: " + donecek);   */         		
           	}
            	
           	else if(yonBilgisi.equals("ileri"))
           	{           		
           		if(xilk==xson)
           		{
           			if(Math.abs(yilk-(yson+mesafe))*10>robot.getKolUzunlugu())
           			{
                   		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(yilk-(yson+mesafe))*10);
                   		break;
           			}
           		}
           		//hipoten�s hesaplatma
           		else if(Math.pow((yilk-(yson+mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
           		{
               		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((yilk-(yson+mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)));
               		break;
           		}
       			if(yson+mesafe>=21)
           		{
           			System.out.println("Haritadan d��ar�ya ��k�ld�!");
               		�zgara.setSonX(xson);
               		�zgara.setSonY(yson);
                   	�zgara.repaint();
               		return donecek;
           		}
           		
           		yson+=mesafe;
        		�zgara.setSonX(xson);
        		�zgara.setSonY(yson);
        		�zgara.repaint();
       			/*if(yilk==yson)
       				donecek = Math.abs(xilk-xson);
       			else if (xilk == xson)
       				donecek = Math.abs(yilk-yson);
       			else
       				donecek = (float) Math.sqrt((Math.pow(Math.abs(xilk-xson),2)+Math.pow(Math.abs(yilk-yson),2)));
       			 */
				donecek += mesafe;
        		/*System.out.println("Robot Konumu: " + xson + "," + yson);
           		System.out.println("Yol: " + donecek);      */    		
           	}
       		
           	else
           	{
           		//geri gitmek i�in       
           		if(xilk==xson)
           		{
           			if(Math.abs(yilk-(yson-mesafe))*10>robot.getKolUzunlugu())
           			{
                   		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(yilk-(yson-mesafe))*10);
                   		break;
           			}
           		}
           		//hipoten�s hesaplatma
           		else if(Math.pow((yilk-(yson-mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
           		{
               		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((yilk-(yson-mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)));
               		break;
           		}
           		
       			if(yson-mesafe<=0)
           		{
           			System.out.println("Haritadan d��ar�ya ��k�lamaz!");
               		�zgara.setSonX(xson);
               		�zgara.setSonY(yson);
                   	�zgara.repaint();
                	return donecek;
            	}
            		
            	yson-=mesafe;
	        	�zgara.setSonX(xson);
	        	�zgara.setSonY(yson);
	        	�zgara.repaint();

/*        		if(yilk==yson)
        			donecek = Math.abs(xilk-xson);
        		else if (xilk == xson)
        			donecek = Math.abs(yilk-yson);
        		else
        			donecek = (float) Math.sqrt((Math.pow(Math.abs(xilk-xson),2)+Math.pow(Math.abs(yilk-yson),2)));
*/
				donecek += mesafe;
            	/*System.out.println("Robot Konumu: " + xson + "," + yson);
            	System.out.println("Yol: " + donecek);*/
            }
        }    	        	        	       	
				
		/*System.out.println("Yol: " + donecek);
		System.out.println("X: " + xson);
		System.out.println("Y: " + yson);*/		
		�zgara.setSonX(xson);
		�zgara.setSonY(yson);
		�zgara.repaint();
		
		return donecek;
	}
	
	public static void hibritHarita(HibritRobot robot, int[][] yol)
	{
		//engel konumland�rma
		Scanner scanner = new Scanner(System.in);
		scanner.useLocale(Locale.US);
		int[] donecek = new int[4];//0.engel sayisi, 1.ilerlenen yol
		float engelGecme, sure1 = 0, maniYol=0;
		
		System.out.print("Ka� tane engel koyacaks�n�z: ");
		int engelSayisi = scanner.nextInt();
		while(engelSayisi!=0)
		{
			int[] xdizi=new int[engelSayisi];
			int[] ydizi=new int[engelSayisi];
			Izgaralar �zgara=new Izgaralar(xdizi,ydizi);
			�zgara.setSize(800, 800);
			�zgara.setVisible(true);
				
			String engelKoordinat;
			for(int i=0; i<engelSayisi; i++)
			{
				System.out.print(i+1 + ". (x,y): ");
				if(i==0){
					engelKoordinat = scanner.nextLine();
					engelKoordinat = scanner.nextLine();
				}
				else
					engelKoordinat = scanner.nextLine();
							
	        	int virgulKonumu=0;
	        	for(int j=0;j<engelKoordinat.length();j++)
	        	{
	        		String harf=engelKoordinat.substring(j, j+1);          
	        		if(harf.equals(",")){
	        			virgulKonumu=j;
	        		}
	        	}

	        	String engelxKoordinat = (engelKoordinat.substring(0,virgulKonumu)).toString();
	        	xdizi[i]=Integer.parseInt(engelxKoordinat);

	        	String engelyKoordinat=(engelKoordinat.substring(virgulKonumu+1, engelKoordinat.length())).toString();
	        	ydizi[i]=Integer.parseInt(engelyKoordinat);
	        	�zgara.repaint();
			
				while((xdizi[i]>20 || ydizi[i]>20) || (xdizi[i]<1 || ydizi[i]<1)){
						System.out.println("Hatal� de�er veya de�erler girdiniz.\n"
								+ "Girdi�iniz de�erler 20'den b�y�k, 1'den k���k olamaz\n"
								+ "Tekrar giriniz...");
						System.out.print(i+1 + "(x,y): ");
						engelKoordinat = scanner.nextLine();
			        	virgulKonumu=0;
			        	for(int k=0; k<engelKoordinat.length(); k++){
			        		String harf=engelKoordinat.substring(k, k+1);
			           
			        		if(harf.equals(",")){
			        			virgulKonumu=k;
			        		}
			        	}
			        	engelxKoordinat = (engelKoordinat.substring(0,virgulKonumu)).toString();
			        	xdizi[i]=Integer.parseInt(engelxKoordinat);

			        	engelyKoordinat=(engelKoordinat.substring(virgulKonumu+1, engelKoordinat.length())).toString();
			        	ydizi[i]=Integer.parseInt(engelyKoordinat);		        	
				}				
				yol[(ydizi[i]-1)][(xdizi[i]-1)]=1;
				
				//Dizi
				/*for(int j=0; 20>j;j++){
					for(int s=0; 20>s;s++){
						System.out.print(yol[j][s] + " ");
					}
					System.out.println();
				}*/
				
				�zgara.setDizix(xdizi);
				�zgara.setDiziy(ydizi);
			}

	        int xilk, yilk;
	        while(true)
	        {		
	        	int hata=0;
	        	System.out.print("Robotu konumland�rmak istedi�iniz yeri belirleyiniz(x,y): ");
	        	String robotKoordinat = scanner.nextLine();
	        	int virgulKonumu=0;
	        	for(int i=0;i<robotKoordinat.length();i++){
	        		String harf=robotKoordinat.substring(i, i+1);
	           
	        		if(harf.equals(",")){
	        			virgulKonumu=i;
	        		}
	        	}
	        	String xKoordinati = (robotKoordinat.substring(0,virgulKonumu)).toString();
	        	xilk=Integer.parseInt(xKoordinati);

	        	String yKoordinati=(robotKoordinat.substring(virgulKonumu+1, robotKoordinat.length())).toString();
	        	yilk=Integer.parseInt(yKoordinati);
	        	�zgara.repaint();
	        	while(xilk>=21 || yilk>=21 || xilk<=0 || yilk<=0)
	        	{
	        		System.out.println("Robotu harita d���na konumland�ramazs�n�z! L�tfen tekrar deneyiniz...");
	        		hata=1;
	        		break;
	        	}
        	
	    		for(int i=0; i<engelSayisi; i++){
	    			if(xdizi[i]==xilk && ydizi[i]==yilk){
	    				System.out.println("Engel �zerine robot konumland�ramazs�n�z! L�tfen tekrar deneyiniz...");
	    				hata=1;
	    				break;
	    			}
	    		}
	    		if(hata==0)
	    			break;
	        }
			
			�zgara.setyRobot(yilk);
			�zgara.setxRobot(xilk);
			//Engel konumland�rma bitti
		
			donecek[0]=0;
			donecek[1]=0;
			donecek[2]=xilk;
			donecek[3]=yilk;
			String yon;
			System.out.println("\nRobotu ilerletmek istedi�iniz y�n� veya y�nleri giriniz...\n"
					+ "(�rnek: 1 sa�a, 2 sola, 3 ileri, 4 geri gibi...)");
			
			while(true)
			{
				System.out.print("Y�n: ");
				yon = scanner.nextLine();
				
	        	int boslukKonum=0;
	        	for(int i=0;i<yon.length();i++){
	        		String harf=yon.substring(i, i+1);
	           
	        		if(harf.equals(" ")){
	        			boslukKonum=i;
	        		}
	        	}
	        	String gidilecekDeger = (yon.substring(0,boslukKonum)).toString();
	        	int mesafe=Integer.parseInt(gidilecekDeger);
	        	String yonBilgisi=(yon.substring(boslukKonum+1, yon.length())).toString();
	        	int birsey, kontrol=0;
	        	if(yonBilgisi.equals("sa�a"))
	        	{
	    			if((robot.getRobotTipi().contains("spider")))
	    			{
	    				if(xilk+mesafe >= 21)
	    				{
	    					birsey=(xilk+mesafe-1)-(Math.abs(19-(xilk+mesafe-1)));
	    					
	        				for(int j=xilk-1; j<=birsey; j++)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	        				for(int j=xilk-1; j<=(xilk+mesafe-1); j++)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}

	    			}
	    			if(xilk+mesafe >= 21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	    			else if(yol[yilk-1][xilk+mesafe-1]==1){
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}
	        		
	        		donecek[1]+=mesafe;
	        		for(int j=xilk-1; j<=(xilk+mesafe-1); j++)
	        		{
						if(yol[yilk-1][j]==1)
						{
							donecek[0]++;
						}
	        		}
	       
	        		xilk+=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        		        	
	        	else if(yonBilgisi.equals("sola"))
	        	{
	    			if((robot.getRobotTipi()).contains("spider"))
	    			{
	      				if(xilk-mesafe<=0)
	    				{
	    					birsey=(xilk-mesafe)-(0-(xilk-mesafe));
	    					
	        				for(int j=xilk-1; j>=birsey; j--)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	        				for(int j=xilk-1; j>=(xilk-mesafe-1); j--)
	        				{
	        					if(yol[yilk-1][j]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    			}
	    			if(xilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}

	    			else if(yol[yilk-1][xilk-mesafe-1]==1)
	    			{
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}
	        		
	        		donecek[1]+=mesafe;
	        		for(int j=xilk-1; j>=(xilk-mesafe-1); j--)
	        		{
						if(yol[yilk-1][j]==1)
						{
							donecek[0]++;
							System.out.println(yol[j][xilk-1] + " => [j]: " + (j) + " [xilk-1]: " + (xilk-1) + " Top engel: " + donecek[0]);
						}
	        		}
	    
	        		xilk-=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	
	        	else if(yonBilgisi.equals("ileri"))
	        	{
	    			if((robot.getRobotTipi()).contains("spider"))
	    			{
	      				if(yilk+mesafe>=21)
	    				{
	    					birsey=(yilk+mesafe-1)-(Math.abs(19-(yilk+mesafe-1)));
	    					
	        				for(int j=yilk-1; j<=birsey; j++)
	        				{
	        					if(yol[j][xilk-1]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	    					for(int j=yilk-1; j<=(yilk+mesafe-1); j++)
	    					{
	    						if(yol[j][xilk-1]==1)
	    						{
	    							System.out.println("Spider robot engelden ge�emez!");
	    							kontrol++;
	    							break;
	    						}
	    					}
	        				if (kontrol!=0)
	        					break;
	    				}
	    			}
	    			if(yilk+mesafe>=21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	    			else if(yol[yilk+mesafe-1][xilk-1]==1)
	    			{
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}

	        		donecek[1]+=mesafe;
	        		for(int j=yilk-1; j<=(yilk+mesafe-1); j++)
	        		{
						if(yol[j][xilk-1]==1)
						{
							donecek[0]++;
						}
	        		}
	        	
	        		yilk+=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	else
	        	{
	        		//geri gitmek i�in	        		
	    			if((robot.getRobotTipi()).contains("spider"))
	    			{
	    				if(yilk-mesafe<=0)
	    				{
	    					birsey=(yilk-mesafe)+(0-(yilk-mesafe));

	        				for(int j=(yilk-1); j>=birsey; j--)
	        				{
	        					if(yol[j][xilk-1]==1)
	        					{
	        						System.out.println("Spider robot engelden ge�emez!");
	        						kontrol++;
	        						break;
	        					}
	        				}
	        				if (kontrol!=0)
	        					break;
	    				}
	    				else
	    				{
	    					for(int j=(yilk-1); j>=(yilk-mesafe-1); j--)
	    					{
	    						if(yol[j][xilk-1]==1)
	    						{
	    							System.out.println("Spider robot engelden ge�emez!");
	    							kontrol++;
	    							break;
	    						}
	    					}
	        				if (kontrol!=0)
	        					break;
	    				}
	    			}
	    			if(yilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}

	       			else if(yol[yilk-mesafe-1][xilk-1]==1)
	       			{
	    				System.out.println("Robot engelin �zerinde kalamaz!");
	    				break;
	    			}
	        		
	        		donecek[1]+=mesafe;
	        		for(int j=(yilk-1); j>=(yilk-mesafe-1); j--)
	        		{
						if(yol[j][xilk-1]==1)
						{
							donecek[0]++;
						}
	        		}
	        
	        		yilk-=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();		
	        	}	        	       	
			}
			
			/*System.out.println("Engel: " + donecek[0]);
			System.out.println("Yol: " + donecek[1]);
			System.out.println("X: " + donecek[2]);
			System.out.println("Y: " + donecek[3]);*/
			�zgara.setManiSabitX(donecek[2]);
			�zgara.setManiSabitY(donecek[3]);	
			�zgara.repaint();
			///// ilerlet bitti
			
			engelGecme = robot.EngelGecmeSuresiBul()*donecek[0];
			sure1 = engelGecme + (donecek[1]*10*robot.getGezinmeHizi());
			sure1 += robot.getSabitlenmeSuresi() + robot.getYukGecisSuresi();
			
			System.out.println("\nRobot sabitlendi ve y�k kola y�klendi, l�tfen y�k� konumland�r�n...");
			
			/////Manip�lator
			xilk = donecek[2];
			yilk = donecek[3];
			int xson = xilk;
			int yson = yilk;
			//Y�k� hareket ettirme alan�
			System.out.println("\nY�k� ilerletmek istedi�iniz y�n� veya y�nleri giriniz...\n"
					+ "(�rnek: 1 sa�a, 2 sola, 3 ileri, 4 geri gibi...)");
			
			while(true)
			{
				System.out.print("Y�n: ");
				yon = scanner.nextLine();
				
	        	int boslukKonum=0;
	        	for(int i=0;i<yon.length();i++){
	        		String harf=yon.substring(i, i+1);
	           
	        		if(harf.equals(" ")){
	        			boslukKonum=i;
	        		}
	        	}
	        	String gidilecekDeger = (yon.substring(0,boslukKonum)).toString();
	        	int mesafe=Integer.parseInt(gidilecekDeger);

	        	String yonBilgisi=(yon.substring(boslukKonum+1, yon.length())).toString();
	        	
				if (yonBilgisi.equals("sa�a")) 
				{
					if (yilk == yson) 
					{
						if (Math.abs(xilk - (xson + mesafe)) * 10 > robot.getKolUzunlugu()) 
						{
							System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(xilk-(xson+mesafe))*10);
							break;
						}
					}
					// hipoten�s hesaplatma
					else if (Math.pow((xilk - (xson + mesafe)) * 10, 2) + Math.pow((yilk - yson) * 10, 2) > Math.pow(
							robot.getKolUzunlugu(), 2)) 
					{
						System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((xilk - (xson + mesafe)) * 10, 2) + Math.pow((yilk - yson) * 10, 2)));
						break;
					}

					if (xson + mesafe >= 21) 
					{
						System.out.println("Haritadan d��ar�ya ��k�lamaz!");
						�zgara.setSonX(xson);
						�zgara.setSonY(yson);
						�zgara.repaint();
						break;
					}

					if (yol[yson - 1][xson + mesafe - 1] == 1) 
					{
						System.out.println("Y�k engel �zerine konumland�r�lamaz!");
						break;
					}

					xson += mesafe;
					�zgara.setSonX(xson);
					�zgara.setSonY(yson);
					�zgara.repaint();
	
/*					if (yilk == yson)
						maniYol = Math.abs(xilk - xson);
					else if (xilk == xson)
						maniYol = Math.abs(yilk - yson);
					else
						maniYol = (float) Math.sqrt((Math.pow(Math.abs(xilk - xson), 2) + Math.pow(Math.abs(yilk - yson), 2)));
*/
					maniYol += mesafe;
				}
				
				else if (yonBilgisi.equals("sola")) 
				{
					if (yilk == yson) 
					{
						if (Math.abs(xilk - (xson - mesafe)) * 10 > robot.getKolUzunlugu()) 
						{
							System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(xilk-(xson-mesafe))*10);
							break;
						}
					}
					// hipoten�s hesaplatma
					else if (Math.pow((xilk - (xson - mesafe)) * 10, 2)
							+ Math.pow((yson - yilk) * 10, 2) > Math.pow(
							robot.getKolUzunlugu(), 2)) 
					{
						System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((xilk - (xson - mesafe)) * 10, 2)+ Math.pow((yson - yilk) * 10, 2)));
						break;
					}

					if (xson - mesafe <= 0) 
					{
						System.out.println("Haritadan d��ar�ya ��k�lamaz!");
						�zgara.setSonX(xson);
						�zgara.setSonY(yson);
						�zgara.repaint();
						break;
					}

					if (yol[yson - 1][xson - mesafe - 1] == 1) {
						System.out.println("Y�k engel �zerine konumland�r�lamaz!");
						break;
					}
			
					xson -= mesafe;
					�zgara.setSonX(xson);
					�zgara.setSonY(yson);
					�zgara.repaint();
			
					maniYol += mesafe;

				}

				else if (yonBilgisi.equals("ileri")) 
				{
					if (xilk == xson) 
					{
						if (Math.abs(yilk - (yson + mesafe)) * 10 > robot
								.getKolUzunlugu()) 
						{
							System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(yilk-(yson+mesafe))*10);
							break;
						}
					}
					// hipoten�s hesaplatma
					else if (Math.pow((yilk - (yson + mesafe)) * 10, 2)
							+ Math.pow((xson - xilk) * 10, 2) > Math.pow(
							robot.getKolUzunlugu(), 2)) 
					{
						System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((yilk - (yson + mesafe)) * 10, 2)+Math.pow((xson - xilk) * 10, 2)));
						break;
					}

					if (yson + mesafe >= 21) 
					{
						System.out.println("Haritadan d��ar�ya ��k�ld�!");
						�zgara.setSonX(xson);
						�zgara.setSonY(yson);
						�zgara.repaint();
						break;
					}

					if (yol[yson + mesafe - 1][xson - 1] == 1) 
					{
						System.out.println("Y�k engel �zerine konumland�r�lamaz!");
						break;
					}
			
					yson += mesafe;
					�zgara.setSonX(xson);
					�zgara.setSonY(yson);
					�zgara.repaint();
				
					maniYol += mesafe;
				} 
				
				else 
				{
					// geri gitmek i�in
					if (xilk == xson) 
					{
						if (Math.abs(yilk - (yson - mesafe)) * 10 > robot
								.getKolUzunlugu()) 
						{
							System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(yilk-(yson-mesafe))*10);
							break;
						}
					}
					// hipoten�s hesaplatma
					else if (Math.pow((yilk - (yson - mesafe)) * 10, 2)
							+ Math.pow((xson - xilk) * 10, 2) > Math.pow(
							robot.getKolUzunlugu(), 2)) 
					{
						System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((yilk - (yson - mesafe)) * 10, 2)+ Math.pow((xson - xilk) * 10, 2)));
						break;
					}

					if (yson - mesafe <= 0) 
					{
						System.out.println("Haritadan d��ar�ya ��k�lamaz!");
						�zgara.setSonX(xson);
						�zgara.setSonY(yson);
						�zgara.repaint();
						break;
					}
					if (yol[yson - mesafe - 1][xson - 1] == 1) 
					{
						System.out.println("Y�k engel �zerine konumland�r�lamaz!");
						break;
					}

					yson -= mesafe;
					�zgara.setSonX(xson);
					�zgara.setSonY(yson);
					�zgara.repaint();

					maniYol += mesafe;
				}
			}       	        	        	       	
			
			/*System.out.println("Yol: " + maniYol);
			System.out.println("X: " + xson);
			System.out.println("Y: " + yson);*/			
			�zgara.setSonX(xson);
			�zgara.setSonY(yson);
			�zgara.repaint();
			
			break;	
		}
		
		if(engelSayisi==0)
		{
			Izgaralar2 �zgara=new Izgaralar2();
			�zgara.setSize(800, 800);
			�zgara.setVisible(true);
			
			int xilk, yilk, l=0;
			String robotKoordinat;
	        while(true)
	        {	
	        	int hata=0;
	        	System.out.print("Robotu konumland�rmak istedi�iniz yeri belirleyiniz(x,y): ");
	        	if(l==0){
		        	robotKoordinat = scanner.nextLine();
	        	}
	        	robotKoordinat = scanner.nextLine();
	        	int virgulKonumu=0;
	        	for(int i=0;i<robotKoordinat.length();i++){
	        		String harf=robotKoordinat.substring(i, i+1);
	           
	        		if(harf.equals(",")){
	        			virgulKonumu=i;
	        		}
	        	}
	        	String xKoordinati = (robotKoordinat.substring(0,virgulKonumu)).toString();
	        	xilk=Integer.parseInt(xKoordinati);

	        	String yKoordinati=(robotKoordinat.substring(virgulKonumu+1, robotKoordinat.length())).toString();
	        	yilk=Integer.parseInt(yKoordinati);
	        	
	        	�zgara.repaint();
	        	
	        	if(xilk>=21 || xilk<1 || yilk<1 || yilk>=21)
	        	{
	        		System.out.println("Robotu harita d���na konumland�ramazs�n�z!");
	        		hata=1;
	        	}
	        	if(hata==0)	
	    			break;
	        }
			
			�zgara.setyRobot(yilk);
			�zgara.setxRobot(xilk);
			
			//////Engel konumland�rma bitti			
			donecek[0]=0;
			donecek[1]=0;
			donecek[2]=xilk;
			donecek[3]=yilk;
			String yon;
			System.out.println("\nRobotu ilerletmek istedi�iniz y�n� veya y�nleri giriniz...\n"
					+ "(�rnek: 1 sa�a, 2 sola, 3 ileri, 4 geri gibi...)");
			
			while(true)
			{
				System.out.print("Y�n: ");
				yon = scanner.nextLine();
				
	        	int boslukKonum=0;
	        	for(int i=0;i<yon.length();i++){
	        		String harf=yon.substring(i, i+1);
	           
	        		if(harf.equals(" ")){
	        			boslukKonum=i;
	        		}
	        	}

	        	String gidilecekDeger = (yon.substring(0,boslukKonum)).toString();
	        	int mesafe=Integer.parseInt(gidilecekDeger);

	        	String yonBilgisi=(yon.substring(boslukKonum+1, yon.length())).toString();

	        	if(yonBilgisi.equals("sa�a"))
	        	{
	    			if(xilk+mesafe >= 21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	        		
	        		donecek[1]+=mesafe;

	        		xilk+=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        		        	
	        	else if(yonBilgisi.equals("sola"))
	        	{  			
	    			if(xilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	        		
	        		donecek[1]+=mesafe;
	   
	        		xilk-=mesafe;
	        		donecek[2]=xilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	
	        	else if(yonBilgisi.equals("ileri"))
	        	{
	    			if(yilk+mesafe>=21)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	        		
	        		donecek[1]+=mesafe;
	  
	        		yilk+=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();
	        	}
	        	
	        	else
	        	{
	        		//geri gitmek i�in        		
	    			if(yilk-mesafe<=0)
	        		{
	        			System.out.println("Haritadan d��ar�ya ��k�ld�!");
	        			break;
	        		}
	        		
	        		donecek[1]+=mesafe;
	      
	        		yilk-=mesafe;
	        		donecek[3]=yilk;
	        		�zgara.setSonX(xilk);
	        		�zgara.setSonY(yilk);
	        		�zgara.repaint();      		
	        	}       	       	
			}
			
			/*System.out.println("Engel: " +donecek[0]);
			System.out.println("Yol: " + donecek[1]);
			System.out.println("X: " + donecek[2]);
			System.out.println("Y: " + donecek[3]);*/
			
			�zgara.setManiSabitX(donecek[2]);
			�zgara.setManiSabitY(donecek[3]);
			�zgara.repaint();
						
			///// ilerlet bitti
			System.out.println("\nRobot sabitlendi ve y�k kola y�klendi, l�tfen y�k� konumland�r�n...");
			sure1 = robot.getGezinmeHizi()*10*donecek[1];
			sure1 += robot.getSabitlenmeSuresi() + robot.getYukGecisSuresi();
			
			/////Manip�lator
			xilk = donecek[2];
			yilk = donecek[3];
			int xson = xilk;
			int yson = yilk;
			//Y�k� hareket ettirme alan�
			System.out.println("\nY�k� ilerletmek istedi�iniz y�n� veya y�nleri giriniz...\n"
					+ "(�rnek: 1 sa�a, 2 sola, 3 ileri, 4 geri gibi...)");
			
			while(true)
			{
				System.out.print("Y�n: ");
				yon = scanner.nextLine();
				
	        	int boslukKonum=0;
	        	for(int i=0;i<yon.length();i++){
	        		String harf=yon.substring(i, i+1);
	           
	        		if(harf.equals(" ")){
	        			boslukKonum=i;
	        		}
	        	}

	        	String gidilecekDeger = (yon.substring(0,boslukKonum)).toString();
	        	int mesafe=Integer.parseInt(gidilecekDeger);

	        	String yonBilgisi=(yon.substring(boslukKonum+1, yon.length())).toString();
	        	
        		if(yonBilgisi.equals("sa�a"))
            	{
            		if(yilk==yson)
            		{
            			if(Math.abs(xilk-(xson+mesafe))*10>robot.getKolUzunlugu())
            			{
                    		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(xilk-(xson+mesafe))*10);
                    		break;
            			}
            		}
            		//hipoten�s hesaplatma
            		else if(Math.pow((xilk-(xson+mesafe))*10, 2)+Math.pow((yilk-yson)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
            		{
                		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((xilk-(xson+mesafe))*10, 2)+Math.pow((yilk-yson)*10, 2)));
                		break;
            		}

        			if(xson+mesafe >= 21)
            		{
            			System.out.println("Haritadan d��ar�ya ��k�lamaz!");
                		�zgara.setSonX(xson);
                		�zgara.setSonY(yson);
                    	�zgara.repaint();
                    	break;
            		}
        			
            		xson+=mesafe;  
	        		�zgara.setSonX(xson);
	        		�zgara.setSonY(yson);
	        		�zgara.repaint();
	        		maniYol += mesafe;     		
            	}
            		            	
            	else if(yonBilgisi.equals("sola"))
            	{
            		if(yilk==yson)
            		{
            			if(Math.abs(xilk-(xson-mesafe))*10>robot.getKolUzunlugu())
            			{
                    		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(xilk-(xson-mesafe))*10);
                    		break;
            			}
            		}
            		//hipoten�s hesaplatma
            		else if(Math.pow((xilk-(xson-mesafe))*10, 2)+Math.pow((yson-yilk)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
            		{
                		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
                		break;
            		}

        			if(xson-mesafe<=0)
            		{
            			System.out.println("Haritadan d��ar�ya ��k�lamaz!");
                		�zgara.setSonX(xson);
                		�zgara.setSonY(yson);
                    	�zgara.repaint();
                    	break;
            		}
        	
            		xson-=mesafe;
	        		�zgara.setSonX(xson);
	        		�zgara.setSonY(yson);
	        		�zgara.repaint();
	   
	        		maniYol += mesafe;           		
            	}
            	
            	else if(yonBilgisi.equals("ileri"))
            	{
            		if(xilk==xson)
            		{
            			if(Math.abs(yilk-(yson+mesafe))*10>robot.getKolUzunlugu())
            			{
                    		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(yilk-(yson+mesafe))*10);
                    		break;
            			}
            		}
            		//hipoten�s hesaplatma
            		else if(Math.pow((yilk-(yson+mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
            		{
                		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((yilk-(yson+mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)));
                		break;
            		}

        			if(yson+mesafe>=21)
            		{
            			System.out.println("Haritadan d��ar�ya ��k�ld�!");
                		�zgara.setSonX(xson);
                		�zgara.setSonY(yson);
                    	�zgara.repaint();
                    	break;
            		}
        			
            		yson+=mesafe;
	        		�zgara.setSonX(xson);
	        		�zgara.setSonY(yson);
	        		�zgara.repaint();

	        		maniYol += mesafe;            		
            	}
        		
            	else
            	{
            		//geri gitmek i�in
            		if(xilk==xson)
            		{
            			if(Math.abs(yilk-(yson-mesafe))*10>robot.getKolUzunlugu())
            			{
                    		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	                   		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.abs(yilk-(yson-mesafe))*10);
                    		break;
            			}
            		}
            		//hipoten�s hesaplatma
            		else if(Math.pow((yilk-(yson-mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)>Math.pow(robot.getKolUzunlugu(), 2))
            		{
                		System.out.println("Kol istenilen mesafeye eri�emedi�i i�in y�k ta��namaz.");
	               		System.out.println("Ta��mas� i�in gereken kol mesafesi: " + Math.sqrt(Math.pow((yilk-(yson-mesafe))*10, 2)+Math.pow((xson-xilk)*10, 2)));
                		break;
            		}
            		
        			if(yson-mesafe<=0)
            		{
            			System.out.println("Haritadan d��ar�ya ��k�lamaz!");
                		�zgara.setSonX(xson);
                		�zgara.setSonY(yson);
                    	�zgara.repaint();
                		break;
            		}

            		yson-=mesafe;
	        		�zgara.setSonX(xson);
	        		�zgara.setSonY(yson);
	        		�zgara.repaint();
	        		maniYol += mesafe;        		
            	}
        	}	        	        	        	       	

			
			/*System.out.println("Yol: " + maniYol);
			System.out.println("X: " + xson);
			System.out.println("Y: " + yson);*/
			
			�zgara.setSonX(xson);
			�zgara.setSonY(yson);
			�zgara.repaint();
		}
		//Hesaplamalar�n sonu
		float sure = sure1 + maniYol*10*robot.getTasimaHizi();
		System.out.println("Topla S�re: " + sure + " saniye");	
	}	
}
