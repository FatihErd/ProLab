
public class HibritRobot extends GezginRobot implements ManipulatorRobot {

	private float yukTasimaKapasitesi, tasimaHizi, kolUzunlugu;
	private float sabitlenmeSuresi, yukGecisSuresi;
	private int uzuvSayisi;
	
	public HibritRobot() {
		super();
	}


	public HibritRobot(int motorSayisi, float tasiyacagiYukMiktari, String robotTipi, 
			float gezinmeHizi, float yukTasimaKapasitesi, float tasimaHizi, float kolUzunlugu,
			float sabitlenmeSuresi, float yukGecisSuresi) 
	{
		super(motorSayisi, tasiyacagiYukMiktari, robotTipi, gezinmeHizi);
		this.yukTasimaKapasitesi = yukTasimaKapasitesi;
		this.tasimaHizi = tasimaHizi;
		this.kolUzunlugu = kolUzunlugu;
		this.sabitlenmeSuresi = sabitlenmeSuresi;
		this.yukGecisSuresi = yukGecisSuresi;
	}
	
	public float EngelGecmeSuresiBul()
	{		    	
		if((super.getRobotTipi()).contains("paletli"))
			return super.getMotorSayisi()*3;
		else if((super.getRobotTipi()).contains("tekerlekli"))
			return (float) (super.getMotorSayisi()*0.5);
		else
			return 0;
	}

	
	public int getUzuvSayisi() {
		return uzuvSayisi;
	}


	public void setUzuvSayisi(int uzuvSayisi) {
		this.uzuvSayisi = uzuvSayisi;
	}

	public float getSabitlenmeSuresi() {
		return sabitlenmeSuresi;
	}


	public void setSabitlenmeSuresi(float sabitlenmeSuresi) {
		this.sabitlenmeSuresi = sabitlenmeSuresi;
	}

	public float getYukGecisSuresi() {
		return yukGecisSuresi;
	}

	public void setYukGecisSuresi(float yukGecisSuresi) {
		this.yukGecisSuresi = yukGecisSuresi;
	}

	public float getYukTasimaKapasitesi() {
		return yukTasimaKapasitesi;
	}


	public void setYukTasimaKapasitesi(float yukTasimaKapasitesi) {
		this.yukTasimaKapasitesi = yukTasimaKapasitesi;
	}


	public float getTasimaHizi() {
		return tasimaHizi;
	}


	public void setTasimaHizi(float tasimaHizi) {
		this.tasimaHizi = tasimaHizi;
	}


	public float getKolUzunlugu() {
		return kolUzunlugu;
	}
	
	public void setKolUzunlugu(float kolUzunlugu) {
		this.kolUzunlugu = kolUzunlugu;
	}
	
}
