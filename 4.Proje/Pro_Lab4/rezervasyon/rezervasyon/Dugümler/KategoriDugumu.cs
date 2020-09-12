using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rezervasyon
{
    public class KategoriDugumu : AgacDugumu
    {
        public string Isim;


        public KategoriDugumu(string isim) : base()
        {
            Turu = DugumTuru.Kategori;
            Isim = isim;
        }


        public override string ToString()
        {
            return "Kategori: " + Isim;
        }


        public string GetYol()
        {
            if (Ana == null || Ana.Turu != DugumTuru.Kategori)
                return Isim;

            return (Ana as KategoriDugumu).GetYol() + ":" + Isim;
        }
    }
}
