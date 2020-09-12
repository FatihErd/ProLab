import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.HeadlessException;
import javax.swing.JFrame;


public class Izgaralar extends JFrame {
	
	private int[] dizix;
	private int[] diziy;
	private int xRobot, yRobot, sonX, sonY, maniSabitX=0, maniSabitY=0;;
	
	public Izgaralar(){
		
	}
	
	public int getManiSabitX() {
		return maniSabitX;
	}

	public void setManiSabitX(int maniSabitX) {
		this.maniSabitX = maniSabitX;
	}

	public int getManiSabitY() {
		return maniSabitY;
	}

	public void setManiSabitY(int maniSabitY) {
		this.maniSabitY = maniSabitY;
	}

	public int getSonX() {
		return sonX;
	}


	public void setSonX(int sonX) {
		this.sonX = sonX;
	}


	public int getSonY() {
		return sonY;
	}


	public void setSonY(int sonY) {
		this.sonY = sonY;
	}


	public int[] getDizix() {
		return dizix;
	}


	public void setDizix(int[] dizix) {
		this.dizix = dizix;
	}

	public int[] getDiziy() {
		return diziy;
	}

	public void setDiziy(int[] diziy) {
		this.diziy = diziy;
	}
	
	public int getxRobot() {
		return xRobot;
	}

	public void setxRobot(int xRobot) {
		this.xRobot = xRobot;
	}


	public int getyRobot() {
		return yRobot;
	}


	public void setyRobot(int yRobot) {
		this.yRobot = yRobot;
	}

	public Izgaralar(int[] dizix, int[] diziy) throws HeadlessException {
		super();
		this.dizix = dizix;
		this.diziy = diziy;
	}

	public void paint (Graphics g) {
		
		super.paint(g);
		
		g.drawString("SAÐ", 126, 90);
		g.drawLine(100, 85, 125, 85);
		g.drawLine(120, 80, 125, 85);
		g.drawLine(120, 90, 125, 85);
		
		
		g.drawString("SOL", 576,90);
		g.drawLine(550, 85, 575, 85);
		g.drawLine(555, 80, 550, 85);
		g.drawLine(555, 90, 550, 85);
		
		g.drawString("ÝLERÝ", 65,115);
		g.drawLine(80, 120, 80, 145);
		g.drawLine(80, 145, 85, 140);
		g.drawLine(80, 145, 75, 140);
		
		g.drawString("GERÝ", 605,600);
		g.drawLine(615, 585, 615, 560);
		g.drawLine(615, 560, 610, 565);
		g.drawLine(615, 560, 620, 565);
				
		g.drawRect(100, 100, 500, 500);
		
		g.drawLine(125, 100, 125, 600);
		g.drawLine(125, 100, 125, 600);
		g.drawLine(150, 100, 150, 600);
		g.drawLine(175, 100, 175, 600);
		g.drawLine(200, 100, 200, 600);
		g.drawLine(225, 100, 225, 600);
		g.drawLine(250, 100, 250, 600);
		g.drawLine(275, 100, 275, 600);
		g.drawLine(300, 100, 300, 600);
		g.drawLine(325, 100, 325, 600);
		g.drawLine(350, 100, 350, 600);
		g.drawLine(375, 100, 375, 600);
		g.drawLine(400, 100, 400, 600);
		g.drawLine(425, 100, 425, 600);
		g.drawLine(450, 100, 450, 600);
		g.drawLine(475, 100, 475, 600);
		g.drawLine(500, 100, 500, 600);
		g.drawLine(525, 100, 525, 600);
		g.drawLine(550, 100, 550, 600);
		g.drawLine(575, 100, 575, 600);
				
		//yatay
		g.drawLine(100, 125, 600, 125);
		g.drawLine(100, 150, 600, 150);
		g.drawLine(100, 175, 600, 175);
		g.drawLine(100, 200, 600, 200);
		g.drawLine(100, 225, 600, 225);
		g.drawLine(100, 250, 600, 250);
		g.drawLine(100, 275, 600, 275);
		g.drawLine(100, 300, 600, 300);
		g.drawLine(100, 325, 600, 325);
		g.drawLine(100, 350, 600, 350);
		g.drawLine(100, 375, 600, 375);
		g.drawLine(100, 400, 600, 400);
		g.drawLine(100, 425, 600, 425);
		g.drawLine(100, 450, 600, 450);
		g.drawLine(100, 475, 600, 475);
		g.drawLine(100, 500, 600, 500);
		g.drawLine(100, 525, 600, 525);
		g.drawLine(100, 550, 600, 550);
		g.drawLine(100, 575, 600, 575);
		
		g.setFont(new Font("TimesRoman", Font.BOLD, 15));
		g.setColor(Color.GREEN);
		g.drawString("GEZGÝN ROBOT ÝLK KONUM", 112, 620);
		g.fillRect(100, 610, 10, 10);
				
		g.setColor(Color.RED);
		g.drawString("ENGEL", 112, 635);
		g.fillRect(100, 625, 10, 10);
			
		g.setColor(Color.BLUE);
		g.drawString("YÜK", 112, 650);
		g.fillRect(100, 640, 10, 10);
		
		g.setColor(Color.ORANGE);
		g.drawString("MANÝPÜLATÖR ROBOT", 112, 665);
		g.fillRect(100, 655, 10, 10);
		
		//araka plan
		getContentPane().setBackground(Color.white);		
		
		// ilk konum 
		g.setColor(Color.GREEN);
		if(xRobot != 0 && yRobot!=0)
			g.fillRect((105+(this.xRobot-1)*25), (105+(this.yRobot-1)*25), 15, 15);
		
		//Son Konum
		g.setColor(Color.BLUE);
		if(sonX!=0 && sonY!=0)
			g.fillRect((105+(this.sonX-1)*25), (105+(this.sonY-1)*25), 15, 15);
		
		g.setColor(Color.ORANGE);
		if(maniSabitX!=0 && maniSabitY!=0)
			g.fillRect((105+(this.maniSabitX-1)*25), (105+(this.maniSabitY-1)*25), 15, 15);
		
		for(int i=0;i<dizix.length;i++){
			g.setColor(Color.RED);
			if(dizix[i]!=0 && diziy[i]!=0)
				g.fillRect((105+(this.dizix[i]-1)*25),(105+(this.diziy[i]-1)*25), 15, 15);
		}

	}
}
