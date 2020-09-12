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
    public partial class Sehirler : Form
    {
        public Sehirler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");
        bool durum = true;

        private bool kayitKontrolGuncelle(int id)
        {
            bool d = true;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM Sehirler WHERE sehirId <>" + id;
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (txtSehirAd.Text == read["sehirAd"].ToString())
                    d = false;
            }
            baglanti.Close();
            return d;
        }

        private void kayitKontrol()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM Sehirler";
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (txtSehirAd.Text == read["sehirAd"].ToString())
                    durum = false;
            }
            baglanti.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtSehirAd.Text != null && txtUlke.Text != "" && txtMesafe.Text != "")
            {
                try
                {
                    kayitKontrol();
                    if (durum)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "INSERT INTO Sehirler(sehirAd,ulke,mesafe)VALUES('" + txtSehirAd.Text + "','" + txtUlke.Text + "','" + Convert.ToDouble(txtMesafe.Text) + "')";
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        baglanti.Close();
                        temizle();
                        listeleme();
                    }
                    else
                        MessageBox.Show("Var olan kayit eklenemez");
                    durum = true;
                    //  baglanti.Close();
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

            //  baglanti.Close();

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
                    cmd.CommandText = "SELECT * FROM Sehirler";
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpr.Fill(ds, "Sehirler");
                    dataGridView1.DataSource = ds.Tables["Sehirler"];
                    dataGridView1.Columns[3].Visible = false;
                    baglanti.Close();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }

        void temizle()
        {
            txtSehirAd.Text = "";
            txtUlke.Text = "";
            txtMesafe.Text = "";
        }

        private void Sehirler_Load(object sender, EventArgs e)
        {
            listeleme();
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
                    cmd.CommandText = "delete from Sehirler where sehirId=@a";
                    cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[3].Value.ToString());
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSehirAd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUlke.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMesafe.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            int id = Int32.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if (txtSehirAd.Text != null && txtUlke.Text != "" && txtMesafe.Text != "")
            {
                try
                {
                    if (durum)
                    {
                        //güncellemede var olanı kontrol edemiyorum
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
                        cmd.CommandText = "UPDATE Sehirler SET sehirAd='" + txtSehirAd.Text + "',ulke = '" + txtUlke.Text + "',mesafe = '" + Convert.ToDouble(txtMesafe.Text) + "'where sehirId=@a";
                        cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        baglanti.Close();
                        listeleme();
                        temizle();
                    }
                    else
                        MessageBox.Show("Var olan değer güncellenemez");
                    baglanti.Close();

                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                    baglanti.Close();
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş geçilemez!");


            baglanti.Close();

        }
    }

}

