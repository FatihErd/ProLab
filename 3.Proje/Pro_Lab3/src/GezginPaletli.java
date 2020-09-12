
public class GezginPaletli extends GezginRobot {

	private int paletSayisi;

	public int getPaletSayisi() {
		return paletSayisi;
	}

	public void setPaletSayisi(int paletSayisi) {
		this.paletSayisi = paletSayisi;
	}
	
	public GezginPaletli(){
		
	}
	
	public GezginPaletli(int motorSayisi, float tasiyacagiYukMiktari,
			String robotTipi, float gezinmeHizi, int paletSayisi) {
		super(motorSayisi, tasiyacagiYukMiktari, robotTipi, gezinmeHizi);
		this.paletSayisi=paletSayisi;
	}
	
	public float EngelGecmeSuresiBul(){
		return super.getMotorSayisi()*3;
	}
}
