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
    public partial class TedarikciHammaddeEkle : Form
    {
        public TedarikciHammaddeEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        private void TedarikciHammaddeEkle_Load(object sender, EventArgs e)
        {
            doldurFirmalari();
            doldurHammadde();
        }

        private void doldurFirmalari()
        {
            try
            {
                cbFirmaAd.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT firmaAd FROM Tedarikciler ORDER BY firmaAd ASC";
                baglanti.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    cbFirmaAd.Items.Add(read["firmaAd"]);
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void doldurHammadde()
        {
            try
            {
                cbHammaddeAdi.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT maddeAd FROM Hammaddeler ORDER BY maddeAd ASC";
                baglanti.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    cbHammaddeAdi.Items.Add(read["maddeAd"]);
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void cbFirmaAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void listeleme()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;

                    //Seçilen firmanın elindeki ürünler
                    cmd.CommandText = "SELECT T.firmaAd, H.maddeAd, TH.maddeStok, TH.maddeUretimTarihi, TH.maddeSatisFiyati FROM "
                        + "Tedarikciler T, Hammaddeler H, TedarikciHammaddeler TH WHERE H.maddeId = TH.maddeId AND "
                        + "T.firmaId = TH.firmaId AND TH.firmaId = (SELECT firmaId FROM Tedarikciler WHERE firmaAd = @a)";
                    cmd.Parameters.AddWithValue("@a", cbFirmaAd.SelectedItem.ToString());
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpr.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }

        private void temizle()
        {
            cbFirmaAd.SelectedItem = "";
            cbHammaddeAdi.SelectedItem = "";
            tbStok.Text = "";
            tbUretimTarih.Text = "";
            tbSatisFiyati.Text = "";
        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            if (cbFirmaAd.SelectedIndex > -1 && cbHammaddeAdi.SelectedIndex > -1 && tbUretimTarih.Text != "" && tbStok.Text != "" && tbSatisFiyati.Text != "")
            {
                string rakamlar, a;
                rakamlar = tbUretimTarih.Text;
                string[] dizi = rakamlar.Split('.', ' ', ',', '/');

                if (Int32.Parse(dizi[0]) > 31 || Int32.Parse(dizi[0]) <= 0 || Int32.Parse(dizi[1]) > 12 || Int32.Parse(dizi[1]) <= 0)
                {
                    MessageBox.Show("Yanlış tarih girdiniz!");
                    kontrol = true;
                }
                a = string.Concat(dizi);

                if(kontrol == false)
                {
                    //geçmiş tarihli ürün eklenemez
                    string tarih;
                    tarih = DateTime.Now.ToShortDateString();
                    string[] dizi1 = tarih.Split('.', ' ', ',', '/');
                    //label1.Text = dizi1[0];
                    int sGun, sAy, sYil;
                    sGun = Convert.ToInt32(dizi1[0]);
                    sAy = Convert.ToInt32(dizi1[1]);
                    sYil = Convert.ToInt32(dizi1[2]);
                    int maddeO = 0;

                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "Select DISTINCT maddeOmur From TedarikciHammaddeler T, Hammaddeler H Where H.maddeId = T.maddeId AND H.maddeAd = @a";
                    cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        maddeO = Int32.Parse(read["maddeOmur"].ToString());
                    }
                    baglanti.Close();

                    int gGun = Convert.ToInt32(dizi[0]);
                    int gAy = Convert.ToInt32(dizi[1]);
                    int gYil = Convert.ToInt32(dizi[2]);

                    if (sYil - gYil > maddeO)
                    {
                        kontrol = true;
                        MessageBox.Show("Tarihi geçmiş ürün giremezsiniz!");
                    }
                    if(sYil - gYil == maddeO)
                    {
                        if(sAy - gAy >= 0)
                        {
                            if(sGun - gGun >=0)
                            {
                                kontrol = true;
                                MessageBox.Show("Tarihi geçmiş ürün giremezsiniz!");
                            }
                        }
                    }
                }

                if (kontrol == false)
                {
                    try
                    {
                        bool durum = true;
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "SELECT T.firmaAd, H.maddeAd, TH.maddeStok, TH.maddeUretimTarihi, TH.maddeSatisFiyati FROM "
                                + "Tedarikciler T, Hammaddeler H, TedarikciHammaddeler TH WHERE H.maddeId = TH.maddeId AND "
                                + "T.firmaId = TH.firmaId AND TH.firmaId = (SELECT firmaId FROM Tedarikciler WHERE firmaAd = @a)";
                        cmd.Parameters.AddWithValue("@a", cbFirmaAd.SelectedItem.ToString());
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            if (cbHammaddeAdi.SelectedItem.ToString() == read["maddeAd"].ToString())
                            {
                                if (Int32.Parse(a) == Int32.Parse(read["maddeUretimTarihi"].ToString()))
                                {
                                    if (Convert.ToDouble(tbSatisFiyati.Text) == Convert.ToDouble(read["maddeSatisFiyati"].ToString()))
                                    {
                                        durum = false;
                                    }
                                }
                            }
                        }
                        baglanti.Close();

                        if (durum == true)
                        {
                            //direkt ekle
                            int firmaID = 0, maddeID = 0;

                            baglanti.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = baglanti;
                            cmd.CommandText = "SELECT maddeId FROM Hammaddeler WHERE maddeAd = @a";
                            cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
                            read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                maddeID = Int32.Parse(read["maddeId"].ToString());
                            }
                            baglanti.Close();

                            baglanti.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = baglanti;
                            cmd.CommandText = "SELECT firmaId FROM Tedarikciler WHERE firmaAd = @a";
                            cmd.Parameters.AddWithValue("@a", cbFirmaAd.SelectedItem.ToString());
                            read = cmd.ExecuteReader();

                            while (read.Read())
                            {
                                firmaID = Int32.Parse(read["firmaId"].ToString());
                            }
                            baglanti.Close();

                            baglanti.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = baglanti;
                            cmd.CommandText = "INSERT INTO TedarikciHammaddeler(firmaId, maddeId, maddeStok, maddeUretimTarihi, maddeSatisFiyati) VALUES (@a1, @a2, @a3, @a4, @a5)";
                            cmd.Parameters.AddWithValue("@a1", firmaID);
                            cmd.Parameters.AddWithValue("@a2", maddeID);
                            cmd.Parameters.AddWithValue("@a3", tbStok.Text);
                            cmd.Parameters.AddWithValue("@a4", a);
                            cmd.Parameters.AddWithValue("@a5", Convert.ToDouble(tbSatisFiyati.Text));
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            baglanti.Close();
                            listeleme();
                        }
                        else
                        {
                            //uretim tarihi ayni güncelleme yap
                            try
                            {
                                int guncelStok = 0;
                                string maddeUretim = "";
                                double maddeSatis = 0.1;

                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandText = "SELECT T.firmaAd, H.maddeAd, TH.maddeStok, TH.maddeUretimTarihi, TH.maddeSatisFiyati FROM "
                                        + "Tedarikciler T, Hammaddeler H, TedarikciHammaddeler TH WHERE H.maddeId = TH.maddeId AND "
                                        + "T.firmaId = TH.firmaId AND TH.firmaId = (SELECT firmaId FROM Tedarikciler WHERE firmaAd = @a)";
                                cmd.Parameters.AddWithValue("@a", cbFirmaAd.SelectedItem.ToString());
                                read = cmd.ExecuteReader();
                                while (read.Read())
                                {
                                    if (cbHammaddeAdi.SelectedItem.ToString() == read["maddeAd"].ToString())
                                        if (a == read["maddeUretimTarihi"].ToString())
                                        {
                                            maddeUretim = read["maddeUretimTarihi"].ToString();
                                            if (Convert.ToDouble(tbSatisFiyati.Text) == Convert.ToDouble(read["maddeSatisFiyati"].ToString()))
                                            {
                                                maddeSatis = Convert.ToDouble(read["maddeSatisFiyati"].ToString());
                                                guncelStok = Int32.Parse(read["maddeStok"].ToString());
                                            }
                                        }
                                }
                                baglanti.Close();

                                int firmaID = 0, maddeID = 0;

                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandText = "SELECT maddeId FROM Hammaddeler WHERE maddeAd = @a";
                                cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
                                read = cmd.ExecuteReader();
                                while (read.Read())
                                {
                                    maddeID = Int32.Parse(read["maddeId"].ToString());
                                }
                                baglanti.Close();

                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandText = "SELECT firmaId FROM Tedarikciler WHERE firmaAd = @a";
                                cmd.Parameters.AddWithValue("@a", cbFirmaAd.SelectedItem.ToString());
                                read = cmd.ExecuteReader();

                                while (read.Read())
                                {
                                    firmaID = Int32.Parse(read["firmaId"].ToString());
                                }
                                baglanti.Close();

                                guncelStok = guncelStok + Int32.Parse(tbStok.Text);

                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandText = "UPDATE TedarikciHammaddeler SET maddeStok = @a WHERE firmaId = @a1 AND maddeId = @a2 AND "
                                    + "maddeStok = @a3 AND maddeUretimTarihi = @a4 AND maddeSatisFiyati = @a5";
                                cmd.Parameters.AddWithValue("@a", guncelStok);
                                cmd.Parameters.AddWithValue("@a1", firmaID);
                                cmd.Parameters.AddWithValue("@a2", maddeID);
                                cmd.Parameters.AddWithValue("@a3", guncelStok- Int32.Parse(tbStok.Text));
                                cmd.Parameters.AddWithValue("@a4", maddeUretim);
                                cmd.Parameters.AddWithValue("@a5", maddeSatis);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                baglanti.Close();
                                listeleme();
                            }
                            catch (Exception b)
                            {
                                MessageBox.Show(b.Message);
                                baglanti.Close();
                            }
                        }
                        durum = true;
                    }
                    catch (Exception b)
                    {
                        MessageBox.Show(b.Message);
                    }
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş geçilemez!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbHammaddeAdi.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbStok.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbUretimTarih.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            ////////
            ///DOĞRU AKTARMA YAPILMADI
            tbSatisFiyati.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader read;

            int firmaID = 0, maddeID = 0;

            baglanti.Open();
            cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT maddeId FROM Hammaddeler WHERE maddeAd = @a";
            cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                maddeID = Int32.Parse(read["maddeId"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT firmaId FROM Tedarikciler WHERE firmaAd = @a";
            cmd.Parameters.AddWithValue("@a", cbFirmaAd.SelectedItem.ToString());
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                firmaID = Int32.Parse(read["firmaId"].ToString());
            }
            baglanti.Close();

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from TedarikciHammaddeler where firmaId=@a1 AND maddeId = @a2 AND "
                        + "maddeStok = @a3 AND maddeUretimTarihi = @a4 AND maddeSatisFiyati = @a5";
                    cmd.Parameters.AddWithValue("@a1", firmaID);
                    cmd.Parameters.AddWithValue("@a2", maddeID);
                    cmd.Parameters.AddWithValue("@a3", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@a4", dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@a5", dataGridView1.CurrentRow.Cells[4].Value.ToString());
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

        private void bGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader read;

            int firmaID = 0, maddeID = 0;

            baglanti.Open();
            cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT maddeId FROM Hammaddeler WHERE maddeAd = @a";
            cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                maddeID = Int32.Parse(read["maddeId"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT firmaId FROM Tedarikciler WHERE firmaAd = @a";
            cmd.Parameters.AddWithValue("@a", cbFirmaAd.SelectedItem.ToString());
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                firmaID = Int32.Parse(read["firmaId"].ToString());
            }
            baglanti.Close();

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;

                    cmd.CommandText = "UPDATE TedarikciHammaddeler SET maddeStok = @p1, maddeSatisFiyati = @p2 WHERE "
                        + "firmaId=@a1 AND maddeId = @a2 AND maddeUretimTarihi = @a4";
                    cmd.Parameters.AddWithValue("@a1", firmaID);
                    cmd.Parameters.AddWithValue("@a2", maddeID);
                    cmd.Parameters.AddWithValue("@a4", dataGridView1.CurrentRow.Cells[3].Value.ToString());

                    cmd.Parameters.AddWithValue("@p1", Int32.Parse(tbStok.Text));
                    cmd.Parameters.AddWithValue("@p2", Convert.ToDouble(tbSatisFiyati.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    listeleme();
                    temizle();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }
    }
}
