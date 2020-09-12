namespace projedenemesi
{
    partial class MusteriSiparisVer
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
            this.musterilerListBox = new System.Windows.Forms.ListBox();
            this.urunlerListBox = new System.Windows.Forms.ListBox();
            this.txtIstenenMiktart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSiparis = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelBilgilendirme = new System.Windows.Forms.Label();
            this.bGuncelle = new System.Windows.Forms.Button();
            this.Ye = new System.Windows.Forms.Label();
            this.tbYeniMiktar = new System.Windows.Forms.TextBox();
            this.bSil = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // musterilerListBox
            // 
            this.musterilerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musterilerListBox.FormattingEnabled = true;
            this.musterilerListBox.ItemHeight = 17;
            this.musterilerListBox.Location = new System.Drawing.Point(17, 51);
            this.musterilerListBox.Name = "musterilerListBox";
            this.musterilerListBox.Size = new System.Drawing.Size(155, 208);
            this.musterilerListBox.TabIndex = 1;
            // 
            // urunlerListBox
            // 
            this.urunlerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunlerListBox.FormattingEnabled = true;
            this.urunlerListBox.ItemHeight = 17;
            this.urunlerListBox.Location = new System.Drawing.Point(197, 51);
            this.urunlerListBox.Name = "urunlerListBox";
            this.urunlerListBox.Size = new System.Drawing.Size(155, 208);
            this.urunlerListBox.TabIndex = 2;
            // 
            // txtIstenenMiktart
            // 
            this.txtIstenenMiktart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIstenenMiktart.Location = new System.Drawing.Point(381, 106);
            this.txtIstenenMiktart.Name = "txtIstenenMiktart";
            this.txtIstenenMiktart.Size = new System.Drawing.Size(100, 24);
            this.txtIstenenMiktart.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(116, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Müşteriler:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(296, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ürünler:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(378, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Miktar:";
            // 
            // btnSiparis
            // 
            this.btnSiparis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparis.Location = new System.Drawing.Point(381, 154);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(100, 31);
            this.btnSiparis.TabIndex = 7;
            this.btnSiparis.Text = "Sipariş Ver";
            this.btnSiparis.UseVisualStyleBackColor = true;
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(461, 243);
            this.dataGridView1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelBilgilendirme);
            this.groupBox1.Controls.Add(this.btnSiparis);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.musterilerListBox);
            this.groupBox1.Controls.Add(this.urunlerListBox);
            this.groupBox1.Controls.Add(this.txtIstenenMiktart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(102, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 313);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sipariş Ver";
            // 
            // labelBilgilendirme
            // 
            this.labelBilgilendirme.AutoSize = true;
            this.labelBilgilendirme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBilgilendirme.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelBilgilendirme.Location = new System.Drawing.Point(14, 278);
            this.labelBilgilendirme.Name = "labelBilgilendirme";
            this.labelBilgilendirme.Size = new System.Drawing.Size(0, 18);
            this.labelBilgilendirme.TabIndex = 8;
            // 
            // bGuncelle
            // 
            this.bGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bGuncelle.Location = new System.Drawing.Point(21, 105);
            this.bGuncelle.Name = "bGuncelle";
            this.bGuncelle.Size = new System.Drawing.Size(100, 36);
            this.bGuncelle.TabIndex = 13;
            this.bGuncelle.Text = "Güncelle";
            this.bGuncelle.UseVisualStyleBackColor = true;
            this.bGuncelle.Click += new System.EventHandler(this.bGuncelle_Click);
            // 
            // Ye
            // 
            this.Ye.AutoSize = true;
            this.Ye.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Ye.Location = new System.Drawing.Point(18, 35);
            this.Ye.Name = "Ye";
            this.Ye.Size = new System.Drawing.Size(85, 18);
            this.Ye.TabIndex = 12;
            this.Ye.Text = "Yeni Miktar:";
            // 
            // tbYeniMiktar
            // 
            this.tbYeniMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbYeniMiktar.Location = new System.Drawing.Point(565, 448);
            this.tbYeniMiktar.Name = "tbYeniMiktar";
            this.tbYeniMiktar.Size = new System.Drawing.Size(100, 24);
            this.tbYeniMiktar.TabIndex = 11;
            // 
            // bSil
            // 
            this.bSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bSil.Location = new System.Drawing.Point(565, 548);
            this.bSil.Name = "bSil";
            this.bSil.Size = new System.Drawing.Size(100, 31);
            this.bSil.TabIndex = 14;
            this.bSil.Text = "Sil";
            this.bSil.UseVisualStyleBackColor = true;
            this.bSil.Click += new System.EventHandler(this.bSil_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(12, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 302);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Siparişler";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bGuncelle);
            this.groupBox3.Controls.Add(this.Ye);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(544, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 221);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Güncelleme";
            // 
            // MusteriSiparisVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 706);
            this.Controls.Add(this.bSil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbYeniMiktar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "MusteriSiparisVer";
            this.Text = "MusteriSiparisVer";
            this.Load += new System.EventHandler(this.MusteriSiparisVer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox musterilerListBox;
        private System.Windows.Forms.ListBox urunlerListBox;
        private System.Windows.Forms.TextBox txtIstenenMiktart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSiparis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelBilgilendirme;
        private System.Windows.Forms.Button bGuncelle;
        private System.Windows.Forms.Label Ye;
        private System.Windows.Forms.TextBox tbYeniMiktar;
        private System.Windows.Forms.Button bSil;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}