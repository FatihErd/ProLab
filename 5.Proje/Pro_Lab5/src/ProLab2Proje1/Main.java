package ProLab2Proje1;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

public class Main extends JFrame {
	private Image dbImage;
	private Graphics dbg;
	static ArrayList harita = new ArrayList<String[]>();
	int[][] matris = list2Int(harita);
	
	static Karakter[] kotuKarakterler;
	static Karakter iyiKarakter;
	ArrayList<Dugum> yol = new ArrayList<Dugum>();
	long zamanBasla, zamanBit, gecenZaman;
	double topZaman;

	public class AL extends KeyAdapter {

		public void keyPressed(KeyEvent e) {
			int[] satirSutun = new int[2];
			satirSutun = satirSutunOgren(harita);
			int keyCode = e.getKeyCode();
			switch (keyCode) {
			case KeyEvent.VK_UP:
				if (matris[iyiKarakter.getKoordinatY() - 1][iyiKarakter.getKoordinatX()] == 1) {
				if ((101 + (iyiKarakter.getKoordinatY() * 30)) > 130) {
					if (matris[iyiKarakter.getKoordinatY() - 1][iyiKarakter.getKoordinatX()] == 1) {
						iyiKarakter.setKoordinatY(iyiKarakter.getKoordinatY() - 1);
					}
				}
				if(iyiKarakter.getKoordinatX() == 13 && iyiKarakter.getKoordinatY()==9)
				{
					//KAZANDINIZ
					JOptionPane.showMessageDialog(rootPane, "Kazandýnýz");
					System.exit(0);
				}
				for (int j = 0; j < kotuKarakterler.length; j++) {
					zamanBasla = System.nanoTime();
					if (kotuKarakterler[j].getAd().equals("Stormtrooper")) 
					{
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Darth Vader")) 
					{
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Kylo Ren")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
							yol = kotuKarakterler[j].EnKisaYol(matris,
									kotuKarakterler[j].getKoordinatY(),
									kotuKarakterler[j].getKoordinatX(),
									iyiKarakter.getKoordinatY(),
									iyiKarakter.getKoordinatX(), satirSutun[0],
									satirSutun[1]);
							if (yol.get(0).y == iyiKarakter.getKoordinatX()
									&& yol.get(0).x == iyiKarakter
											.getKoordinatY()) {
								kotuKarakterler[j].setKoordinatX(yol.get(0).y);
								kotuKarakterler[j].setKoordinatY(yol.get(0).x);
							} 
							else {
								kotuKarakterler[j].setKoordinatX(yol.get(1).y);
								kotuKarakterler[j].setKoordinatY(yol.get(1).x);
							}
						}

					}
					zamanBit = System.nanoTime();
					gecenZaman = zamanBit - zamanBasla;
			        topZaman = (double) gecenZaman / 1000000; 
			        System.out.println(kotuKarakterler[j].getAd() + ": " + topZaman + " ms");
					if(kotuKarakterler[j].getKoordinatX() == iyiKarakter.getKoordinatX() && kotuKarakterler[j].getKoordinatY() == iyiKarakter.getKoordinatY())
					{
						if(iyiKarakter.getAd().equals("Luke Skywalker"))
						{
							((LukeSkywalker)iyiKarakter).setcanDegeri(1);
							if(((LukeSkywalker)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}	
							else
							{
								dispose();
								sifirla(((LukeSkywalker)iyiKarakter).getcanDegeri());
								break;
							}
						}
						else
						{
							((MasterYoda)iyiKarakter).setcanDegeri(1);
							if(((MasterYoda)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}			
							else
							{
								dispose();
								sifirla(((MasterYoda)iyiKarakter).getcanDegeri());
								break;
							}
						}
					}
				}}
				break;
			case KeyEvent.VK_DOWN:
				if (matris[iyiKarakter.getKoordinatY() + 1][iyiKarakter.getKoordinatX()] == 1) {
				if ((101 + (iyiKarakter.getKoordinatY() * 30)) < 400) {
					if (matris[iyiKarakter.getKoordinatY() + 1][iyiKarakter.getKoordinatX()] == 1) {
						iyiKarakter.setKoordinatY(iyiKarakter.getKoordinatY() + 1);
					}
				}
				if(iyiKarakter.getKoordinatX() == 13 && iyiKarakter.getKoordinatY()==9)
				{
					//KAZANDINIZ
					JOptionPane.showMessageDialog(rootPane, "Kazandýnýz");
					System.exit(0);
				}
				for (int j = 0; j < kotuKarakterler.length; j++) {
					zamanBasla = System.nanoTime();
					if (kotuKarakterler[j].getAd().equals("Stormtrooper")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Darth Vader")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Kylo Ren")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						
						if(yol.get(0).y == iyiKarakter.getKoordinatX() && yol.get(0).x == iyiKarakter.getKoordinatY())
						{
							kotuKarakterler[j].setKoordinatX(yol.get(0).y);
							kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
						else
						{
							kotuKarakterler[j].setKoordinatX(yol.get(1).y);
							kotuKarakterler[j].setKoordinatY(yol.get(1).x);
						}
						}
					}
					zamanBit = System.nanoTime();
					gecenZaman = zamanBit - zamanBasla;
			        topZaman = (double) gecenZaman / 1000000;  
			        System.out.println(kotuKarakterler[j].getAd() + ": " + topZaman + " ms");
					if(kotuKarakterler[j].getKoordinatX() == iyiKarakter.getKoordinatX() && kotuKarakterler[j].getKoordinatY() == iyiKarakter.getKoordinatY())
					{
						if(iyiKarakter.getAd().equals("Luke Skywalker"))
						{
							((LukeSkywalker)iyiKarakter).setcanDegeri(1);
							if(((LukeSkywalker)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}	
							else
							{
								dispose();
								sifirla(((LukeSkywalker)iyiKarakter).getcanDegeri());
								break;
							}
						}
						else
						{
							((MasterYoda)iyiKarakter).setcanDegeri(1);
							if(((MasterYoda)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}			
							else
							{
								dispose();
								sifirla(((MasterYoda)iyiKarakter).getcanDegeri());
								break;
							}
						}
					}
				}}
				break;
			case KeyEvent.VK_RIGHT:
				if (matris[iyiKarakter.getKoordinatY()][iyiKarakter.getKoordinatX() + 1] == 1){
				if ((101 + (iyiKarakter.getKoordinatX() * 30)) < 490) {
					if (matris[iyiKarakter.getKoordinatY()][iyiKarakter.getKoordinatX() + 1] == 1){

						iyiKarakter.setKoordinatX(iyiKarakter.getKoordinatX() + 1);
					}
				}
				if(iyiKarakter.getKoordinatX() == 13 && iyiKarakter.getKoordinatY()==9)
				{
					//KAZANDINIZ
					JOptionPane.showMessageDialog(rootPane, "Kazandýnýz");
					System.exit(0);
				}
				for (int j = 0; j < kotuKarakterler.length; j++) {
					zamanBasla = System.nanoTime();
					if (kotuKarakterler[j].getAd().equals("Stormtrooper")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Darth Vader")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Kylo Ren")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						if(yol.get(0).y == iyiKarakter.getKoordinatX() && yol.get(0).x == iyiKarakter.getKoordinatY())
						{
							kotuKarakterler[j].setKoordinatX(yol.get(0).y);
							kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
						else
						{
							kotuKarakterler[j].setKoordinatX(yol.get(1).y);
							kotuKarakterler[j].setKoordinatY(yol.get(1).x);
						}
						}
					}
					zamanBit = System.nanoTime();
					gecenZaman = zamanBit - zamanBasla;
			        topZaman = (double) gecenZaman / 1000000;
			        System.out.println(kotuKarakterler[j].getAd() + ": " + topZaman + " ms");
					if(kotuKarakterler[j].getKoordinatX() == iyiKarakter.getKoordinatX() && kotuKarakterler[j].getKoordinatY() == iyiKarakter.getKoordinatY())
					{
						if(iyiKarakter.getAd().equals("Luke Skywalker"))
						{
							((LukeSkywalker)iyiKarakter).setcanDegeri(1);
							if(((LukeSkywalker)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}	
							else
							{
								dispose();
								sifirla(((LukeSkywalker)iyiKarakter).getcanDegeri());
								break;
							}
						}
						else
						{
							((MasterYoda)iyiKarakter).setcanDegeri(1);
							if(((MasterYoda)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}			
							else
							{
								dispose();
								sifirla(((MasterYoda)iyiKarakter).getcanDegeri());
								break;
							}
						}
					}
				}}
				break;
			case KeyEvent.VK_LEFT:
				if (matris[iyiKarakter.getKoordinatY()][iyiKarakter.getKoordinatX() - 1] == 1) {
				if ((101 + (iyiKarakter.getKoordinatX() * 30)) > 130) {
					if (matris[iyiKarakter.getKoordinatY()][iyiKarakter.getKoordinatX() - 1] == 1) {
						iyiKarakter.setKoordinatX(iyiKarakter.getKoordinatX() - 1);
					}
				}
				if(iyiKarakter.getKoordinatX() == 13 && iyiKarakter.getKoordinatY()==9)
				{
					//KAZANDINIZ
					JOptionPane.showMessageDialog(rootPane, "Kazandýnýz");
					System.exit(0);
				}
				for (int j = 0; j < kotuKarakterler.length; j++) {
					zamanBasla = System.nanoTime();
					if (kotuKarakterler[j].getAd().equals("Stormtrooper")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Darth Vader")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						kotuKarakterler[j].setKoordinatX(yol.get(0).y);
						kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
					}
					else if (kotuKarakterler[j].getAd().equals("Kylo Ren")) {
						if(kotuKarakterler[j].getKoordinatX() != iyiKarakter.getKoordinatX() || kotuKarakterler[j].getKoordinatY() != iyiKarakter.getKoordinatY())
						{
						yol = kotuKarakterler[j].EnKisaYol(matris, kotuKarakterler[j].getKoordinatY(),
								kotuKarakterler[j].getKoordinatX(), iyiKarakter.getKoordinatY(),
								iyiKarakter.getKoordinatX(), satirSutun[0], satirSutun[1]);
						if(yol.get(0).y == iyiKarakter.getKoordinatX() && yol.get(0).x == iyiKarakter.getKoordinatY())
						{
							kotuKarakterler[j].setKoordinatX(yol.get(0).y);
							kotuKarakterler[j].setKoordinatY(yol.get(0).x);
						}
						else
						{
							kotuKarakterler[j].setKoordinatX(yol.get(1).y);
							kotuKarakterler[j].setKoordinatY(yol.get(1).x);
						}
						}
					}
					zamanBit = System.nanoTime();
					gecenZaman = zamanBit - zamanBasla;
			        topZaman = (double) gecenZaman / 1000000;
			        System.out.println(kotuKarakterler[j].getAd() + ": " + topZaman + " ms");
					if(kotuKarakterler[j].getKoordinatX() == iyiKarakter.getKoordinatX() && kotuKarakterler[j].getKoordinatY() == iyiKarakter.getKoordinatY())
					{
						if(iyiKarakter.getAd().equals("Luke Skywalker"))
						{
							((LukeSkywalker)iyiKarakter).setcanDegeri(1);
							if(((LukeSkywalker)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}	
							else
							{
								dispose();
								sifirla(((LukeSkywalker)iyiKarakter).getcanDegeri());
								break;
							}
						}
						else
						{
							((MasterYoda)iyiKarakter).setcanDegeri(1);
							if(((MasterYoda)iyiKarakter).getcanDegeri()==0)
							{
								//GAME OVER
								JOptionPane.showMessageDialog(rootPane, "GAME OVER :(");
								System.exit(0);
							}			
							else
							{
								dispose();
								sifirla(((MasterYoda)iyiKarakter).getcanDegeri());
								break;
							}
						}
					}
				}}
				break;
			}
			System.out.println("\n");
			repaint();
		}
	}

	public Main() {
		addKeyListener(new AL());
		setSize(640, 640);
		setVisible(true);
		setLocationRelativeTo(null);
		setFocusable(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}

	public void paint(Graphics g) {
		dbImage = createImage(getWidth(), getHeight());
		dbg = dbImage.getGraphics();
		paintComponet(dbg);
		g.drawImage(dbImage, 0, 0, this);	
	}

	public void paintComponet(Graphics g) {
		g.drawRect(100, 100, 420, 330);
		// dikey
		g.drawLine(130, 100, 130, 430);
		g.drawLine(160, 100, 160, 430);
		g.drawLine(190, 100, 190, 430);
		g.drawLine(220, 100, 220, 430);
		g.drawLine(250, 100, 250, 430);
		g.drawLine(280, 100, 280, 430);
		g.drawLine(310, 100, 310, 430);
		g.drawLine(340, 100, 340, 430);
		g.drawLine(370, 100, 370, 430);
		g.drawLine(400, 100, 400, 430);
		g.drawLine(430, 100, 430, 430);
		g.drawLine(460, 100, 460, 430);
		g.drawLine(490, 100, 490, 430);

		// yatay
		g.drawLine(100, 130, 520, 130);
		g.drawLine(100, 160, 520, 160);
		g.drawLine(100, 190, 520, 190);
		g.drawLine(100, 220, 520, 220);
		g.drawLine(100, 250, 520, 250);
		g.drawLine(100, 280, 520, 280);
		g.drawLine(100, 310, 520, 310);
		g.drawLine(100, 340, 520, 340);
		g.drawLine(100, 370, 520, 370);
		g.drawLine(100, 400, 520, 400);

		// yolun çizilmesi
		for (int i = 0; i < matris.length; i++) {
			for (int j = 0; j < matris[0].length; j++) {
				if (matris[i][j] == 1) {
					g.setColor(Color.cyan);
					g.fillRect(101 + (j * 30), 101 + (i * 30), 29, 29);
				}
			}
		}
		repaint();

		// koyu mavi olan yerler
		g.setColor(Color.blue);
		g.fillRect(221, 101, 29, 29);
		g.fillRect(221, 401, 29, 29);
		g.fillRect(101, 251, 29, 29);
		g.fillRect(491, 251, 29, 29);
		g.fillRect(461, 101, 29, 29);

		for (int j = 0; j < kotuKarakterler.length; j++) {
			if (kotuKarakterler[j].getAd().equals("Darth Vader")) {
				g.setColor(Color.magenta);
				g.fillRect((101 + (kotuKarakterler[j].getKoordinatX() * 30)),
						(101 + (kotuKarakterler[j].getKoordinatY() * 30)), 29, 29);
			} 
			else if (kotuKarakterler[j].getAd().equals("Stormtrooper")) {
				g.setColor(Color.GREEN);
				g.fillRect((101 + (kotuKarakterler[j].getKoordinatX() * 30)),
						(101 + (kotuKarakterler[j].getKoordinatY() * 30)), 29, 29);
			} 
			else {
				g.setColor(Color.ORANGE);
				g.fillRect((101 + (kotuKarakterler[j].getKoordinatX() * 30)),
						(101 + (kotuKarakterler[j].getKoordinatY() * 30)), 29, 29);
			}
		}

		// en kýsa yol
		int[] satirSutun = new int[2];
		satirSutun = satirSutunOgren(harita);
		for (int j = 0; j < kotuKarakterler.length; j++) {
			if (kotuKarakterler[j].getAd().equals("Stormtrooper")) {
				yol = kotuKarakterler[j].EnKisaYol(matris,
						kotuKarakterler[j].getKoordinatY(),
						kotuKarakterler[j].getKoordinatX(),
						iyiKarakter.getKoordinatY(),
						iyiKarakter.getKoordinatX(), satirSutun[0],
						satirSutun[1]);
				for (Dugum dugum : yol) {
					g.setColor(Color.GREEN);
					g.fillRect((108 + (dugum.y) * 30), (108 + (dugum.x) * 30),
							15, 15);
				}
			} 
			else if (kotuKarakterler[j].getAd().equals("Darth Vader")) {
				yol = kotuKarakterler[j].EnKisaYol(matris,
						kotuKarakterler[j].getKoordinatY(),
						kotuKarakterler[j].getKoordinatX(),
						iyiKarakter.getKoordinatY(),
						iyiKarakter.getKoordinatX(), satirSutun[0],
						satirSutun[1]);
				for (Dugum dugum : yol) {
					g.setColor(Color.magenta);
					g.fillRect((108 + (dugum.y) * 30), (108 + (dugum.x) * 30),
							15, 15);

				}
			} 
			else if (kotuKarakterler[j].getAd().equals("Kylo Ren")) {
				yol = kotuKarakterler[j].EnKisaYol(matris,
						kotuKarakterler[j].getKoordinatY(),
						kotuKarakterler[j].getKoordinatX(),
						iyiKarakter.getKoordinatY(),
						iyiKarakter.getKoordinatX(), satirSutun[0],
						satirSutun[1]);
				for (Dugum dugum : yol) {
					g.setColor(Color.ORANGE);
					g.fillRect((108 + (dugum.y) * 30), (108 + (dugum.x) * 30),
							15, 15);
				}
			}
		}

		// karakterlerin tanýmý
		g.setColor(Color.yellow);
		g.fillRect(101, 440, 29, 29);
		g.setColor(Color.black);
		g.setFont(new Font("TimesRoman", Font.BOLD, 17));
		g.drawString("Ýyi Karakter", 140, 460);
		g.setColor(Color.ORANGE);
		g.fillRect(101, 480, 29, 29);
		g.setColor(Color.black);
		g.drawString("Kylo Ren", 140, 500);
		g.setColor(Color.MAGENTA);
		g.fillRect(101, 520, 29, 29);
		g.setColor(Color.black);
		g.drawString("Darth Vader", 140, 540);
		g.setColor(Color.GREEN);
		g.fillRect(101, 560, 29, 29);
		g.setColor(Color.black);
		g.drawString("Stormtrooper", 140, 580);
		
		g.setFont(new Font("TimesRoman", Font.BOLD, 15));
		g.setColor(Color.white);
		g.drawString("A", 113, 270);
		g.drawString("B", 231, 120);
		g.drawString("C", 472, 120);
		g.drawString("D", 501, 270);
		g.drawString("E", 231, 420);
		g.setColor(Color.black);
		g.drawString("Ç", 501, 390);

		
		if(iyiKarakter.getAd().equals("Luke Skywalker"))
		{
			g.setFont(new Font("TimesRoman", Font.BOLD, 17));
			g.drawString("CAN :", 400, 90);
			for(int i=0;i<(((LukeSkywalker)iyiKarakter).getcanDegeri());i++)
			{		
				g.setColor(Color.RED);
				g.fillOval(450+(i*20), 77, 15, 15 );
			}
		}
		else
		{
			g.setFont(new Font("TimesRoman", Font.BOLD, 17));
			g.drawString("CAN :", 350, 90);
			for(int i=0;i<(((MasterYoda)iyiKarakter).getcanDegeri());i++)
			{
				g.setColor(Color.RED);
				g.fillOval(400+(i*20), 77, 15, 15 );
			}
		}

		g.setColor(Color.yellow);
		g.fillRect((101 + (iyiKarakter.getKoordinatX() * 30)), (101 + (iyiKarakter.getKoordinatY() * 30)), 29, 29);

	}

	public static int karakterSay(ArrayList<String> karakterler) {
		int kotuKarakterSayisi = 0;
		for (String bas : karakterler)
			kotuKarakterSayisi++;
		return kotuKarakterSayisi;
	}

	public static int[][] list2Int(ArrayList<String[]> haritaCevir) {
		int[][] matris = new int[haritaCevir.size()][haritaCevir.get(0).length];
		for (int k = 0; k < haritaCevir.size(); k++) {
			for (int j = 0; j < haritaCevir.get(k).length; j++) {
				matris[k][j] = Integer.parseInt(haritaCevir.get(k)[j]);
			}
		}
		return matris;
	}

	public static int[] satirSutunOgren(ArrayList<String[]> haritaBas) {
		int[] satirSutun = new int[2];
		satirSutun[0] = haritaBas.size();
		satirSutun[1] = haritaBas.get(haritaBas.size() - 1).length;
		return satirSutun;
	}

	public static void sifirla(int can)
	{
		harita.clear();
		try {
			FileReader oku3 = new FileReader("Harita.txt");
			BufferedReader okuyucu3 = new BufferedReader(oku3);// satir satir okumasýný saðlýyor
			while (true) {
				String satir = okuyucu3.readLine();
				String[] dizi = satir.split(",");
				if(dizi[0].substring(9, dizi[0].length()).equals("Luke Skywalker"))
					iyiKarakter = new LukeSkywalker("Luke Skywalker", "iyi", 6, 5, can);
				else
					iyiKarakter = new MasterYoda("Master Yoda", "iyi", 6, 5, can);
				break;
			}
			okuyucu3.close();
			oku3.close();

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}		

		ArrayList karakterler = new ArrayList<String>();
		ArrayList kapilar = new ArrayList<String>();

		try {
			FileReader oku = new FileReader("Harita.txt");
			BufferedReader okuyucu = new BufferedReader(oku);// satir satir okumasýný saðlýyor
			char harf = 'H';
			String satir = okuyucu.readLine();
			while (true) {
				satir = okuyucu.readLine();
				harf = satir.charAt(0);
				if (harf == '0' || harf == '1') {
					break;
				}
				String[] dizi = satir.split(",");
				karakterler.add(dizi[0].substring(9, dizi[0].length()));
				kapilar.add(dizi[1].substring(5, dizi[1].length()));
			}
			okuyucu.close();
			oku.close();

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		int kotuKarakterSayisi = karakterSay(karakterler);
		kotuKarakterler = new Karakter[kotuKarakterSayisi];
		for (int j = 0; j < kotuKarakterSayisi; j++) {
			String karakterAd = (String) karakterler.get(j);
			String karakterKapi = (String) kapilar.get(j);
			int y, x;
			if (karakterKapi.equals("A")) {
				y = 5;
				x = 0;
			} else if (karakterKapi.equalsIgnoreCase("B")) {
				y = 0;
				x = 4;
			} else if (karakterKapi.equalsIgnoreCase("C")) {
				y = 0;
				x = 12;
			} else if (karakterKapi.equalsIgnoreCase("D")) {
				y = 5;
				x = 13;
			} else {
				y = 10;
				x = 4;
			}

			// Darth Vader
			if (karakterAd.equals("Darth Vader")) {
				kotuKarakterler[j] = new DarthVader(x, y, karakterAd, "kotu");
			}
			// Stormtrooper
			else if (karakterAd.equalsIgnoreCase("Stormtrooper")) {
				kotuKarakterler[j] = new Stormtrooper(x, y, karakterAd, "kotu");
			}
			// Kylo Ren
			else {
				kotuKarakterler[j] = new KyloRen(x, y, karakterAd, "kotu");
			}
		}

		try {
			char harf;
			FileReader oku2 = new FileReader("Harita.txt");
			BufferedReader okuyucu2 = new BufferedReader(oku2);// satir satirokumasýný saðlýyor

			int i = 0, satirSayici = 0, sutunSayici = 0;
			while (true) {
				String satir = okuyucu2.readLine();
				if (satir == null)
					break;
				harf = satir.charAt(0);
				if (harf != '0' && harf != '1') {
					continue;
				}
				String[] gecici = satir.split("\t");

				harita.add(gecici);
			}
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		int[] satirSutun = new int[2];
		satirSutun = satirSutunOgren(harita);

		new Main();
	}
	
	public static void main(String[] args) {

		int canSayi = 0;
		try {
			FileReader oku3 = new FileReader("Harita.txt");
			BufferedReader okuyucu3 = new BufferedReader(oku3);
			String satir = okuyucu3.readLine();
			String[] dizi = satir.split(",");
			if (dizi[0].substring(9, dizi[0].length()).equals("Luke Skywalker"))
				canSayi = 3;
			else
				canSayi = 6;

			okuyucu3.close();
			oku3.close();

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		sifirla(canSayi);
	}
}
