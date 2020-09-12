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
    public partial class KimyasalUrunEkle : Form
    {
        public KimyasalUrunEkle()
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
            cmd.CommandText = "SELECT * FROM KimyasalUrunler";
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (txtÜrünAd.Text == read["urunAd"].ToString())
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
            cmd.CommandText = "SELECT * FROM KimyasalUrunler WHERE urunId <>" + id;
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (txtÜrünAd.Text == read["urunAd"].ToString())
                    d = false;
            }
            baglanti.Close();
            return d;
        }

        void temizle()
        {
            txtÜrünAd.Text = "";
            txtÜrünBirleşen.Text = "";
            txtKimyasalÖmür.Text = "";
            txtİscilikMaliyeti.Text = "";
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
                    //cmd.CommandText = "SELECT urunAd, urunBilesen, kimyasalOmur FROM KimyasalUrunler";
                    cmd.CommandText = "SELECT * FROM KimyasalUrunler";
                    SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpr.Fill(ds, "Urunler");
                    dataGridView1.DataSource = ds.Tables["Urunler"];
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


        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtÜrünAd.Text != null && txtÜrünBirleşen.Text != "" && txtKimyasalÖmür.Text != "")
            {
                try
                {
                    kayitKontrol();
                    if (durum)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;

                        cmd.CommandText = "INSERT INTO KimyasalUrunler(urunAd,urunBilesen,kimyasalOmur,iscilikMaliyet)VALUES(@a1, @a2, @a3, @a4)";
                        cmd.Parameters.AddWithValue("@a1", txtÜrünAd.Text);
                        cmd.Parameters.AddWithValue("@a2", txtÜrünBirleşen.Text);
                        cmd.Parameters.AddWithValue("@a3", Int32.Parse(txtKimyasalÖmür.Text));
                        cmd.Parameters.AddWithValue("@a4", Convert.ToDouble(txtİscilikMaliyeti.Text));

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

        private void KimyasalUrun_Load(object sender, EventArgs e)
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
                    cmd.CommandText = "delete from KimyasalUrunler where urunId=@a";
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
            txtÜrünAd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtÜrünBirleşen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtKimyasalÖmür.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtİscilikMaliyeti.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if (txtÜrünAd.Text != null && txtÜrünBirleşen.Text != "" && txtKimyasalÖmür.Text != "")
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
                        //cmd.CommandText = "UPDATE KimyasalUrunler SET urunAd='" + txtÜrünAd.Text + "',urunBilesen = '" + txtÜrünBirleşen.Text + "',kimyasalOmur = '" + Int32.Parse(txtKimyasalÖmür.Text) + "',iscilikMaliyet = '" + float.Parse(txtİscilikMaliyeti.Text) + "'where urunId=@a";

                        cmd.CommandText = "UPDATE KimyasalUrunler SET urunAd = @a1, urunBilesen = @a2, kimyasalOmur = @a3, iscilikMaliyet = @a4 where urunId=@a";
                        cmd.Parameters.AddWithValue("@a1", txtÜrünAd.Text);
                        cmd.Parameters.AddWithValue("@a2", txtÜrünBirleşen.Text);
                        cmd.Parameters.AddWithValue("@a3", Int32.Parse(txtKimyasalÖmür.Text));
                        cmd.Parameters.AddWithValue("@a4", Convert.ToDouble(txtİscilikMaliyeti.Text));
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
    }
}
