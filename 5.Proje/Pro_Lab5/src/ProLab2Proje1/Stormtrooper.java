package ProLab2Proje1;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Queue;

public class Stormtrooper extends Karakter{
	
	public Stormtrooper(int x, int y, String ad, String turu) {
		super(ad, turu, x, y);
		// TODO Auto-generated constructor stub
	}
	
	public int getX(){
		return super.getKoordinatX();
	}
	
	public void setX(int x) {
		super.setKoordinatX(x);
	}
	
	public int getY(){
		return super.getKoordinatY();
	}
	
	public void setY(int y) {
		super.setKoordinatY(y);
	}
	
	public void EnKisaYol() 
	{
		
	}
}
