
public class GezginRobot implements Robot{
	private int motorSayisi;
	private float tasiyacagiYukMiktari;
	private String robotTipi;

	private float gezinmeHizi;
	
	public GezginRobot(){
		
	}

	public GezginRobot(int motorSayisi, float tasiyacagiYukMiktari,
			String robotTipi, float gezinmeHizi) {	
		this.motorSayisi = motorSayisi;
		this.tasiyacagiYukMiktari = tasiyacagiYukMiktari;
		this.robotTipi = robotTipi;
		this.gezinmeHizi = gezinmeHizi;

	}

	public float getGezinmeHizi() {
		return gezinmeHizi;
	}

	public void setGezinmeHizi(float gezinmeHizi) {
		this.gezinmeHizi = gezinmeHizi;
	}

	@Override
	public int getMotorSayisi(){
		return motorSayisi;
	}
		
	
	@Override
	public void setMotorSayisi(int motorSayisi) {
		// TODO Auto-generated method stub
		this.motorSayisi = motorSayisi;
	}

	@Override
	public float getTasiyacagiYukMiktari() {
		// TODO Auto-generated method stub
		return tasiyacagiYukMiktari;
	}

	@Override
	public void setTasiyacagiYukMiktari(float tasiyacagiYukMiktari) {
		// TODO Auto-generated method stub
		this.tasiyacagiYukMiktari = tasiyacagiYukMiktari;
	}

	@Override
	public String getRobotTipi() {
		// TODO Auto-generated method stub
		return robotTipi;
	}

	@Override
	public void setRobotTipi(String robotTipi) {
		// TODO Auto-generated method stub
		this.robotTipi = robotTipi;
	}

}
