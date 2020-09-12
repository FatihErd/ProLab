using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace projedenemesi
{
    public partial class HammaddeEkle : Form
    {
        public HammaddeEkle()
        {
            InitializeComponent();
        }

         SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
         //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        bool durum = true;

        private void kayitKontrol()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM Hammaddeler";
            SqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                if (txtBirlesenKisitlama.Text == read["maddeKisaltma"].ToString())
                    durum = false;
            }
            baglanti.Close();
        }

        private bool kayitKontrolGuncelle(int id)
        {
            bool d = true;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM Hammaddeler WHERE maddeId <>" + id;
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (txtBirlesenKisitlama.Text == read["maddeKisaltma"].ToString())
                    d = false;
            }
            baglanti.Close();
            return d;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtBirlesenKisitlama.Text != null && txtMaddeAd.Text != "" && txtMaddeOmur.Text != "")
            {
                try
                {
                    kayitKontrol();
                    if (durum == true)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "INSERT INTO Hammaddeler(maddeKisaltma,maddeAd,maddeOmur)VALUES('" + txtBirlesenKisitlama.Text + "','" + txtMaddeAd.Text + "','" + Int32.Parse(txtMaddeOmur.Text) + "')";
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        baglanti.Close();
                        temizle();
                        listeleme();
                    }
                    else
                        MessageBox.Show("Var olan kayit eklenemez");
                    durum = true;
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                    durum = true;
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş bırakılamaz!");
            durum = true;
        }

        void listeleme()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    //  cmd.CommandText = "SELECT maddeKisaltma, maddeAd, maddeOmur FROM Hammaddeler";
                    cmd.CommandText = "SELECT * FROM Hammaddeler";
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpr.Fill(ds, "Hammaddeler");
                    dataGridView1.DataSource = ds.Tables["Hammaddeler"];
                    dataGridView1.Columns[3].Visible = false;
                    baglanti.Close();
                }
            }
            catch(Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }

        void temizle()
        {
            txtBirlesenKisitlama.Text = "";
            txtMaddeAd.Text = "";
            txtMaddeOmur.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listeleme();
            ///////////
            ///SİLME İŞLEMİ TARİHİ GEÇENLERİ
            ///
            /*try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;

                    //Seçilen firmanın elindeki ürünler
                    cmd.CommandText = "SELECT * FROM UreticiHammaddeler";
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpr.Fill(dt);
                    dataGridView2.DataSource = dt;
                    baglanti.Close();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
            string tarih;
            tarih = DateTime.Now.ToShortDateString();
            string[] dizi1 = tarih.Split('.', ' ', ',', '/');
            //label1.Text = dizi1[0];
            int sGun, sAy, sYil;
            sGun = Convert.ToInt32(dizi1[0]);
            sAy = Convert.ToInt32(dizi1[1]);
            sYil = Convert.ToInt32(dizi1[2]);
            int maddeO = 0;
            int say = 0;
            //hammadde stoktan atma
            while(say < dataGridView2.RowCount-1)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "Select DISTINCT maddeOmur From UreticiHammaddeler U, Hammaddeler H Where H.maddeId = U.maddeId AND H.maddeId = @a";
                cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dataGridView2.Rows[say].Cells[0].Value.ToString()));
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    maddeO = Int32.Parse(read["maddeOmur"].ToString());
                }
                baglanti.Close();

                string a;
                string kelime = dataGridView2.Rows[say].Cells[1].Value.ToString();
                char[] rakamlar = kelime.ToCharArray();
                string[] dizi = new string [3];
                dizi[0] = rakamlar[0].ToString() + rakamlar[1].ToString();
                dizi[1] = rakamlar[2].ToString() + rakamlar[3].ToString();
                dizi[2] = rakamlar[4].ToString() + rakamlar[5].ToString() + rakamlar[6].ToString() + rakamlar[7].ToString();

                a = string.Concat(dizi);

                int gGun = Convert.ToInt32(dizi[0]);
                int gAy = Convert.ToInt32(dizi[1]);
                int gYil = Convert.ToInt32(dizi[2]);
                bool kontrol=false;
                if (sYil - gYil > maddeO)
                {
                    kontrol = true;
                }
                if (sYil - gYil == maddeO)
                {
                    if (sAy - gAy >= 0)
                    {
                        if (sGun - gGun >= 0)
                        {
                            kontrol = true;
                        }
                    }
                }


                if (kontrol == true)
                {
                    ///zarar olarak işle
                    ///
                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO MusteriSiparis(musteriId,urunId,istenenMiktar,maliyet,urunSatisFiyati) VALUES "
                        + "(@a1, @a2, @a3, @a4, @a5)";
                    cmd.Parameters.AddWithValue("@a1", 1);
                    cmd.Parameters.AddWithValue("@a2", 6);
                    cmd.Parameters.AddWithValue("@a3", 0);
                    cmd.Parameters.AddWithValue("@a4", 0);
                    cmd.Parameters.AddWithValue("@a5", (-1)*Convert.ToDouble(dataGridView2.Rows[say].Cells[2].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();

                    //stoktan at
                    try
                    {
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = baglanti;
                            cmd.CommandText = "delete from UreticiHammaddeler where maddeId=@a1 AND maddeuretimtarihi = @a2 AND "
                                + "hammaddeMaliyet = @a3 AND hammaddeStok = @a4";
                            cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView2.Rows[say].Cells[0].Value.ToString()));
                            cmd.Parameters.AddWithValue("@a2", dataGridView2.Rows[say].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@a3", Convert.ToDouble(dataGridView2.Rows[say].Cells[2].Value.ToString()));
                            cmd.Parameters.AddWithValue("@a4", Convert.ToInt32(dataGridView2.Rows[say].Cells[3].Value.ToString()));
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            baglanti.Close();
                            temizle();
                            listeleme();
                        }
                    }
                    catch (Exception b)
                    {
                        MessageBox.Show(b.Message);
                        baglanti.Close();
                    }
                }

                say++;
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;

                    //Seçilen firmanın elindeki ürünler
                    cmd.CommandText = "SELECT * FROM UreticiKimyasallar";
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpr.Fill(dt);
                    dataGridView2.DataSource = dt;
                    baglanti.Close();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
            //Kimyasal stoktan atma
            while (say < dataGridView2.RowCount - 1)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "Select DISTINCT kimyasalOmur From KimyasalUrunler K, UreticiKimyasallar U Where U.urunId = K.urunId AND U.urunId = @a";
                cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dataGridView2.Rows[say].Cells[0].Value.ToString()));
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    maddeO = Int32.Parse(read["maddeOmur"].ToString());
                }
                baglanti.Close();

                string a;
                string kelime = dataGridView2.Rows[say].Cells[2].Value.ToString();
                char[] rakamlar = kelime.ToCharArray();
                string[] dizi = new string[3];
                dizi[0] = rakamlar[0].ToString() + rakamlar[1].ToString();
                dizi[1] = rakamlar[2].ToString() + rakamlar[3].ToString();
                dizi[2] = rakamlar[4].ToString() + rakamlar[5].ToString() + rakamlar[6].ToString() + rakamlar[7].ToString();

                a = string.Concat(dizi);

                int gGun = Convert.ToInt32(dizi[0]);
                int gAy = Convert.ToInt32(dizi[1]);
                int gYil = Convert.ToInt32(dizi[2]);
                bool kontrol = false;
                if (sYil - gYil > maddeO)
                {
                    kontrol = true;
                }
                if (sYil - gYil == maddeO)
                {
                    if (sAy - gAy >= 0)
                    {
                        if (sGun - gGun >= 0)
                        {
                            kontrol = true;
                        }
                    }
                }


                if (kontrol == true)
                {
                    ///zarar olarak işle
                    ///
                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO UreticiKimyasallar(urunId, kimyasalStok, kimyasaılUretimTarihi, toplamMaliyet) VALUES "
                        + "(@a1, @a2, @a3, @a4)";
                    cmd.Parameters.AddWithValue("@a1", 1);
                    cmd.Parameters.AddWithValue("@a2", 6);
                    cmd.Parameters.AddWithValue("@a3", 0);
                    cmd.Parameters.AddWithValue("@a4", 0);
                    cmd.Parameters.AddWithValue("@a5", (-1) * Convert.ToDouble(dataGridView2.Rows[say].Cells[3].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();

                    //stoktan at
                    try
                    {
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = baglanti;
                            cmd.CommandText = "delete from UreticiKimyasallar where urunId=@a1 AND kimyasalStok = @a2 AND "
                                + "kimyasaılUretimTarihi = @a3 AND toplamMaliyet = @a4";
                            cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView2.Rows[say].Cells[0].Value.ToString()));
                            cmd.Parameters.AddWithValue("@a2", Convert.ToInt32(dataGridView2.Rows[say].Cells[1].Value.ToString()));
                            cmd.Parameters.AddWithValue("@a3", dataGridView2.Rows[say].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@a4", Convert.ToDouble(dataGridView2.Rows[say].Cells[3].Value.ToString()));
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            baglanti.Close();
                            temizle();
                            listeleme();
                        }
                    }
                    catch (Exception b)
                    {
                        MessageBox.Show(b.Message);
                        baglanti.Close();
                    }
                }

                say++;
            }*/

        }
    

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from Hammaddeler where maddeId=@a";
                    cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    temizle();
                    listeleme();
                }
            }catch(Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBirlesenKisitlama.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtMaddeAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMaddeOmur.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            int id = Int32.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if (txtBirlesenKisitlama.Text != null && txtMaddeAd.Text != "" && txtMaddeOmur.Text != "")
            {
                try
                {
                    if (kayitKontrolGuncelle(id))
                    {
                        //güncellemede var olanı kontrol edemiyorum
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
                        cmd.CommandText = "UPDATE Hammaddeler SET maddeKisaltma='" + txtBirlesenKisitlama.Text + "',maddeAd = '" + txtMaddeAd.Text + "',maddeOmur = '" + Int32.Parse(txtMaddeOmur.Text) + "'where maddeId=@a";
                        cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        baglanti.Close();
                        listeleme();
                        temizle();
                    }
                    else
                        MessageBox.Show("Var olan değer güncellenemez");

                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                    baglanti.Close();
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş geçilemez!");
        }

        private void hammaddeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HammaddeEkle hammadde_ekle = new HammaddeEkle();
                hammadde_ekle.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void musterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MusterilerEkle musteri_ekle = new MusterilerEkle();
                musteri_ekle.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void kimyasalÜrünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KimyasalUrunEkle kimyasal_urun_ekle = new KimyasalUrunEkle();
                kimyasal_urun_ekle.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void musteriSiparisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MusteriSiparisVer musteri_siparisi_ver = new MusteriSiparisVer();
                musteri_siparisi_ver.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void sehirlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Sehirler sehirler = new Sehirler();
                sehirler.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void tedarikcilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TedarikciEkle tedarikci_ekle = new TedarikciEkle();
                tedarikci_ekle.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void tedarikciHammaddeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TedarikciHammaddeEkle tedarikci_hammadde_ekle = new TedarikciHammaddeEkle();
                tedarikci_hammadde_ekle.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void hammaddeSatinAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UreticiHammadde uretici_hammadde_ekle = new UreticiHammadde();
                uretici_hammadde_ekle.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void firmayaGoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UreticiHammadde_TedarikciFirmayaGore_ uretici_hammadde_ekle_FirmayaGore = new UreticiHammadde_TedarikciFirmayaGore_();
                uretici_hammadde_ekle_FirmayaGore.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void kimyasalUretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KimyasalUret kimyasal_uret = new KimyasalUret();
                kimyasal_uret.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void siparisKarsilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SiparisKarsila siparis_karsila = new SiparisKarsila();
                siparis_karsila.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void karZararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KarZararTablosu kar_zarar = new KarZararTablosu();
                kar_zarar.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }
    }
}
