using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rezervasyon
{
    class Program
    {
        public static KategoriDugumu kokDugum;
        static void Main(string[] args)
        {
            //Agaci olusturma
            kokDugum = new KategoriDugumu("Rezervasyon");//kök dügüm ataması
            //Dosyadan okuma
            string[] satirlar = File.ReadAllLines("rezervasyon.txt");//satirlarin diziler halinde alınması
            foreach (var satir in satirlar)//satirlari satira at
                SatirIsle(satir);

            AgacYazdir(kokDugum);
            Console.ReadLine();
            Console.Clear();

            Bastan:
            Console.Write("Bulmak İstediginiz Kategori Giriniz:");
            string kategori = Console.ReadLine();
            if (!KategoriBulYazdir(kokDugum, kategori))
            {
                Console.WriteLine("Aradığınız kategori bulunamadı...\n");
                goto Bastan;
            }

            Secim:
            int yeni;
            Console.WriteLine("\n1.Alt kategori ekle" +
                              "\n2.Mevcut kategoriyi silmek\n3.Geri gel");
            Console.Write("Seçim:");
            yeni = Convert.ToInt32(Console.ReadLine());
            if (yeni == 1)
            {
                var kategoritut = KategoriBul(kokDugum, kategori);            
                Console.WriteLine(kategoritut.GetYol());
                Console.Write("Alt kategori giriniz:");

                string altkategori = Console.ReadLine();

                bool varmi = false;
                foreach (var c in kategoritut.Cocuklar)
                    if (c.Turu == DugumTuru.Kategori)
                        if (altkategori.ToLowerInvariant() == ((KategoriDugumu)c).Isim.ToLowerInvariant())
                            varmi = true;
                if (varmi)
                {
                    Console.WriteLine("Alt kategori zaten var!");
                }
                else
                {
                    var yeniKategori = new KategoriDugumu(altkategori);
                    kategoritut.CocukEkle(yeniKategori);
                    AgacYazdir(kokDugum);
                }
                Console.WriteLine("Başka işlem yaptıracak mısınız? (e/h)");
                char tercih = (char)Console.Read();
                if (tercih == 'e')
                    goto Bastan;
            }
            if (yeni == 2)
            {
                KategoriBulSil(kokDugum, kategori);
                AgacYazdir(kokDugum);
                Console.WriteLine("Başka işlem yaptıracak mısınız? (e/h)");
                char tercih = (char)Console.Read();
                if (tercih == 'e')
                    goto Bastan;
            }
            if (yeni == 3)
                goto Bastan;
            if(yeni > 3 || yeni <= 0)
            {
                Console.WriteLine("Yanlış seçim yaptınız! Lütfen tekrar giriniz;");
                goto Secim;
            }

            Console.ReadLine();

        }

        public static void SatirIsle(string satir)
        {
            var vars = satir.Split(new[] { ',' });//var deikenini tanır ,gelen , gördükce dizlerini ayırır 

            KullaniciDugumu kullanici = new KullaniciDugumu(vars[0]);//ilk oknan kullanıcı ismi atanır
            RezervasyonDugumu rez = new RezervasyonDugumu(vars[1], vars[2], vars[3], vars[4], vars[5]);

            var kategori = KategoriBulYoksaEkle(kokDugum, vars[6]);
            kategori.CocukEkle(kullanici);//verileri bir birine bağlama
            kullanici.CocukEkle(rez);
        }

        public static KategoriDugumu KategoriBulYoksaEkle(KategoriDugumu ana, string text)
        {
            string org_text = text;
            string eslesme;
            if (!text.Contains(':'))//: nokta yoksa 
            {
                eslesme = text;
                text = null;
            }
            else
            {
                eslesme = text.Split(new char[] { ':' })[0];
                int index = text.IndexOf(':');
                text = text.Remove(0, index + 1);
            }

            foreach (var c in ana.Cocuklar)
            {
                if (c.Turu == DugumTuru.Kategori)
                {
                    KategoriDugumu cocuk = (KategoriDugumu)c;

                    if (cocuk.Isim.ToLower() == eslesme.ToLower())
                    {
                        if (string.IsNullOrEmpty(text))
                            return cocuk;
                        else
                            return KategoriBulYoksaEkle(cocuk, text);
                    }
                }
            }

            ana.CocukEkle(new KategoriDugumu(eslesme));
            return KategoriBulYoksaEkle(ana, org_text);
        }

        public static void AgacYazdir(AgacDugumu dal, int derinlik = 0)
        {
            for (int i = 0; i < derinlik; i++)
                Console.Write("  ");

            Console.WriteLine(dal.ToString());
            int count = 0;
            foreach (var cocuk in dal.Cocuklar)
            {
                AgacYazdir(cocuk, derinlik + 1);


                count++;
                if (count == 200)
                {
                    Console.WriteLine("Devam etmek icin bir tusa basiniz...");
                    Console.Read();
                    count = 0;
                }
            }
        }

        public static bool KategoriBulYazdir(KategoriDugumu ana, string isim)
        {
            foreach (var c in ana.Cocuklar)
            {
                if (c.Turu != DugumTuru.Kategori)
                    continue;
                KategoriDugumu cocuk = (KategoriDugumu)c;//türü bilindiği için cast et

                if (cocuk.Isim.ToLower() == isim.ToLower())
                {
                    AgacYazdir(cocuk);
                    return true;
                }
            }

            //Kategorlerde bulunamadı, altındaki kategorilere bak
            for (int i = 0; i < ana.Cocuklar.Count; i++)
                if (ana.Cocuklar[i].Turu == DugumTuru.Kategori)
                    if (KategoriBulYazdir((KategoriDugumu)ana.Cocuklar[i], isim))
                        return true;
            return false;
        }

        public static KategoriDugumu KategoriBul(KategoriDugumu ana, string isim)
        {
            foreach (var c in ana.Cocuklar)
            {
                if (c.Turu != DugumTuru.Kategori)
                    continue;
                KategoriDugumu cocuk = (KategoriDugumu)c;

                if (cocuk.Isim.ToLower() == isim.ToLower())
                {
                    return cocuk;
                }
            }
            KategoriDugumu ret = null;
            //Kategorlerde bulunamadı, altındaki kategorilere bak
            for (int i = 0; i < ana.Cocuklar.Count; i++)
                if (ana.Cocuklar[i].Turu == DugumTuru.Kategori)
                    if (ret == null)
                        ret = KategoriBul((KategoriDugumu)ana.Cocuklar[i], isim);

            return ret;
        }

        public static void KategoriBulSil(KategoriDugumu ana, string isim)
        {
            foreach (var c in ana.Cocuklar)
            {
                if (c.Turu != DugumTuru.Kategori)
                    continue;
                KategoriDugumu cocuk = (KategoriDugumu)c;

                if (cocuk.Isim.ToLower() == isim.ToLower())
                {
                    KategoriSil(cocuk);
                    return;
                }
            }

            //Kategorlerde bulunamadı, altındaki kategorilere bak
            for (int i = 0; i < ana.Cocuklar.Count; i++)
                if (ana.Cocuklar[i].Turu == DugumTuru.Kategori)
                    KategoriBulSil((KategoriDugumu)ana.Cocuklar[i], isim);
        }

        public static void KategoriSil(KategoriDugumu dugum)
        {
            foreach (var cocuk in dugum.Cocuklar)
            {
                if (cocuk.Turu == DugumTuru.Kategori)
                {
                    //Tasi
                    cocuk.Ana = dugum.Ana;
                    dugum.Ana.Cocuklar.Add(cocuk);
                }
            }
            dugum.Cocuklar.Clear();
            dugum.Ana.Cocuklar.Remove(dugum);
        }


    }
}
