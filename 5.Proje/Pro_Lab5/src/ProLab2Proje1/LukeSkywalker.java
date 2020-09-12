package ProLab2Proje1;

public class LukeSkywalker extends Karakter{
	int canDegeri;

	public LukeSkywalker(String ad, String turu, int x, int y, int canDegeri) {
		super(ad, turu, x, y);
		this.canDegeri = canDegeri;
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

	public int getcanDegeri() {
		return canDegeri;
	}

	public void setcanDegeri(int canDegeri) {
		this.canDegeri = this.canDegeri - canDegeri;
	}
	
}
