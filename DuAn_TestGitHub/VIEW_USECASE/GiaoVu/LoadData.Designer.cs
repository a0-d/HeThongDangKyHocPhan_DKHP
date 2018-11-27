namespace VIEW_USECASE.GiaoVu
{
    partial class LoadData
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlTatCaChuyenDe = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPageChuyenDeDuocMo = new System.Windows.Forms.TabPage();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.tbTimKiem = new Telerik.WinControls.UI.RadTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlTatCaChuyenDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPageChuyenDeDuocMo);
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 18);
            this.tabControl1.Location = new System.Drawing.Point(1, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1301, 490);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControlTatCaChuyenDe);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1293, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tất cả chuyên đề";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControlTatCaChuyenDe
            // 
            this.tabControlTatCaChuyenDe.Controls.Add(this.tabPage3);
            this.tabControlTatCaChuyenDe.Controls.Add(this.tabPage4);
            this.tabControlTatCaChuyenDe.Location = new System.Drawing.Point(760, 265);
            this.tabControlTatCaChuyenDe.Name = "tabControlTatCaChuyenDe";
            this.tabControlTatCaChuyenDe.SelectedIndex = 0;
            this.tabControlTatCaChuyenDe.Size = new System.Drawing.Size(8, 8);
            this.tabControlTatCaChuyenDe.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(0, 0);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(0, 0);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPageChuyenDeDuocMo
            // 
            this.tabPageChuyenDeDuocMo.Location = new System.Drawing.Point(4, 22);
            this.tabPageChuyenDeDuocMo.Name = "tabPageChuyenDeDuocMo";
            this.tabPageChuyenDeDuocMo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChuyenDeDuocMo.Size = new System.Drawing.Size(1293, 527);
            this.tabPageChuyenDeDuocMo.TabIndex = 1;
            this.tabPageChuyenDeDuocMo.Text = "Chuyên đề được mở";
            this.tabPageChuyenDeDuocMo.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTimKiem.Location = new System.Drawing.Point(618, 17);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 37);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.tbTimKiem.ForeColor = System.Drawing.Color.Blue;
            this.tbTimKiem.Location = new System.Drawing.Point(12, 12);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.tbTimKiem.Size = new System.Drawing.Size(575, 44);
            this.tbTimKiem.TabIndex = 8;
            // 
            // LoadData
            // 
            this.AcceptButton = this.btnTimKiem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 550);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.tbTimKiem);
            this.Controls.Add(this.tabControl1);
            this.Name = "LoadData";
            this.Text = "LoadData";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControlTatCaChuyenDe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControlTatCaChuyenDe;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPageChuyenDeDuocMo;
        private System.Windows.Forms.Button btnTimKiem;
        private Telerik.WinControls.UI.RadTextBox tbTimKiem;
    }
}