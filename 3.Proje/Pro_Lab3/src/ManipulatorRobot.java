
public interface ManipulatorRobot extends Robot{

	public float getYukTasimaKapasitesi();

	public void setYukTasimaKapasitesi(float yukTasimaKapasitesi) ;

	public float getTasimaHizi() ;

	public void setTasimaHizi(float tasimaHizi) ;

	public float getKolUzunlugu() ;

	public void setKolUzunlugu(float kolUzunlugu);

	@Override
	public int getMotorSayisi() ;


	@Override
	public void setMotorSayisi(int motorSayisi) ;


	@Override
	public float getTasiyacagiYukMiktari();


	@Override
	public void setTasiyacagiYukMiktari(float tasiyacagiYukMiktari) ;


	@Override
	public String getRobotTipi() ;


	@Override
	public void setRobotTipi(String robotTipi) ;

}
