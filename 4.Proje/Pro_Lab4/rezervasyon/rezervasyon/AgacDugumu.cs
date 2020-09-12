using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rezervasyon
{
    public enum DugumTuru //tür 
    {
        Kategori,
        Kullanici,
        Rezervasyon
    }

    public class AgacDugumu
    {
        public DugumTuru Turu;
        public AgacDugumu Ana = null;
        public List<AgacDugumu> Cocuklar;
     

        public AgacDugumu()
        {
            Cocuklar = new List<AgacDugumu>();
        }

        public void  CocukEkle(AgacDugumu dugum)
        {
            Cocuklar.Add(dugum);
            dugum.Ana = this;
            
        }

        public int getCocukSayisi()
        {            
            return Cocuklar.Count;
        }
    }
}
