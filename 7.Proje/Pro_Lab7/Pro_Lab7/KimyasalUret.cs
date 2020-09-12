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
    public partial class KimyasalUret : Form
    {
        public KimyasalUret()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PT75IMG\\SQLEXPRESS;Initial Catalog=ProLab3;Integrated Security=True");
        //SqlConnection baglanti = new SqlConnection("Data Source=SATELLITE;Initial Catalog=ProLab3;Integrated Security=True");
        string bilesen;
        int uretilecek;

        private void KimyasalUret_Load(object sender, EventArgs e)
        {
            doldurKimyasallar();
            listeleme();
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

        private void listeleme()
        {
            if (cbKimyasallar.SelectedIndex > -1)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "SELECT K.urunAd, UK.kimyasalStok, UK.kimyasaılUretimTarihi, UK.toplamMaliyet "
                            + "FROM UreticiKimyasallar UK, KimyasalUrunler K WHERE K.urunId = UK.urunId AND K.urunAd = @a";
                        cmd.Parameters.AddWithValue("@a", cbKimyasallar.SelectedItem.ToString());
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
            else
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "SELECT K.urunAd, UK.kimyasalStok, UK.kimyasaılUretimTarihi, UK.toplamMaliyet "
                            + "FROM UreticiKimyasallar UK, KimyasalUrunler K WHERE K.urunId = UK.urunId";
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

        }

        private void bUret_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            double toplamMaliyet = 0;
            SqlCommand cmd;
            SqlDataReader read;
            if (tbUretilecek.Text != "" || cbKimyasallar.SelectedIndex < 0)
            {
                uretilecek = Convert.ToInt32(tbUretilecek.Text);
                string[] parcalar = new string[5];
                int[] adetler = new int[5];
                int uzunluk = 0, j = 0;
                bilesen = bilesen.Trim(' ');
                ////AYIRMA
                while (uzunluk < bilesen.Length - 1)
                {
                    if (char.IsUpper(bilesen[uzunluk]))
                    {
                        parcalar[j] = bilesen[uzunluk].ToString();
                        if (bilesen.Length - 1 > uzunluk)
                            uzunluk++;
                        if (char.IsLower(bilesen[uzunluk]))
                        {
                            parcalar[j] = bilesen[uzunluk - 1].ToString() + bilesen[uzunluk].ToString();
                            if (bilesen.Length - 1 > uzunluk)
                                uzunluk++;
                            if (char.IsDigit(bilesen[uzunluk]))
                            {
                                string rakam = bilesen[uzunluk].ToString();
                                if (bilesen.Length - 1 > uzunluk)
                                {
                                    uzunluk++;
                                    if (char.IsDigit(bilesen[uzunluk]))
                                    {
                                        rakam += bilesen[uzunluk].ToString();
                                        if (bilesen.Length - 1 > uzunluk)
                                            uzunluk++;
                                    }
                                }
                                adetler[j] = Convert.ToInt32(rakam);
                            }
                            else
                            {
                                adetler[j] = 1;
                            }
                        }
                        else if (char.IsDigit(bilesen[uzunluk]))
                        {
                            string rakam = bilesen[uzunluk].ToString();
                            if (bilesen.Length - 1 > uzunluk)
                            {
                                uzunluk++;
                                if (char.IsDigit(bilesen[uzunluk]))
                                {
                                    rakam += bilesen[uzunluk].ToString();
                                    if (bilesen.Length - 1 > uzunluk)
                                        uzunluk++;
                                }
                            }
                            adetler[j] = Convert.ToInt32(rakam);
                        }
                        else
                        {
                            adetler[j] = 1;
                        }
                    }
                    j++;
                }
                for (int i = 0; i < j; i++)
                    adetler[i] *= uretilecek;

                int[] elimdekiHammaddeler = new int[j];
                //elimdeki hammaddeler
                for (int i = 0; i < j; i++)
                {
                    try
                    {
                        baglanti.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "SELECT toplam = SUM(UH.hammaddeStok) FROM UreticiHammaddeler UH, Hammaddeler H "
                            + "WHERE H.maddeId = UH.maddeId AND H.maddeKisaltma = @a";
                        cmd.Parameters.AddWithValue("@a", parcalar[i]);
                        read = cmd.ExecuteReader();

                        while (read.Read())
                        {
                            elimdekiHammaddeler[i] = Convert.ToInt32(read["toplam"].ToString());
                        }
                        baglanti.Close();
                    }
                    catch (Exception b)
                    {
                        elimdekiHammaddeler[i] = 0;
                    }
                }

                //elimdekiler yetiyor mu kontrolü
                bool kontrol = true;
                for (int i = 0; i < j; i++)
                    if (elimdekiHammaddeler[i] < adetler[i])
                        kontrol = false;

                if (kontrol == false)
                {
                    MessageBox.Show("Yeterli sayıda hammaddeniz bulunmuyor!");
                    for (int i = 0; i < j; i++)
                        if (elimdekiHammaddeler[i] < adetler[i])
                        {
                            label2.Text = label2.Text + "\n" + parcalar[i] + "; Elimde: " + elimdekiHammaddeler[i].ToString()
                                + " Gereken: " + adetler[i].ToString();
                        }
                    baglanti.Close();
                }
                else
                {
                    //üretim işlemi yap
                    /////////////////////////
                    ///Delete işlemleri
                    for (int i = 0; i < j; i++)
                    {
                        int silinen = 0;
                        //yeteri kadar delete bir madde için
                        while (adetler[i] != silinen)
                        {
                            try
                            {
                                if (baglanti.State == ConnectionState.Closed)
                                {
                                    baglanti.Open();
                                    cmd = new SqlCommand();
                                    cmd.Connection = baglanti;
                                    cmd.CommandText = "SELECT H.maddeId, H.maddeAd, UH.maddeuretimtarihi, UH.hammaddeMaliyet, UH.hammaddeStok FROM "
                                        + "UreticiHammaddeler UH, Hammaddeler H WHERE H.maddeId = UH.maddeId AND H.maddeKisaltma = @a "
                                        + "ORDER BY H.maddeAd ASC, UH.maddeuretimtarihi ASC";
                                    cmd.Parameters.AddWithValue("@a", parcalar[i].ToString());
                                    dataGridView1.Columns[0].Visible = false;
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

                            ///silme
                            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) <= adetler[i])
                            {
                                /////direkt silme
                                try
                                {
                                    if (baglanti.State == ConnectionState.Closed)
                                    {
                                        toplamMaliyet += Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                                        baglanti.Open();
                                        cmd = new SqlCommand();
                                        cmd.Connection = baglanti;
                                        cmd.CommandText = "DELETE FROM UreticiHammaddeler WHERE maddeId=@a1 AND maddeUretimTarihi = @a2 AND "
                                            + "hammaddeMaliyet = @a3 AND hammaddeStok = @a4";
                                        cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                                        cmd.Parameters.AddWithValue("@a2", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                                        cmd.Parameters.AddWithValue("@a3", Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
                                        cmd.Parameters.AddWithValue("@a4", Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
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
                                silinen += Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                            }
                            else
                            {
                                ///bir miktar sil update edilecek
                                try
                                {
                                    if (baglanti.State == ConnectionState.Closed)
                                    {
                                        toplamMaliyet += (Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value.ToString())/Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()))*(adetler[i] - silinen);
                                        /*MessageBox.Show(toplamMaliyet.ToString());
                                        MessageBox.Show(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                                        MessageBox.Show(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                                        MessageBox.Show((adetler[i] - silinen).ToString());*/
                                        baglanti.Open();
                                        cmd = new SqlCommand();
                                        cmd.Connection = baglanti;

                                        cmd.CommandText = "UPDATE UreticiHammaddeler SET hammaddeStok = @p1, hammaddeMaliyet = @p2 WHERE "
                                              + "maddeId = @a1 AND maddeUretimTarihi = @a2 AND hammaddeMaliyet = @a3 AND hammaddeStok = @a4";
                                        int yeniStok = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()) - (adetler[i] - silinen);
                                        cmd.Parameters.AddWithValue("@p1", yeniStok);

                                        float yeniFiyat = float.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) / Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                                        yeniFiyat = yeniFiyat * yeniStok;
                                        cmd.Parameters.AddWithValue("@p2", Math.Round(yeniFiyat, 2));

                                        cmd.Parameters.AddWithValue("@a1", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                                        cmd.Parameters.AddWithValue("@a2", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                                        cmd.Parameters.AddWithValue("@a3", Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
                                        cmd.Parameters.AddWithValue("@a4", Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString()));

                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();
                                        baglanti.Close();
                                        silinen += (adetler[i] - silinen);
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

                    //delete işlemi bitti üret

                    //tarih eklemek icin
                    string tarih, a;
                    tarih = DateTime.Now.ToShortDateString();
                    string[] dizi1 = tarih.Split('.', ' ', ',', '/');
                    //label1.Text = dizi1[0];
                    int sGun, sAy, sYil;
                    sGun = Convert.ToInt32(dizi1[0]);
                    sAy = Convert.ToInt32(dizi1[1]);
                    sYil = Convert.ToInt32(dizi1[2]);
                    a = string.Concat(dizi1);

                    //aynı tarihli aynı madde yoksa
                    int urunID = 0;
                    Double iscilik = 0;

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT urunId FROM KimyasalUrunler WHERE urunAd = @a";
                    cmd.Parameters.AddWithValue("@a", cbKimyasallar.SelectedItem.ToString());
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        urunID = Int32.Parse(read["urunId"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT iscilikMaliyet FROM KimyasalUrunler WHERE urunAd = @a";
                    cmd.Parameters.AddWithValue("@a", cbKimyasallar.SelectedItem.ToString());
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        iscilik = Convert.ToDouble(read["iscilikMaliyet"].ToString());
                    }
                    baglanti.Close();

                    toplamMaliyet += (iscilik * Convert.ToInt32(tbUretilecek.Text));
                    toplamMaliyet = Math.Round(toplamMaliyet, 2);
                    //tarih
                    bool tarihKontrol = true;
                    int eskiStok = 0;
                    double eskiMaliyet = 0;
                    baglanti.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "SELECT * FROM UreticiKimyasallar WHERE urunId = @a";
                    cmd.Parameters.AddWithValue("@a", urunID);
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        if (a.Equals(read["kimyasaılUretimTarihi"].ToString()))
                        {
                            tarihKontrol = false;
                            eskiStok = Convert.ToInt32(read["kimyasalStok"].ToString());
                            eskiMaliyet = Convert.ToDouble(read["toplamMaliyet"].ToString());
                        }
                    }
                    baglanti.Close();


                    if (tarihKontrol == true)
                    {
                        baglanti.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "INSERT INTO UreticiKimyasallar(urunId, kimyasalStok, kimyasaılUretimTarihi, "
                                        + "toplamMaliyet) VALUES (@a1, @a2, @a3, @a4)";
                        cmd.Parameters.AddWithValue("@a1", urunID);
                        cmd.Parameters.AddWithValue("@a2", Convert.ToInt32(tbUretilecek.Text));
                        cmd.Parameters.AddWithValue("@a3", a);
                        cmd.Parameters.AddWithValue("@a4", toplamMaliyet);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        baglanti.Close();
                        listeleme();
                    }
                    else
                    {
                        //update
                        try
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                baglanti.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;

                                cmd.CommandText = "UPDATE UreticiKimyasallar SET kimyasalStok = @p1, toplamMaliyet=@p2 WHERE "
                                    + "urunId = @a1 AND kimyasaılUretimTarihi=@a2";
                                cmd.Parameters.AddWithValue("@a1", urunID);
                                cmd.Parameters.AddWithValue("@a2", a);

                                cmd.Parameters.AddWithValue("@p1", eskiStok + Convert.ToInt32(tbUretilecek.Text));
                                cmd.Parameters.AddWithValue("@p2", eskiMaliyet + toplamMaliyet);
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
                }
            }
            else
                MessageBox.Show("Hiçbir alan boş geçilemez!");
            listeleme();
        }

        private void cbKimyasallar_SelectedIndexChanged(object sender, EventArgs e)
        {          
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT urunBilesen FROM KimyasalUrunler WHERE urunAd = @a";
                cmd.Parameters.AddWithValue("@a", cbKimyasallar.SelectedItem.ToString());          
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    bilesen = Convert.ToString(read["urunBilesen"]);
                }
                baglanti.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }

            label1.Text = bilesen;
            listeleme();
        }
    }
}
