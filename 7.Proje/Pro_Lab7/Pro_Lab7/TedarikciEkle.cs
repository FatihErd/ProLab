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
    public partial class TedarikciEkle : Form
    {
        public TedarikciEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        SqlCommand cmd;

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int sehir_Id = -1;
            bool durum = true;

            if (cbEkliSehirler.SelectedIndex>-1 && cbEkliSehirler.SelectedIndex>-1)
            {
                //şehir seçilmiş
                baglanti.Open();
                cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT sehirId FROM Sehirler WHERE sehirAd = '" + cbEkliSehirler.SelectedItem.ToString() + "'";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    sehir_Id = Int32.Parse(read["sehirId"].ToString());
                }
                baglanti.Close();

                baglanti.Open();
                cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO Tedarikciler(firmaAd,sehirId)VALUES(@p1,@p2)";
                cmd.Parameters.AddWithValue("@p1", txtFirmaAd.Text);
                cmd.Parameters.AddWithValue("@p2", sehir_Id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
            }
            else if (txtFirmaAd.Text != "" && txtSehirAd.Text != "" && txtUlke.Text != "")
            {
                //şehir seçilmemiş

                //Şehirler tablosunda var mı?
                baglanti.Open();
                cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM Sehirler";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (txtSehirAd.Text == read["sehirAd"].ToString())
                        durum = false;
                }
                baglanti.Close();

                if(durum)
                {
                    //şehir yok
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO Sehirler(sehirAd,ulke,mesafe)VALUES(@p1,@p2,@p3)";
                    cmd.Parameters.AddWithValue("@p1", txtSehirAd.Text);
                    cmd.Parameters.AddWithValue("@p2", txtUlke.Text);
                    cmd.Parameters.AddWithValue("@p3", Convert.ToDouble(txtMesafe.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT sehirId FROM Sehirler WHERE sehirAd = '" + txtSehirAd.Text + "'";
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        sehir_Id = Int32.Parse(read["sehirId"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO Tedarikciler(firmaAd,sehirId)VALUES(@p1,@p2)";
                    cmd.Parameters.AddWithValue("@p1", txtFirmaAd.Text);
                    cmd.Parameters.AddWithValue("@p2", sehir_Id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    doldurEkliUlkeleri();
                    temizle();
                }
                else
                {
                    //şehir var
                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT sehirId FROM Sehirler WHERE sehirAd = '" + txtSehirAd.Text + "'";
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        sehir_Id = Int32.Parse(read["sehirId"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO Tedarikciler(firmaAd,sehirId)VALUES(@p1,@p2)";
                    cmd.Parameters.AddWithValue("@p1", txtFirmaAd.Text);
                    cmd.Parameters.AddWithValue("@p2", sehir_Id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    temizle();
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş geçilemez");
            listeleme();
        }

        private void doldurEkliUlkeleri()
        {
            try
            {
                cbUlke.Items.Clear();
                cbEkliSehirler.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT DISTINCT ulke FROM Sehirler ORDER BY ulke";
                baglanti.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    cbUlke.Items.Add(read["ulke"]);
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void doldurEkliSehirleri()
        {
            try
            {
                cbEkliSehirler.Items.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT DISTINCT sehirAd FROM Sehirler WHERE ulke='" + cbUlke.SelectedItem.ToString() + "' ORDER BY sehirAd";
                baglanti.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    cbEkliSehirler.Items.Add(read["sehirAd"]);
                }
                baglanti.Close();
            }catch(Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void TedarikciEkle_Load(object sender, EventArgs e)
        {
            doldurEkliUlkeleri();
            listeleme();
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
                    cmd.CommandText = "SELECT T.firmaAd, S.ulke, S.sehirAd, S.mesafe, S.sehirId FROM Tedarikciler T, Sehirler S WHERE S.sehirId=T.sehirId";
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

        private void cbUlke_SelectedIndexChanged(object sender, EventArgs e)
        {
            doldurEkliSehirleri();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFirmaAd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUlke.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSehirAd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMesafe.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void temizle()
        {
            txtFirmaAd.Text = "";
            txtUlke.Text = "";
            txtSehirAd.Text = "";
            txtMesafe.Text = "";
        }
    }
}
