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
    public partial class SiparisKarsila : Form
    {
        public SiparisKarsila()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        private void SiparisKarsila_Load(object sender, EventArgs e)
        {
            listeleme();
            doldurKimyasallar();
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
                    cmd.CommandText = "SELECT M.musteriId, M.musteriAd, K.urunAd, S.istenenMiktar, K.urunId FROM MusteriSiparis S, Musteriler M, "
                        + "KimyasalUrunler K WHERE M.musteriId = S.musteriId AND K.urunId = S.urunId AND S.maliyet = 0 AND S.urunSatisFiyati = 0";
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpr.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    baglanti.Close();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT K.urunAd, UK.kimyasalStok, UK.kimyasaılUretimTarihi, UK.toplamMaliyet, K.UrunId "
                        + "FROM UreticiKimyasallar UK, KimyasalUrunler K WHERE K.urunId = UK.urunId";
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

        private void bKarsila_Click(object sender, EventArgs e)
        {
            //karşılıyor mu kontrolü
            int elimdekiStok = 0;
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT toplam = SUM(kimyasalStok) FROM UreticiKimyasallar WHERE urunId = @a";
                cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value.ToString()));
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    elimdekiStok = Convert.ToInt32(read["toplam"].ToString());
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                elimdekiStok = 0;
            }

            if(elimdekiStok >= Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString()))
            {
                //sipariş karşıla
                SqlCommand cmd;

                int silinen = 0, gereken = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                double toplamMaliyet = 0;
                //yeteri kadar delete bir madde için
                while (gereken != silinen)
                {
                    try
                    {
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = baglanti;
                            cmd.CommandText = "SELECT K.urunAd, UK.kimyasalStok, UK.kimyasaılUretimTarihi, UK.toplamMaliyet, K.UrunId "
                                + "FROM UreticiKimyasallar UK, KimyasalUrunler K WHERE K.urunId = UK.urunId AND K.urunId = @a";
                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value.ToString()));
                            dataGridView2.Columns[4].Visible = false;
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

                    ///silme
                    if (Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString()) <= gereken)
                    {
                        /////direkt silme
                        try
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                toplamMaliyet += Convert.ToDouble(dataGridView2.CurrentRow.Cells[3].Value.ToString());
                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandText = "DELETE FROM UreticiKimyasallar WHERE urunId=@a1 AND kimyasalStok = @a2 AND "
                                    + "kimyasaılUretimTarihi = @a3 AND toplamMaliyet = @a4";
                                cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value.ToString()));
                                cmd.Parameters.AddWithValue("@a2", Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString()));
                                cmd.Parameters.AddWithValue("@a3", dataGridView2.CurrentRow.Cells[2].Value.ToString());
                                cmd.Parameters.AddWithValue("@a4", Convert.ToDouble(dataGridView2.CurrentRow.Cells[3].Value.ToString()));
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
                        silinen += Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                    }
                    else
                    {
                        ///bir miktar sil update edilecek
                        try
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                toplamMaliyet += (Convert.ToDouble(dataGridView2.CurrentRow.Cells[3].Value.ToString())/Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString()))*(gereken - silinen);

                                ////////////////////////////////////////////////////////////////
                                ///
                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;

                                cmd.CommandText = "UPDATE UreticiKimyasallar SET kimyasalStok = @p1, toplamMaliyet = @p2 WHERE "
                                      + "urunId = @a1 AND kimyasaılUretimTarihi = @a2 AND toplamMaliyet = @a3 AND kimyasalStok = @a4";

                                int yeniStok = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString()) - (gereken - silinen);
                                cmd.Parameters.AddWithValue("@p1", yeniStok);

                                float yeniFiyat = float.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString()) / Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                                yeniFiyat = yeniFiyat * yeniStok;
                                cmd.Parameters.AddWithValue("@p2", Math.Round(yeniFiyat, 2));

                                cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView2.CurrentRow.Cells[4].Value.ToString()));
                                cmd.Parameters.AddWithValue("@a2", dataGridView2.CurrentRow.Cells[2].Value.ToString());
                                cmd.Parameters.AddWithValue("@a3", Convert.ToDouble(dataGridView2.CurrentRow.Cells[3].Value.ToString()));
                                cmd.Parameters.AddWithValue("@a4", Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString()));

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                baglanti.Close();
                                silinen += (gereken - silinen);

                            }
                        }
                        catch (Exception b)
                        {
                            MessageBox.Show(b.Message);
                            baglanti.Close();
                        }
                    }
                }

                baglanti.Open();
                cmd = new SqlCommand();
                cmd.Connection = baglanti;

                cmd.CommandText = "UPDATE MusteriSiparis SET maliyet = @p1, urunSatisFiyati = @p2 WHERE "
                      + "musteriId = @a1 AND urunId = @a2 AND istenenMiktar = @a3 AND maliyet = @a4 AND urunSatisFiyati = @a5";
                double satisFiyat = (Int32.Parse(tbKar.Text) / 100.0);
                MessageBox.Show(satisFiyat.ToString());
                satisFiyat = satisFiyat * toplamMaliyet;
                MessageBox.Show(satisFiyat.ToString());
                satisFiyat += toplamMaliyet;
                MessageBox.Show(satisFiyat.ToString());
                cmd.Parameters.AddWithValue("@p1", toplamMaliyet);
                cmd.Parameters.AddWithValue("@p2", Math.Round(satisFiyat, 2));

                cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                cmd.Parameters.AddWithValue("@a2", Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
                cmd.Parameters.AddWithValue("@a3", gereken);
                cmd.Parameters.AddWithValue("@a4", 0);
                cmd.Parameters.AddWithValue("@a5", 0);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();

            }
            else
            {
                MessageBox.Show("Elimizde yeterli sayıda " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " bulunmamaktadır!");
            }
            listeleme();
        }

        private void cbKimyasallar_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT K.urunAd, UK.kimyasalStok, UK.kimyasaılUretimTarihi, UK.toplamMaliyet, K.UrunId "
                        + "FROM UreticiKimyasallar UK, KimyasalUrunler K WHERE K.urunId = UK.urunId AND K.urunAd = @a";
                    cmd.Parameters.AddWithValue("@a", cbKimyasallar.SelectedItem.ToString());
                    dataGridView2.Columns[4].Visible = false;
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

        private void doldurKimyasallar()
        {
            try
            {
                cbKimyasallar.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT DISTINCT urunAd From KimyasalUrunler ORDER BY urunAd ASC";
                baglanti.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    cbKimyasallar.Items.Add(read["urunAd"]);
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }
    }
}
