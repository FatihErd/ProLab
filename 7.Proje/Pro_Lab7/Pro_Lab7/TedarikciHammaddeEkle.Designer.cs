namespace projedenemesi
{
    partial class TedarikciHammaddeEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbFirmaAd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHammaddeAdi = new System.Windows.Forms.ComboBox();
            this.tbStok = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUretimTarih = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSatisFiyati = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bEkle = new System.Windows.Forms.Button();
            this.bSil = new System.Windows.Forms.Button();
            this.bGuncelle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFirmaAd
            // 
            this.cbFirmaAd.FormattingEnabled = true;
            this.cbFirmaAd.Location = new System.Drawing.Point(105, 78);
            this.cbFirmaAd.Name = "cbFirmaAd";
            this.cbFirmaAd.Size = new System.Drawing.Size(121, 24);
            this.cbFirmaAd.TabIndex = 0;
            this.cbFirmaAd.SelectedIndexChanged += new System.EventHandler(this.cbFirmaAd_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Firma Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hammadde Adı: ";
            // 
            // cbHammaddeAdi
            // 
            this.cbHammaddeAdi.FormattingEnabled = true;
            this.cbHammaddeAdi.Location = new System.Drawing.Point(105, 141);
            this.cbHammaddeAdi.Name = "cbHammaddeAdi";
            this.cbHammaddeAdi.Size = new System.Drawing.Size(121, 24);
            this.cbHammaddeAdi.TabIndex = 2;
            // 
            // tbStok
            // 
            this.tbStok.Location = new System.Drawing.Point(267, 80);
            this.tbStok.Name = "tbStok";
            this.tbStok.Size = new System.Drawing.Size(121, 22);
            this.tbStok.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stok Adeti: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Üretim Tarihi: ";
            // 
            // tbUretimTarih
            // 
            this.tbUretimTarih.Location = new System.Drawing.Point(267, 143);
            this.tbUretimTarih.Name = "tbUretimTarih";
            this.tbUretimTarih.Size = new System.Drawing.Size(121, 22);
            this.tbUretimTarih.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Satis Fiyati: ";
            // 
            // tbSatisFiyati
            // 
            this.tbSatisFiyati.Location = new System.Drawing.Point(435, 111);
            this.tbSatisFiyati.Name = "tbSatisFiyati";
            this.tbSatisFiyati.Size = new System.Drawing.Size(121, 22);
            this.tbSatisFiyati.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(726, 236);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // bEkle
            // 
            this.bEkle.Location = new System.Drawing.Point(605, 46);
            this.bEkle.Name = "bEkle";
            this.bEkle.Size = new System.Drawing.Size(88, 34);
            this.bEkle.TabIndex = 11;
            this.bEkle.Text = "Ekle";
            this.bEkle.UseVisualStyleBackColor = true;
            this.bEkle.Click += new System.EventHandler(this.bEkle_Click);
            // 
            // bSil
            // 
            this.bSil.Location = new System.Drawing.Point(605, 89);
            this.bSil.Name = "bSil";
            this.bSil.Size = new System.Drawing.Size(88, 34);
            this.bSil.TabIndex = 12;
            this.bSil.Text = "Sil";
            this.bSil.UseVisualStyleBackColor = true;
            this.bSil.Click += new System.EventHandler(this.bSil_Click);
            // 
            // bGuncelle
            // 
            this.bGuncelle.Location = new System.Drawing.Point(605, 135);
            this.bGuncelle.Name = "bGuncelle";
            this.bGuncelle.Size = new System.Drawing.Size(88, 34);
            this.bGuncelle.TabIndex = 13;
            this.bGuncelle.Text = "Güncelle";
            this.bGuncelle.UseVisualStyleBackColor = true;
            this.bGuncelle.Click += new System.EventHandler(this.bGuncelle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(96, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 146);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgiler";
            // 
            // TedarikciHammaddeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 450);
            this.Controls.Add(this.bGuncelle);
            this.Controls.Add(this.bSil);
            this.Controls.Add(this.bEkle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSatisFiyati);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUretimTarih);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbHammaddeAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFirmaAd);
            this.Controls.Add(this.groupBox1);
            this.Name = "TedarikciHammaddeEkle";
            this.Text = "TedarikciHammaddeEkle";
            this.Load += new System.EventHandler(this.TedarikciHammaddeEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFirmaAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHammaddeAdi;
        private System.Windows.Forms.TextBox tbStok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUretimTarih;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSatisFiyati;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bEkle;
        private System.Windows.Forms.Button bSil;
        private System.Windows.Forms.Button bGuncelle;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}