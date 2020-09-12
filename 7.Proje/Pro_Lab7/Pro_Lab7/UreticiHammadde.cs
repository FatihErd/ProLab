using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projedenemesi
{
    public partial class UreticiHammadde : Form
    {
        public UreticiHammadde()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        private void UreticiHammadde_Load(object sender, EventArgs e)
        {
            doldurHammadde();
            doldurHammaddeler();
            listeleme();
        }

        private void doldurHammaddeler()
        {
            try
            {
                cbHammaddeler.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT DISTINCT H.maddeAd From Hammaddeler H, UreticiHammaddeler UH WHERE UH.maddeId = H.maddeId "
                    + "ORDER BY H.maddeAd ASC";
                baglanti.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    cbHammaddeler.Items.Add(read["maddeAd"]);
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

        private void cbHammaddeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;

                    //Seçilen ürünler

                    if (tbStok.Text != "")
                    {
                        cmd.CommandText = "SELECT TH.firmaId, H.maddeAd, TH.maddeStok, TH.maddeUretimTarihi, TH.maddeSatisFiyati, "
                            + "'Kargo Fiyat' = CASE ulke WHEN 'Türkiye' THEN mesafe*0.5 ELSE mesafe *1.0 END, "
                            + "'Toplam Fiyat' = (CASE ulke WHEN 'Türkiye' THEN((mesafe * 0.5) + (TH.maddeSatisFiyati*@s)) ELSE((mesafe * 1.0) + (TH.maddeSatisFiyati*@s)) END), "
                            + "T.firmaAd FROM Sehirler S, Tedarikciler T, Hammaddeler H, TedarikciHammaddeler TH WHERE "
                            + "H.maddeId = TH.maddeId AND T.firmaId = TH.firmaId AND H.maddeAd = @a AND S.sehirId = T.sehirId "
                            + "ORDER BY 'Toplam Fiyat' ASC";
                        cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@s", Convert.ToInt32(tbStok.Text));
                    }
                    else
                    {
                        cmd.CommandText = "SELECT TH.firmaId, H.maddeAd, TH.maddeStok, TH.maddeUretimTarihi, TH.maddeSatisFiyati, "
                            + "'Kargo Fiyat' = CASE ulke WHEN 'Türkiye' THEN mesafe*0.5 ELSE mesafe *1.0 END, "
                            + "'Toplam Fiyat' = (CASE ulke WHEN 'Türkiye' THEN((mesafe * 0.5) + (TH.maddeSatisFiyati)) ELSE((mesafe * 1.0) + (TH.maddeSatisFiyati)) END), "
                            + "T.firmaAd FROM Sehirler S, Tedarikciler T, Hammaddeler H, TedarikciHammaddeler TH WHERE "
                            + "H.maddeId = TH.maddeId AND T.firmaId = TH.firmaId AND H.maddeAd = @a AND S.sehirId = T.sehirId "
                            + "ORDER BY 'Toplam Fiyat' ASC";
                        cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
                    }
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpr.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    baglanti.Close();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }

        private void listeleme()
        {
            if (cbHammaddeler.SelectedIndex > -1)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "SELECT H.maddeAd, UH.maddeuretimtarihi, UH.hammaddeMaliyet, UH.hammaddeStok FROM "
                            + "UreticiHammaddeler UH, Hammaddeler H WHERE H.maddeId = UH.maddeId AND H.maddeAd = @a ORDER BY H.maddeAd ASC, UH.hammaddeMaliyet ASC";
                        cmd.Parameters.AddWithValue("@a", cbHammaddeler.SelectedItem.ToString());
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
            }
            else
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "SELECT H.maddeAd, UH.maddeuretimtarihi, UH.hammaddeMaliyet, UH.hammaddeStok FROM "
                            + "UreticiHammaddeler UH, Hammaddeler H WHERE H.maddeId = UH.maddeId ORDER BY H.maddeAd ASC, UH.hammaddeMaliyet ASC";
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
            }
        }

        private void bSatinAl_Click(object sender, EventArgs e)
        {
            try
            {
                string maddeUretim = "";
                double maliyet = 0, birimMaliyet = 0;
                int stok = 0;
                bool durum = true;
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT H.maddeAd, UH.maddeuretimtarihi, UH.hammaddeMaliyet, UH.hammaddeStok FROM UreticiHammaddeler UH, "
                    + "Hammaddeler H WHERE H.maddeId = UH.maddeId";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (cbHammaddeAdi.SelectedItem.ToString() == read["maddeAd"].ToString())
                    {
                        if (Int32.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == Int32.Parse(read["maddeUretimTarihi"].ToString()))
                        {
                            maddeUretim = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                            maliyet = Convert.ToDouble(read["hammaddeMaliyet"].ToString());
                            birimMaliyet = Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value.ToString()) / Convert.ToInt32(tbStok.Text);
                            durum = false;
                            stok = Convert.ToInt32(read["hammaddeStok"].ToString());
                        }
                    }
                }
                baglanti.Close();

                //yeterli stok var mı?
                bool kontrol = true;
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString()) < Convert.ToInt32(tbStok.Text))
                    kontrol = false;

                if(kontrol == true)
                {
                    //stoktan çıkarma işlemi tedarikçi için yani silme

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

                    firmaID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    if(Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString()) == Convert.ToInt32(tbStok.Text))
                    {
                        //silme
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
                            }
                        }
                        catch (Exception b)
                        {
                            MessageBox.Show(b.Message);
                            baglanti.Close();
                        }
                    }
                    else
                    {
                        //çıkarma işlemi yapılacak
                        try
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;

                                cmd.CommandText = "UPDATE TedarikciHammaddeler SET maddeStok = @p1 WHERE "
                                    + "maddeSatisFiyati = @a1 AND firmaId=@a2 AND maddeId = @a3 AND maddeUretimTarihi = @a4";
                                cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
                                cmd.Parameters.AddWithValue("@a2", firmaID);
                                cmd.Parameters.AddWithValue("@a3", maddeID);
                                cmd.Parameters.AddWithValue("@a4", dataGridView1.CurrentRow.Cells[3].Value.ToString());
                                cmd.Parameters.AddWithValue("@p1", Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString())-Convert.ToInt32(tbStok.Text));
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                baglanti.Close();
                            }
                        }
                        catch (Exception b)
                        {
                            MessageBox.Show(b.Message);
                            baglanti.Close();
                        }
                    }    
                    ////////
                    maddeID = 0;

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT maddeId FROM Hammaddeler WHERE maddeAd = @a";
                    cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        maddeID = Int32.Parse(read["maddeId"].ToString());
                    }
                    baglanti.Close();

                    if (durum == true)
                    {
                        //direkt ekle
                        baglanti.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        //cmd.CommandText = "INSERT INTO TedarikciHammaddeler(firmaId, maddeId, maddeStok, maddeUretimTarihi, maddeSatisFiyati) VALUES (@a1, @a2, @a3, @a4, @a5)";
                        cmd.CommandText = "INSERT INTO UreticiHammaddeler(maddeId, maddeuretimtarihi, hammaddeMaliyet, hammaddeStok) VALUES (@a1, @a2, @a3, @a4)";
                        cmd.Parameters.AddWithValue("@a1", maddeID);
                        cmd.Parameters.AddWithValue("@a2", dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@a3", Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value.ToString()));
                        cmd.Parameters.AddWithValue("@a4", Convert.ToInt32(tbStok.Text));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        baglanti.Close();
                        listeleme();
                        //silme yazılacak ve tedarikçilerde güncellenecek datagriddde
                    }
                    else
                    {
                        //uretim tarihi ayni güncelleme yap
                        try
                        {
                            stok = stok + Int32.Parse(tbStok.Text);

                            baglanti.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = baglanti;
                            cmd.CommandText = "UPDATE UreticiHammaddeler SET hammaddeStok = @s1, hammaddeMaliyet=@s2 WHERE maddeId = @a1 AND maddeuretimtarihi = @a2 AND hammaddeMaliyet=@a3";
                            cmd.Parameters.AddWithValue("@s1", Convert.ToInt32(stok));
                            cmd.Parameters.AddWithValue("@s2", maliyet + (birimMaliyet * Convert.ToInt32(tbStok.Text)));
                            cmd.Parameters.AddWithValue("@a1", maddeID);
                            cmd.Parameters.AddWithValue("@a2", maddeUretim);
                            cmd.Parameters.AddWithValue("@a3", maliyet);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            baglanti.Close();
                            listeleme();
                            //silme yazılacak ve tedarikçilerde güncellenecek datagriddde

                        }
                        catch (Exception b)
                        {
                            MessageBox.Show(b.Message);
                            baglanti.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Yeterli stok yok");
                }
                //hepsini güncelle datagridlerin
                durum = true;
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
            cbHammaddeAdi_SelectedIndexChanged(sender, e);
        }

        private void tbStok_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    if (cbHammaddeAdi.SelectedIndex > -1)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;

                        //Seçilen ürünler
                        cmd.CommandText = "SELECT TH.firmaId, H.maddeAd, TH.maddeStok, TH.maddeUretimTarihi, TH.maddeSatisFiyati, "
                            + "'Kargo Fiyat' = CASE ulke WHEN 'Türkiye' THEN mesafe*0.5 ELSE mesafe *1.0 END, "
                            + "'Toplam Fiyat' = (CASE ulke WHEN 'Türkiye' THEN((mesafe * 0.5) + (TH.maddeSatisFiyati*@s)) ELSE((mesafe * 1.0) + (TH.maddeSatisFiyati*@s)) END), "
                            + "T.firmaAd FROM Sehirler S, Tedarikciler T, Hammaddeler H, TedarikciHammaddeler TH WHERE "
                            + "H.maddeId = TH.maddeId AND T.firmaId = TH.firmaId AND H.maddeAd = @a AND S.sehirId = T.sehirId "
                            + "ORDER BY 'Toplam Fiyat' ASC";
                        cmd.Parameters.AddWithValue("@a", cbHammaddeAdi.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@s", Convert.ToInt32(tbStok.Text));

                        SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adpr.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].Visible = false;
                        baglanti.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ürün seçiniz");
                        tbStok.Text = "";
                    }

                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }

        private void cbHammaddeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
