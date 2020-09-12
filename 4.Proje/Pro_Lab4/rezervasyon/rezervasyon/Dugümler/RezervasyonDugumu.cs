using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rezervasyon
{
    class RezervasyonDugumu : AgacDugumu
    {
        public string Yer, Zaman, Enlem, Boylam, Sehir;

        public RezervasyonDugumu(string yer, string zaman, string enlem, string boylam, string sehir) : base()
        {
            Turu = DugumTuru.Rezervasyon;
            Yer = yer;
            Zaman = zaman;
            Enlem = enlem;
            Boylam = boylam;
            Sehir = sehir;
        }


        public override string ToString()
        {
            return "Rezervasyon: " + Yer + ", " + Zaman + ", " + Enlem + ", " + Boylam + ", "  + Sehir;
        }
    }
}
