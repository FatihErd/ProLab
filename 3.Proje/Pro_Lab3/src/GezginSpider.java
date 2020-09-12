
public class GezginSpider extends GezginRobot {
	
	private int bacakSayisi;

	public int getBacakSayisi() {
		return bacakSayisi;
	}

	public void setBacakSayisi(int bacakSayisi) {
		this.bacakSayisi = bacakSayisi;
	}
	
	public GezginSpider(){
		
	}

	public GezginSpider(int motorSayisi, float tasiyacagiYukMiktari,
			String robotTipi, float gezinmeHizi, int bacakSayisi) {
		super(motorSayisi, tasiyacagiYukMiktari, robotTipi, gezinmeHizi);
		this.bacakSayisi = bacakSayisi;
		// TODO Auto-generated constructor stub
	}

}
