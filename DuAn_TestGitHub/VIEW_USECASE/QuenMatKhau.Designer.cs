namespace VIEW_USECASE
{
    partial class QuenMatKhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTK = new System.Windows.Forms.TextBox();
            this.btnLayMaXacThuc = new System.Windows.Forms.Button();
            this.lbNote = new System.Windows.Forms.Label();
            this.tbMaXacNhan = new System.Windows.Forms.TextBox();
            this.tbMKM = new System.Windows.Forms.TextBox();
            this.tbXNMKM = new System.Windows.Forms.TextBox();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.lbMXT = new System.Windows.Forms.Label();
            this.lbMKM = new System.Windows.Forms.Label();
            this.lbXNMKM = new System.Windows.Forms.Label();
            this.lbNote2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản";
            // 
            // tbTK
            // 
            this.tbTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTK.Location = new System.Drawing.Point(145, 18);
            this.tbTK.Name = "tbTK";
            this.tbTK.Size = new System.Drawing.Size(261, 30);
            this.tbTK.TabIndex = 1;
            // 
            // btnLayMaXacThuc
            // 
            this.btnLayMaXacThuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLayMaXacThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayMaXacThuc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLayMaXacThuc.Location = new System.Drawing.Point(33, 67);
            this.btnLayMaXacThuc.Name = "btnLayMaXacThuc";
            this.btnLayMaXacThuc.Size = new System.Drawing.Size(412, 50);
            this.btnLayMaXacThuc.TabIndex = 2;
            this.btnLayMaXacThuc.Text = "Lấy mã xác thực";
            this.btnLayMaXacThuc.UseVisualStyleBackColor = false;
            this.btnLayMaXacThuc.Click += new System.EventHandler(this.btnLayMaXacThuc_Click);
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.ForeColor = System.Drawing.Color.Blue;
            this.lbNote.Location = new System.Drawing.Point(30, 131);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(0, 15);
            this.lbNote.TabIndex = 3;
            // 
            // tbMaXacNhan
            // 
            this.tbMaXacNhan.Enabled = false;
            this.tbMaXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaXacNhan.Location = new System.Drawing.Point(203, 175);
            this.tbMaXacNhan.Name = "tbMaXacNhan";
            this.tbMaXacNhan.Size = new System.Drawing.Size(242, 30);
            this.tbMaXacNhan.TabIndex = 1;
            // 
            // tbMKM
            // 
            this.tbMKM.Enabled = false;
            this.tbMKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMKM.Location = new System.Drawing.Point(203, 238);
            this.tbMKM.Name = "tbMKM";
            this.tbMKM.Size = new System.Drawing.Size(242, 30);
            this.tbMKM.TabIndex = 1;
            // 
            // tbXNMKM
            // 
            this.tbXNMKM.Enabled = false;
            this.tbXNMKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbXNMKM.Location = new System.Drawing.Point(203, 297);
            this.tbXNMKM.Name = "tbXNMKM";
            this.tbXNMKM.Size = new System.Drawing.Size(242, 30);
            this.tbXNMKM.TabIndex = 1;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.Blue;
            this.btnDoiMatKhau.Enabled = false;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(33, 378);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(412, 50);
            this.btnDoiMatKhau.TabIndex = 4;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // lbMXT
            // 
            this.lbMXT.AutoSize = true;
            this.lbMXT.Enabled = false;
            this.lbMXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMXT.Location = new System.Drawing.Point(28, 175);
            this.lbMXT.Name = "lbMXT";
            this.lbMXT.Size = new System.Drawing.Size(118, 25);
            this.lbMXT.TabIndex = 0;
            this.lbMXT.Text = "Mã xác thực";
            // 
            // lbMKM
            // 
            this.lbMKM.AutoSize = true;
            this.lbMKM.Enabled = false;
            this.lbMKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMKM.Location = new System.Drawing.Point(28, 238);
            this.lbMKM.Name = "lbMKM";
            this.lbMKM.Size = new System.Drawing.Size(129, 25);
            this.lbMKM.TabIndex = 0;
            this.lbMKM.Text = "Mật khẩu mới";
            // 
            // lbXNMKM
            // 
            this.lbXNMKM.AutoSize = true;
            this.lbXNMKM.Enabled = false;
            this.lbXNMKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXNMKM.Location = new System.Drawing.Point(28, 300);
            this.lbXNMKM.Name = "lbXNMKM";
            this.lbXNMKM.Size = new System.Drawing.Size(168, 25);
            this.lbXNMKM.TabIndex = 0;
            this.lbXNMKM.Text = "Nhập lại mật khẩu";
            // 
            // lbNote2
            // 
            this.lbNote2.AutoSize = true;
            this.lbNote2.Enabled = false;
            this.lbNote2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote2.ForeColor = System.Drawing.Color.Red;
            this.lbNote2.Location = new System.Drawing.Point(30, 341);
            this.lbNote2.Name = "lbNote2";
            this.lbNote2.Size = new System.Drawing.Size(0, 15);
            this.lbNote2.TabIndex = 3;
            // 
            // QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 454);
            this.Controls.Add(this.btnDoiMatKhau);
            this.Controls.Add(this.lbNote2);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.btnLayMaXacThuc);
            this.Controls.Add(this.tbXNMKM);
            this.Controls.Add(this.tbMKM);
            this.Controls.Add(this.tbMaXacNhan);
            this.Controls.Add(this.tbTK);
            this.Controls.Add(this.lbXNMKM);
            this.Controls.Add(this.lbMKM);
            this.Controls.Add(this.lbMXT);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "QuenMatKhau";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quên mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTK;
        private System.Windows.Forms.Button btnLayMaXacThuc;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.TextBox tbMaXacNhan;
        private System.Windows.Forms.TextBox tbMKM;
        private System.Windows.Forms.TextBox tbXNMKM;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Label lbMXT;
        private System.Windows.Forms.Label lbMKM;
        private System.Windows.Forms.Label lbXNMKM;
        private System.Windows.Forms.Label lbNote2;
    }
}