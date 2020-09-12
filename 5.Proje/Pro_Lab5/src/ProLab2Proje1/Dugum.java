package ProLab2Proje1;

import java.util.ArrayList;

public class Dugum {

	int x, y, kisaYolSayisi;
	private ArrayList<Dugum> yol = new ArrayList<Dugum>();

	public Dugum() {

	}

	Dugum(int x, int y, int kisaYolSayisi) {
		this.x = x;
		this.y = y;
		this.kisaYolSayisi = kisaYolSayisi;
	}

	public Dugum(int x, int y, int kisaYolSayisi, ArrayList<Dugum> yol) {
		this.x = x;
		this.y = y;
		this.kisaYolSayisi = kisaYolSayisi;
		this.yol = yol;
	}

	public ArrayList<Dugum> getList() {
		return this.yol;
	}
}
