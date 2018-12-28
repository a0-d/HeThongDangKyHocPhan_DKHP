namespace VIEW_USECASE.GiaoVu
{
    partial class CapNhatThongTinLop
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
            this.lbNote = new System.Windows.Forms.Label();
            this.btnLuuThayDoi = new System.Windows.Forms.Button();
            this.radGroupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTenLop = new System.Windows.Forms.ComboBox();
            this.SLSVTD1N = new System.Windows.Forms.NumericUpDown();
            this.SLNTD = new System.Windows.Forms.NumericUpDown();
            this.SLSV1L = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLSVTD1N)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLNTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLSV1L)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.ForeColor = System.Drawing.Color.Red;
            this.lbNote.Location = new System.Drawing.Point(547, 351);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(0, 13);
            this.lbNote.TabIndex = 41;
            // 
            // btnLuuThayDoi
            // 
            this.btnLuuThayDoi.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLuuThayDoi.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuThayDoi.ForeColor = System.Drawing.Color.Black;
            this.btnLuuThayDoi.Location = new System.Drawing.Point(550, 387);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new System.Drawing.Size(241, 60);
            this.btnLuuThayDoi.TabIndex = 43;
            this.btnLuuThayDoi.Text = "Lưu thay đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = false;
            this.btnLuuThayDoi.Click += new System.EventHandler(this.btnLuuThayDoi_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radGroupBox1.Controls.Add(this.tbTenLop);
            this.radGroupBox1.Controls.Add(this.SLSVTD1N);
            this.radGroupBox1.Controls.Add(this.SLNTD);
            this.radGroupBox1.Controls.Add(this.SLSV1L);
            this.radGroupBox1.Controls.Add(this.label17);
            this.radGroupBox1.Controls.Add(this.label15);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.label16);
            this.radGroupBox1.Controls.Add(this.label13);
            this.radGroupBox1.Controls.Add(this.label14);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.ForeColor = System.Drawing.Color.Red;
            this.radGroupBox1.Location = new System.Drawing.Point(160, 104);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(980, 229);
            this.radGroupBox1.TabIndex = 42;
            this.radGroupBox1.TabStop = false;
            this.radGroupBox1.Text = "Thông tin lớp";
            // 
            // tbTenLop
            // 
            this.tbTenLop.Enabled = false;
            this.tbTenLop.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenLop.FormattingEnabled = true;
            this.tbTenLop.ItemHeight = 27;
            this.tbTenLop.Location = new System.Drawing.Point(237, 42);
            this.tbTenLop.Name = "tbTenLop";
            this.tbTenLop.Size = new System.Drawing.Size(216, 35);
            this.tbTenLop.TabIndex = 40;
            // 
            // SLSVTD1N
            // 
            this.SLSVTD1N.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SLSVTD1N.Location = new System.Drawing.Point(748, 159);
            this.SLSVTD1N.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.SLSVTD1N.Name = "SLSVTD1N";
            this.SLSVTD1N.Size = new System.Drawing.Size(134, 35);
            this.SLSVTD1N.TabIndex = 37;
            // 
            // SLNTD
            // 
            this.SLNTD.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SLNTD.Location = new System.Drawing.Point(320, 157);
            this.SLNTD.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.SLNTD.Name = "SLNTD";
            this.SLNTD.Size = new System.Drawing.Size(133, 35);
            this.SLNTD.TabIndex = 38;
            // 
            // SLSV1L
            // 
            this.SLSV1L.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SLSV1L.Location = new System.Drawing.Point(748, 42);
            this.SLSV1L.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.SLSV1L.Name = "SLSV1L";
            this.SLSV1L.Size = new System.Drawing.Size(134, 35);
            this.SLSV1L.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(706, 163);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 27);
            this.label17.TabIndex = 33;
            this.label17.Text = "(*)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(278, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 27);
            this.label15.TabIndex = 34;
            this.label15.Text = "(*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(150, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 27);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên lớp";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(534, 163);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(178, 27);
            this.label16.TabIndex = 28;
            this.label16.Text = "SV tối đa 1 nhóm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(706, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 27);
            this.label13.TabIndex = 35;
            this.label13.Text = "(*)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(66, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(217, 27);
            this.label14.TabIndex = 30;
            this.label14.Text = "Số lượng nhóm tối đa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(522, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 27);
            this.label6.TabIndex = 31;
            this.label6.Text = "Số lượng sinh viên";
            // 
            // CapNhatThongTinLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1300, 550);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.btnLuuThayDoi);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "CapNhatThongTinLop";
            this.Text = "CapNhatThongTinLop";
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLSVTD1N)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLNTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLSV1L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Button btnLuuThayDoi;
        private System.Windows.Forms.GroupBox radGroupBox1;
        private System.Windows.Forms.ComboBox tbTenLop;
        private System.Windows.Forms.NumericUpDown SLSVTD1N;
        private System.Windows.Forms.NumericUpDown SLNTD;
        private System.Windows.Forms.NumericUpDown SLSV1L;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
    }
}