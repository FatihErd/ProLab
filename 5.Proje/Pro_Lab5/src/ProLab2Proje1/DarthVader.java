package ProLab2Proje1;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Queue;

public class DarthVader extends Karakter {
	
	public DarthVader(int x, int y, String ad, String turu) {
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
	
	private static boolean ziyaretEdildiMi(int mat[][], boolean visited[][], int satir, int sutun, int diziSatiri, int diziSutunu) 
	{
		return (satir >= 0) && (satir < diziSatiri) && (sutun >= 0) && (sutun < diziSutunu)
				&& (mat[satir][sutun] == 1 || mat[satir][sutun] == 0) && !visited[satir][sutun];
	}
	
	@Override
	public ArrayList<Dugum> EnKisaYol(int mat[][], int i, int j, int x, int y, int diziSatiri, int diziSutunu) 
	{
		ArrayList<Dugum> yedekYol = new ArrayList<Dugum>();
		int satir[] = { -1, 0, 0, 1 };
		int sutun[] = { 0, -1, 1, 0 };

		boolean[][] ziyaret = new boolean[diziSatiri][diziSutunu];

		// boþ bir sýra oluþturun
		Queue<Dugum> q = new ArrayDeque<>();

		// kaynak hücreyi ziyaret edildiði gibi iþaretle ve kuyruða ekle
		ziyaret[i][j] = true;
		q.add(new Dugum(i, j, 0));

		// kaynaktan hedefe en uzun yolun uzunluðunu saklar
		int enKisaYol = Integer.MAX_VALUE;

		// sýra boþ olmayana kadar koþ
		while (!q.isEmpty()) 
		{
			Dugum node = q.poll();

			i = node.x;
			j = node.y;
			int kisaYolSayisi = node.kisaYolSayisi;
			yedekYol = (ArrayList<Dugum>) (node.getList()).clone();

			if (yedekYol.size() > 0)
				if ((yedekYol.get(yedekYol.size() - 1)).x != node.x
						|| (yedekYol.get(yedekYol.size() - 1)).y != node.y) {
					yedekYol.remove(yedekYol.size() - 1);
					yedekYol.add(new Dugum(i, j, 0));
				}

			// eðer hedef bulunursa, enKisaYol'u güncelle ve durdur
			if (i == x && j == y) {
				enKisaYol = kisaYolSayisi;
				break;
			}

			// mevcut hücreden tüm 4 olasý hareketi kontrol et ve yol ara
			for (int k = 0; k < 4; k++) 
			{
				if (ziyaretEdildiMi(mat, ziyaret, i + satir[k], j + sutun[k], diziSatiri, diziSutunu)) {
					ziyaret[i + satir[k]][j + sutun[k]] = true;

					Dugum dugum = new Dugum();
					dugum.x = i + satir[k];
					dugum.y = j + sutun[k];

					if (yedekYol.size() > (kisaYolSayisi))
						yedekYol.remove(yedekYol.size() - 1);
					yedekYol.add(dugum);

					Dugum eklenecek = new Dugum(i + satir[k], j + sutun[k], kisaYolSayisi + 1, yedekYol);
					q.add(eklenecek);
				}
			}
		}
		return yedekYol;
	}
}
