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
    public partial class MusterilerEkle : Form
    {
        public MusterilerEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        private void listeleme()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    //  cmd.CommandText = "SELECT musteriAd, musteriAdres FROM Musteriler";
                    cmd.CommandText = "SELECT * FROM Musteriler";
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpr.Fill(ds, "Musteri");
                    dataGridView1.DataSource = ds.Tables["Musteri"];
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

        public void temizle()
        {
            txtMusteriAdi.Text = "";
            txtMusteriAdresi.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtMusteriAdi.Text != null && txtMusteriAdresi.Text != null)
            {
                try
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO Musteriler(musteriAd,musteriAdres)VALUES('" + txtMusteriAdi.Text + "','" + txtMusteriAdresi.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    temizle();
                    listeleme();
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş bırakılamaz!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusteriAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMusteriAdresi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

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
                    cmd.CommandText = "delete from Musteriler where musteriId=@a";
                    cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[0].Value.ToString());
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

        private void MusterilerEkle_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                //güncellemede var olanı kontrol edemiyorum
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
                cmd.CommandText = "UPDATE Musteriler SET musteriAd='" + txtMusteriAdi.Text + "',musteriAdres = '" + txtMusteriAdresi.Text + "'where musteriId=@a";
                cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                listeleme();
                temizle();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
                baglanti.Close();
            }
        }
    }
}
