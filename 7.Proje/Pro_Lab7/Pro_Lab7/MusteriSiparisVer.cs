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
    public partial class MusteriSiparisVer : Form
    {
        public MusteriSiparisVer()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        void doldurUrun()
        {
            try
            {
                urunlerListBox.Items.Clear();
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM KimyasalUrunler";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    urunlerListBox.Items.Add(read["urunAd"]);
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        void doldurMusteri()
        {
            try
            {
                musterilerListBox.Items.Clear();
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Musteriler";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    musterilerListBox.Items.Add(read["musteriAd"]);
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void MusteriSiparisVer_Load(object sender, EventArgs e)
        {
            doldurUrun();
            doldurMusteri();
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
                    cmd.CommandText = " SELECT M.musteriId, M.musteriAd, K.urunAd, S.istenenMiktar FROM MusteriSiparis S, Musteriler M, "
                        + "KimyasalUrunler K WHERE M.musteriId = S.musteriId AND K.urunId = S.urunId AND S.maliyet = 0";
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

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            try
            {
                int musteri_Id = -1, urun_Id = -1;
                if (txtIstenenMiktart.Text != "" || musterilerListBox.SelectedIndex > -1 || urunlerListBox.SelectedIndex > -1)
                {
                    //musteriId bul

                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT * FROM Musteriler WHERE musteriAd = '" + musterilerListBox.SelectedItem.ToString() + "'";
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        musteri_Id = Int32.Parse(read["musteriId"].ToString());
                    }
                    baglanti.Close();

                    //urunId bul
                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT * FROM KimyasalUrunler WHERE urunAd = '" + urunlerListBox.SelectedItem.ToString() + "'";
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        urun_Id = Int32.Parse(read["urunId"].ToString());
                    }
                    baglanti.Close();

                    //ekleme
                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO MusteriSiparis(musteriId,urunId,istenenMiktar,maliyet,urunSatisFiyati) VALUES "
                        + "(@a1, @a2, @a3, @a4, @a5)";
                    cmd.Parameters.AddWithValue("@a1", musteri_Id);
                    cmd.Parameters.AddWithValue("@a2", urun_Id);
                    cmd.Parameters.AddWithValue("@a3", Int32.Parse(txtIstenenMiktart.Text));
                    cmd.Parameters.AddWithValue("@a4", 0);
                    cmd.Parameters.AddWithValue("@a5", 0);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();

                    labelBilgilendirme.Text = (musteri_Id.ToString() + " müşteri idli " + urun_Id + " urun idli " + txtIstenenMiktart.Text + " tane ürün eklendi");
                }
                else
                    MessageBox.Show("Hiçbir alan boş geçilemez");
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
            listeleme();
            txtIstenenMiktart.Text = "";
        }

        private void bGuncelle_Click(object sender, EventArgs e)
        {
            //urunId bul
            int UrunId = 0;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM KimyasalUrunler WHERE urunAd = '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                UrunId = Int32.Parse(read["urunId"].ToString());
            }
            baglanti.Close();

            //güncellemede var olanı kontrol edemiyorum
            baglanti.Open();
             cmd = new SqlCommand();
            cmd.Connection = baglanti;
            //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
            cmd.CommandText = "UPDATE MusteriSiparis SET istenenMiktar = @a1 WHERE musteriId=@p1 AND urunId=@p2 AND maliyet=@p3";
            cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(tbYeniMiktar.Text));
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            cmd.Parameters.AddWithValue("@p2", UrunId);
            cmd.Parameters.AddWithValue("@p3", 0);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglanti.Close();
            listeleme();
            tbYeniMiktar.Text = "";
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    //urunId bul
                    int UrunId = 0;
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT * FROM KimyasalUrunler WHERE urunAd = '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        UrunId = Int32.Parse(read["urunId"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "DELETE FROM MusteriSiparis WHERE musteriId=@a1 AND urunId = @a2 AND "
                        + "maliyet = @a3 AND istenenMiktar = @a4";
                    cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    cmd.Parameters.AddWithValue("@a2", UrunId);
                    cmd.Parameters.AddWithValue("@a3", 0);
                    cmd.Parameters.AddWithValue("@a4", dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    listeleme();
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
