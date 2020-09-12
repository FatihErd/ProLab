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
    public partial class KarZararTablosu : Form
    {
        public KarZararTablosu()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");

        private void KarZararTablosu_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT 'Müşteri Ad' = CASE S.maliyet WHEN 0 THEN '-' ELSE M.musteriAd END, "
                        + "'Ürün Ad' = CASE S.maliyet WHEN 0 THEN '-' ELSE K.urunAd END, "
                        + "'Maliyet' = CASE S.maliyet WHEN 0 THEN 0 ELSE S.maliyet END, S.urunSatisFiyati, "
                        + "'Kar-Zarar' = CASE S.maliyet WHEN 0 THEN S.urunSatisFiyati ELSE S.urunSatisFiyati - maliyet END "
                        + "FROM MusteriSiparis S, Musteriler M, KimyasalUrunler K WHERE K.urunId = S.urunId AND M.musteriId = S.musteriId";
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
            int say = 0;
            double satis = 0, maliyet =0;
            while (say < dataGridView1.RowCount - 1)
            {
                satis += Convert.ToDouble(dataGridView1.Rows[say].Cells[4].Value.ToString());
                maliyet += Convert.ToDouble(dataGridView1.Rows[say].Cells[2].Value.ToString());
                say++;
            }

            textBox1.Text = satis.ToString();
            //((Satış Fiyatı - Alış Fiyatı) / Alış Fiyatı) x 100
            textBox2.Text = "% " +(Math.Round((((satis - maliyet) / maliyet)*100.0),2)).ToString();
        }
    }
}
