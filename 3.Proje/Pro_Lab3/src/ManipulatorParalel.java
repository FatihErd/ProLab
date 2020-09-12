
public class ManipulatorParalel implements ManipulatorRobot {
	
	
	private int motorSayisi;
	private float tasiyacagiYukMiktari;
	private String robotTipi;
	private float yukTasimaKapasitesi, tasimaHizi, kolUzunlugu;
	
	
	public ManipulatorParalel() {
		
	}
	
	public ManipulatorParalel(int motorSayisi, String robotTipi, 
			float yukTasimaKapasitesi, float tasimaHizi, float kolUzunlugu) 
	{
		this.motorSayisi = motorSayisi;
		this.robotTipi = robotTipi;
		this.yukTasimaKapasitesi = yukTasimaKapasitesi;
		this.tasimaHizi = tasimaHizi;
		this.kolUzunlugu = kolUzunlugu;
	}

	public float getYukTasimaKapasitesi() {
		// TODO Auto-generated method stub
		return yukTasimaKapasitesi;
	}

	public void setYukTasimaKapasitesi(float yukTasimaKapasitesi) {
		// TODO Auto-generated method stub
		this.yukTasimaKapasitesi = yukTasimaKapasitesi;
	}
	
	public float getTasimaHizi() {
		// TODO Auto-generated method stub
		return tasimaHizi;
	}

	public void setTasimaHizi(float tasimaHizi) {
		// TODO Auto-generated method stub
		this.tasimaHizi = tasimaHizi;
	}

	public float getKolUzunlugu() {
		// TODO Auto-generated method stub
		return kolUzunlugu;
	}
	
	public void setKolUzunlugu(float kolUzunlugu) {
		// TODO Auto-generated method stub
		this.kolUzunlugu = kolUzunlugu;
	}
	
	public int getMotorSayisi() {
		// TODO Auto-generated method stub
		return motorSayisi;
	}

	public void setMotorSayisi(int motorSayisi) {
		// TODO Auto-generated method stub
		this.motorSayisi = motorSayisi;
	}

	public float getTasiyacagiYukMiktari() {
		// TODO Auto-generated method stub
		return tasiyacagiYukMiktari;
	}
	
	public void setTasiyacagiYukMiktari(float tasiyacagiYukMiktari) {
		// TODO Auto-generated method stub
		this.tasiyacagiYukMiktari = tasiyacagiYukMiktari;
	}

	
	public String getRobotTipi() {
		// TODO Auto-generated method stub
		return robotTipi;
	}

	
	public void setRobotTipi(String robotTipi) {
		// TODO Auto-generated method stub
		this.robotTipi = robotTipi;
	}
}
