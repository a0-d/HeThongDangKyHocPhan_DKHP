namespace VIEW_USECASE
{
    partial class ChonLoaiTaiKhoan_DangKy
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
            this.btnSV = new System.Windows.Forms.Button();
            this.btnGVGV = new System.Windows.Forms.Button();
            this.btnCanCel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vui lòng chọn loại tài khoản muốn đăng ký";
            // 
            // btnSV
            // 
            this.btnSV.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSV.Location = new System.Drawing.Point(16, 50);
            this.btnSV.Name = "btnSV";
            this.btnSV.Size = new System.Drawing.Size(147, 48);
            this.btnSV.TabIndex = 1;
            this.btnSV.Text = "Sinh Viên";
            this.btnSV.UseVisualStyleBackColor = false;
            this.btnSV.Click += new System.EventHandler(this.btnSV_Click);
            // 
            // btnGVGV
            // 
            this.btnGVGV.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGVGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGVGV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGVGV.Location = new System.Drawing.Point(169, 50);
            this.btnGVGV.Name = "btnGVGV";
            this.btnGVGV.Size = new System.Drawing.Size(148, 48);
            this.btnGVGV.TabIndex = 2;
            this.btnGVGV.Text = "Giáo Viên/Giáo Vụ";
            this.btnGVGV.UseVisualStyleBackColor = false;
            this.btnGVGV.Click += new System.EventHandler(this.btnGVGV_Click);
            // 
            // btnCanCel
            // 
            this.btnCanCel.Location = new System.Drawing.Point(233, 120);
            this.btnCanCel.Name = "btnCanCel";
            this.btnCanCel.Size = new System.Drawing.Size(75, 23);
            this.btnCanCel.TabIndex = 3;
            this.btnCanCel.Text = "Cancel";
            this.btnCanCel.UseVisualStyleBackColor = true;
            this.btnCanCel.Click += new System.EventHandler(this.btnCanCel_Click);
            // 
            // ChonLoaiTaiKhoan_DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 155);
            this.ControlBox = false;
            this.Controls.Add(this.btnCanCel);
            this.Controls.Add(this.btnGVGV);
            this.Controls.Add(this.btnSV);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Name = "ChonLoaiTaiKhoan_DangKy";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông báo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSV;
        private System.Windows.Forms.Button btnGVGV;
        private System.Windows.Forms.Button btnCanCel;
    }
}