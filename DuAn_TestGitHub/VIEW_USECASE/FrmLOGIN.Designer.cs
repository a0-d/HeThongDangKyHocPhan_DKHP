namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label5 = new System.Windows.Forms.Label();
            this.tb_MK = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.tb_TenTK = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNote = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(145, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 42);
            this.label5.TabIndex = 36;
            this.label5.Text = "LOGIN";
            // 
            // tb_MK
            // 
            this.tb_MK.BorderColorFocused = System.Drawing.Color.DarkTurquoise;
            this.tb_MK.BorderColorIdle = System.Drawing.Color.DarkCyan;
            this.tb_MK.BorderColorMouseHover = System.Drawing.Color.DarkTurquoise;
            this.tb_MK.BorderThickness = 3;
            this.tb_MK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_MK.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tb_MK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb_MK.isPassword = true;
            this.tb_MK.Location = new System.Drawing.Point(176, 179);
            this.tb_MK.Margin = new System.Windows.Forms.Padding(4);
            this.tb_MK.Name = "tb_MK";
            this.tb_MK.Size = new System.Drawing.Size(224, 44);
            this.tb_MK.TabIndex = 1;
            this.tb_MK.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tb_TenTK
            // 
            this.tb_TenTK.BorderColorFocused = System.Drawing.Color.DarkTurquoise;
            this.tb_TenTK.BorderColorIdle = System.Drawing.Color.DarkCyan;
            this.tb_TenTK.BorderColorMouseHover = System.Drawing.Color.DarkTurquoise;
            this.tb_TenTK.BorderThickness = 3;
            this.tb_TenTK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_TenTK.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tb_TenTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb_TenTK.isPassword = false;
            this.tb_TenTK.Location = new System.Drawing.Point(176, 118);
            this.tb_TenTK.Margin = new System.Windows.Forms.Padding(4);
            this.tb_TenTK.Name = "tb_TenTK";
            this.tb_TenTK.Size = new System.Drawing.Size(224, 44);
            this.tb_TenTK.TabIndex = 0;
            this.tb_TenTK.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(63, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(24, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "ngay.";
            // 
            // linkLabel2
            // 
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.DarkCyan;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabel2.LinkColor = System.Drawing.Color.DarkCyan;
            this.linkLabel2.Location = new System.Drawing.Point(260, 392);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(62, 17);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Đăng Ký";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkCyan;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkCyan;
            this.linkLabel1.Location = new System.Drawing.Point(162, 358);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Bạn chưa có tài khoản? Nhấn";
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.ForeColor = System.Drawing.Color.Red;
            this.lbNote.Location = new System.Drawing.Point(18, 256);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(0, 20);
            this.lbNote.TabIndex = 37;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.LightCyan;
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnDangNhap.Location = new System.Drawing.Point(28, 284);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(372, 49);
            this.btnDangNhap.TabIndex = 38;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 463);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_MK);
            this.Controls.Add(this.tb_TenTK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuMetroTextbox tb_MK;
        private Bunifu.Framework.UI.BunifuMetroTextbox tb_TenTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Button btnDangNhap;
    }
}

