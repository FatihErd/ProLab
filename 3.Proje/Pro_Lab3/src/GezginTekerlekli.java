
public class GezginTekerlekli extends GezginRobot {
	private int tekerlekSayisi;
	
	public GezginTekerlekli(){
		
	}
	
	public GezginTekerlekli(int motorSayisi, float tasiyacagiYukMiktari,
			String robotTipi, float gezinmeHizi, int tekerlekSayisi) {
		super(motorSayisi, tasiyacagiYukMiktari, robotTipi, gezinmeHizi);
		this.tekerlekSayisi = tekerlekSayisi;
	}
	
	public int getTekerlekSayisi() {
		return tekerlekSayisi;
	}

	
	public void setTekerlekSayisi(int tekerlekSayisi) {
		this.tekerlekSayisi = tekerlekSayisi;
	}

	public float EngelGecmeSuresi(){
		return (float) (super.getMotorSayisi()*0.5);
	}

}
