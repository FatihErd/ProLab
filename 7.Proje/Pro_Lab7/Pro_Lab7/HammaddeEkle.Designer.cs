namespace projedenemesi
{
    partial class HammaddeEkle
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaddeOmur = new System.Windows.Forms.TextBox();
            this.txtMaddeAd = new System.Windows.Forms.TextBox();
            this.txtBirlesenKisitlama = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.proLab3DataSet = new projedenemesi.ProLab3DataSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eklemeİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hammaddeEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kimyasalÜrünlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikcilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikciHammaddeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musteriSiparisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablolarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sehirlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üreticiFirmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hammaddeSatinAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firmayaGoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kimyasalUretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparisKarsilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.karZararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proLab3DataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(344, 110);
            this.btnSil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSil.Name = "btnSil";
            this.btnSil.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSil.Size = new System.Drawing.Size(96, 25);
            this.btnSil.TabIndex = 51;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(61, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 50;
            this.label3.Text = "Madde Ömür";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(61, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "Madde Ad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(61, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Birleşen kısıtlama";
            // 
            // txtMaddeOmur
            // 
            this.txtMaddeOmur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMaddeOmur.Location = new System.Drawing.Point(209, 107);
            this.txtMaddeOmur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaddeOmur.Name = "txtMaddeOmur";
            this.txtMaddeOmur.Size = new System.Drawing.Size(100, 23);
            this.txtMaddeOmur.TabIndex = 47;
            // 
            // txtMaddeAd
            // 
            this.txtMaddeAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMaddeAd.Location = new System.Drawing.Point(209, 75);
            this.txtMaddeAd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaddeAd.Name = "txtMaddeAd";
            this.txtMaddeAd.Size = new System.Drawing.Size(100, 23);
            this.txtMaddeAd.TabIndex = 46;
            // 
            // txtBirlesenKisitlama
            // 
            this.txtBirlesenKisitlama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBirlesenKisitlama.Location = new System.Drawing.Point(209, 43);
            this.txtBirlesenKisitlama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBirlesenKisitlama.Name = "txtBirlesenKisitlama";
            this.txtBirlesenKisitlama.Size = new System.Drawing.Size(100, 23);
            this.txtBirlesenKisitlama.TabIndex = 45;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(344, 76);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(96, 25);
            this.btnGuncelle.TabIndex = 44;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Location = new System.Drawing.Point(344, 41);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(96, 25);
            this.btnEkle.TabIndex = 43;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 155);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(469, 229);
            this.dataGridView1.TabIndex = 52;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // proLab3DataSet
            // 
            this.proLab3DataSet.DataSetName = "ProLab3DataSet";
            this.proLab3DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eklemeİşlemleriToolStripMenuItem,
            this.musteriSiparisToolStripMenuItem,
            this.tablolarToolStripMenuItem,
            this.üreticiFirmaToolStripMenuItem,
            this.karZararToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(569, 28);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eklemeİşlemleriToolStripMenuItem
            // 
            this.eklemeİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hammaddeEkleToolStripMenuItem,
            this.musterilerToolStripMenuItem,
            this.kimyasalÜrünlerToolStripMenuItem,
            this.tedarikcilerToolStripMenuItem,
            this.tedarikciHammaddeToolStripMenuItem});
            this.eklemeİşlemleriToolStripMenuItem.Name = "eklemeİşlemleriToolStripMenuItem";
            this.eklemeİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.eklemeİşlemleriToolStripMenuItem.Text = "Ekleme İşlemleri";
            // 
            // hammaddeEkleToolStripMenuItem
            // 
            this.hammaddeEkleToolStripMenuItem.Name = "hammaddeEkleToolStripMenuItem";
            this.hammaddeEkleToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.hammaddeEkleToolStripMenuItem.Text = "Hammaddeler";
            this.hammaddeEkleToolStripMenuItem.Click += new System.EventHandler(this.hammaddeEkleToolStripMenuItem_Click);
            // 
            // musterilerToolStripMenuItem
            // 
            this.musterilerToolStripMenuItem.Name = "musterilerToolStripMenuItem";
            this.musterilerToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.musterilerToolStripMenuItem.Text = "Müşteriler";
            this.musterilerToolStripMenuItem.Click += new System.EventHandler(this.musterilerToolStripMenuItem_Click);
            // 
            // kimyasalÜrünlerToolStripMenuItem
            // 
            this.kimyasalÜrünlerToolStripMenuItem.Name = "kimyasalÜrünlerToolStripMenuItem";
            this.kimyasalÜrünlerToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.kimyasalÜrünlerToolStripMenuItem.Text = "Kimyasal Ürünler ";
            this.kimyasalÜrünlerToolStripMenuItem.Click += new System.EventHandler(this.kimyasalÜrünlerToolStripMenuItem_Click);
            // 
            // tedarikcilerToolStripMenuItem
            // 
            this.tedarikcilerToolStripMenuItem.Name = "tedarikcilerToolStripMenuItem";
            this.tedarikcilerToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.tedarikcilerToolStripMenuItem.Text = "Tedarikçiler";
            this.tedarikcilerToolStripMenuItem.Click += new System.EventHandler(this.tedarikcilerToolStripMenuItem_Click);
            // 
            // tedarikciHammaddeToolStripMenuItem
            // 
            this.tedarikciHammaddeToolStripMenuItem.Name = "tedarikciHammaddeToolStripMenuItem";
            this.tedarikciHammaddeToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.tedarikciHammaddeToolStripMenuItem.Text = "Tedarikçi Hammadde";
            this.tedarikciHammaddeToolStripMenuItem.Click += new System.EventHandler(this.tedarikciHammaddeToolStripMenuItem_Click);
            // 
            // musteriSiparisToolStripMenuItem
            // 
            this.musteriSiparisToolStripMenuItem.Name = "musteriSiparisToolStripMenuItem";
            this.musteriSiparisToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.musteriSiparisToolStripMenuItem.Text = "Müşteri Sipariş";
            this.musteriSiparisToolStripMenuItem.Click += new System.EventHandler(this.musteriSiparisToolStripMenuItem_Click);
            // 
            // tablolarToolStripMenuItem
            // 
            this.tablolarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sehirlerToolStripMenuItem});
            this.tablolarToolStripMenuItem.Name = "tablolarToolStripMenuItem";
            this.tablolarToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.tablolarToolStripMenuItem.Text = "Tablolar";
            // 
            // sehirlerToolStripMenuItem
            // 
            this.sehirlerToolStripMenuItem.Name = "sehirlerToolStripMenuItem";
            this.sehirlerToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.sehirlerToolStripMenuItem.Text = "Şehirler";
            this.sehirlerToolStripMenuItem.Click += new System.EventHandler(this.sehirlerToolStripMenuItem_Click);
            // 
            // üreticiFirmaToolStripMenuItem
            // 
            this.üreticiFirmaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hammaddeSatinAlToolStripMenuItem,
            this.kimyasalUretToolStripMenuItem,
            this.siparisKarsilaToolStripMenuItem});
            this.üreticiFirmaToolStripMenuItem.Name = "üreticiFirmaToolStripMenuItem";
            this.üreticiFirmaToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.üreticiFirmaToolStripMenuItem.Text = "Üretici Firma";
            // 
            // hammaddeSatinAlToolStripMenuItem
            // 
            this.hammaddeSatinAlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firmayaGoreToolStripMenuItem});
            this.hammaddeSatinAlToolStripMenuItem.Name = "hammaddeSatinAlToolStripMenuItem";
            this.hammaddeSatinAlToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.hammaddeSatinAlToolStripMenuItem.Text = "Hammadde Satın Al";
            this.hammaddeSatinAlToolStripMenuItem.Click += new System.EventHandler(this.hammaddeSatinAlToolStripMenuItem_Click);
            // 
            // firmayaGoreToolStripMenuItem
            // 
            this.firmayaGoreToolStripMenuItem.Name = "firmayaGoreToolStripMenuItem";
            this.firmayaGoreToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.firmayaGoreToolStripMenuItem.Text = "Firmaya Göre";
            this.firmayaGoreToolStripMenuItem.Click += new System.EventHandler(this.firmayaGoreToolStripMenuItem_Click);
            // 
            // kimyasalUretToolStripMenuItem
            // 
            this.kimyasalUretToolStripMenuItem.Name = "kimyasalUretToolStripMenuItem";
            this.kimyasalUretToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.kimyasalUretToolStripMenuItem.Text = "Kimyasal Üret";
            this.kimyasalUretToolStripMenuItem.Click += new System.EventHandler(this.kimyasalUretToolStripMenuItem_Click);
            // 
            // siparisKarsilaToolStripMenuItem
            // 
            this.siparisKarsilaToolStripMenuItem.Name = "siparisKarsilaToolStripMenuItem";
            this.siparisKarsilaToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.siparisKarsilaToolStripMenuItem.Text = "Sipariş Karşıla";
            this.siparisKarsilaToolStripMenuItem.Click += new System.EventHandler(this.siparisKarsilaToolStripMenuItem_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(243, 201);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(52, 126);
            this.dataGridView2.TabIndex = 54;
            // 
            // karZararToolStripMenuItem
            // 
            this.karZararToolStripMenuItem.Name = "karZararToolStripMenuItem";
            this.karZararToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.karZararToolStripMenuItem.Text = "Kar-Zarar";
            this.karZararToolStripMenuItem.Click += new System.EventHandler(this.karZararToolStripMenuItem_Click);
            // 
            // HammaddeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 410);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaddeOmur);
            this.Controls.Add(this.txtMaddeAd);
            this.Controls.Add(this.txtBirlesenKisitlama);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HammaddeEkle";
            this.Text = "Hammaddeler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proLab3DataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaddeOmur;
        private System.Windows.Forms.TextBox txtMaddeAd;
        private System.Windows.Forms.TextBox txtBirlesenKisitlama;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ProLab3DataSet proLab3DataSet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eklemeİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hammaddeEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musterilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kimyasalÜrünlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriSiparisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablolarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sehirlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tedarikcilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tedarikciHammaddeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üreticiFirmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hammaddeSatinAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firmayaGoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kimyasalUretToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparisKarsilaToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripMenuItem karZararToolStripMenuItem;
    }
}

