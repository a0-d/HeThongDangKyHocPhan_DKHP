using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_USECASE.GiaoVu;
using VIEW_USECASE.GiaoVu.TraCuu;

namespace VIEW_USECASE
{
    public partial class FrmGiaoVu : Form
    {
        public FrmGiaoVu()
        {
            //update
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            panel.Controls.Clear();
            LoadData frm = new LoadData();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }
        private void btnThemCD_Click(object sender, EventArgs e)
        {
            this.panel.Controls.Clear();
            ThemChuyenDe frm = new ThemChuyenDe();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            this.panel.Controls.Add(frm);
            frm.Show();
        }

        //Button tra cứu điểm . vì chưa đổi tên button
        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            panelTraCuu.Controls.Clear();
            TraCuuDiem frm = new TraCuuDiem();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            panelTraCuu.Controls.Add(frm);
            frm.Show();
        }

        //Button tra cứu thông tin đăng ký . vì chưa đổi tên button
        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            panelTraCuu.Controls.Clear();
            TraCuuThongTinDangKy frm = new TraCuuThongTinDangKy();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panelTraCuu.Controls.Add(frm);
            frm.Show();
        }

        private void btnSuaCD_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            SuaChuyenDe frm = new SuaChuyenDe();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }

        private void btnMoCD_Click(object sender, EventArgs e)
        {
            this.panel.Controls.Clear();
            MoChuyenDe frm = new MoChuyenDe();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            this.panel.Controls.Add(frm);
            frm.Show();
        }

        private void btnCapNhatCD_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatChuyenDeDangDuocMo frm = new CapNhatChuyenDeDangDuocMo();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }
        private void btnCapNhatGiaoVienPhuTrachCD_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            CapNhatGiaoVienPhuTrach frm = new CapNhatGiaoVienPhuTrach();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            LoadData frm = new LoadData();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            tbTenTK.Enabled = true;
            tbCTK.Enabled = true;
            tbEmail.Enabled = true;
            tbChucVu.Enabled = true;
            tbNgayBatDau.Enabled = true;
            btnLuuChinhSua.Enabled = true;
            btnDoiMatKhau.Enabled = false;
            btnChinhSua.Enabled = false;
        }

        private void btnLuuChinhSua_Click(object sender, EventArgs e)
        {
            tbTenTK.Enabled = false;
            tbCTK.Enabled = false;
            tbEmail.Enabled = false;
            tbChucVu.Enabled = false;
            tbNgayBatDau.Enabled = false;
            btnLuuChinhSua.Enabled = false;
            btnDoiMatKhau.Enabled = true;
            btnChinhSua.Enabled = true;
        }

        
    }
}
