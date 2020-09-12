using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rezervasyon
{
    class KullaniciDugumu : AgacDugumu
    {
        public string Isim;

        public KullaniciDugumu(string isim) : base()
        {
            Turu = DugumTuru.Kullanici;
            Isim = isim;
        }


        public override string ToString()
        {
            return "Kullanici: " + Isim;
        }


    }
}
