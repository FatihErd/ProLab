namespace projedenemesi
{
    partial class UreticiHammadde
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
            this.cbHammaddeAdi = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbStok = new System.Windows.Forms.TextBox();
            this.bSatinAl = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbHammaddeler = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.proLab3DataSet1 = new projedenemesi.ProLab3DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proLab3DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbHammaddeAdi
            // 
            this.cbHammaddeAdi.FormattingEnabled = true;
            this.cbHammaddeAdi.Location = new System.Drawing.Point(9, 50);
            this.cbHammaddeAdi.Name = "cbHammaddeAdi";
            this.cbHammaddeAdi.Size = new System.Drawing.Size(121, 24);
            this.cbHammaddeAdi.TabIndex = 17;
            this.cbHammaddeAdi.SelectedIndexChanged += new System.EventHandler(this.cbHammaddeAdi_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(57, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(993, 241);
            this.dataGridView1.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbHammaddeAdi);
            this.groupBox2.Location = new System.Drawing.Point(1118, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 90);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tedarik Edilecek Hammadde";
            // 
            // tbStok
            // 
            this.tbStok.Location = new System.Drawing.Point(15, 33);
            this.tbStok.Name = "tbStok";
            this.tbStok.Size = new System.Drawing.Size(115, 22);
            this.tbStok.TabIndex = 27;
            this.tbStok.TextChanged += new System.EventHandler(this.tbStok_TextChanged);
            // 
            // bSatinAl
            // 
            this.bSatinAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bSatinAl.Location = new System.Drawing.Point(1143, 291);
            this.bSatinAl.Name = "bSatinAl";
            this.bSatinAl.Size = new System.Drawing.Size(87, 39);
            this.bSatinAl.TabIndex = 29;
            this.bSatinAl.Text = "Satın Al";
            this.bSatinAl.UseVisualStyleBackColor = true;
            this.bSatinAl.Click += new System.EventHandler(this.bSatinAl_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(257, 388);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(593, 263);
            this.dataGridView2.TabIndex = 32;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(232, 365);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(643, 303);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Üretici Hammaddeler";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(32, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1042, 282);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tedarikçi Hammaddeler";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbStok);
            this.groupBox5.Location = new System.Drawing.Point(1118, 200);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(142, 74);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "İstenen Adet";
            // 
            // cbHammaddeler
            // 
            this.cbHammaddeler.FormattingEnabled = true;
            this.cbHammaddeler.Location = new System.Drawing.Point(9, 35);
            this.cbHammaddeler.Name = "cbHammaddeler";
            this.cbHammaddeler.Size = new System.Drawing.Size(121, 24);
            this.cbHammaddeler.TabIndex = 17;
            this.cbHammaddeler.SelectedIndexChanged += new System.EventHandler(this.cbHammaddeler_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbHammaddeler);
            this.groupBox6.Location = new System.Drawing.Point(1118, 479);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(142, 74);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hammadde Sırala";
            // 
            // proLab3DataSet1
            // 
            this.proLab3DataSet1.DataSetName = "ProLab3DataSet";
            this.proLab3DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UreticiHammadde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 683);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.bSatinAl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "UreticiHammadde";
            this.Text = "UreticiHammadde";
            this.Load += new System.EventHandler(this.UreticiHammadde_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.proLab3DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbHammaddeAdi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbStok;
        private System.Windows.Forms.Button bSatinAl;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbHammaddeler;
        private System.Windows.Forms.GroupBox groupBox6;
        private ProLab3DataSet proLab3DataSet1;
    }
}