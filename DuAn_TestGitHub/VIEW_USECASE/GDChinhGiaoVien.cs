using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEW_USECASE
{
    public partial class GDChinhGiaoVien : Form
    {
        string IDChuyenDe = "";

        public GDChinhGiaoVien()
        {
            InitializeComponent();
            //dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = true;
        }
        private void GDChinhGiaoVien_Load_1(object sender, EventArgs e)
        {
            //ComboxLop_Load(sender, e);
            TT orders1 = new TT();
            DataTable dt = orders1.LayDSChuyeDeDuocMo();

            dataGridViewChuyenDe.DataSource = dt;        
        }

    private void button13_Click(object sender, EventArgs e)
        {
            panelChinh.Visible = false;

            panelQT.Visible = false;
            button_QT_LuuChinhSua.Enabled = true;
            button_QT_ChinhSua.Enabled = false;
            tb_QT_TenTK.ReadOnly = false;
            tb_QT_TenChuTK.ReadOnly = false;
            tb_QT_NgayBDCongTac.ReadOnly = false;
            tb_QT_ChucVu.ReadOnly = false;
            tb_QT_Email.ReadOnly = false;
            tb_QT_ThuocNganh.ReadOnly = false;
            //dataGridViewTraCuu.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            button_QT_DoiMatKhau.Enabled = true;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;

        }

        private void button_QT_LuuChinhSua_Click(object sender, EventArgs e)
        {
            //dataGridViewTraCuu.Visible = false;
            panelChinh.Visible = false;

            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelQT.Visible = false;
            button_QT_ChinhSua.Enabled = true;
            tb_QT_TenTK.ReadOnly = true;
            tb_QT_TenChuTK.ReadOnly = true;
            tb_QT_NgayBDCongTac.ReadOnly = true;
            tb_QT_ChucVu.ReadOnly = true;
            tb_QT_Email.ReadOnly = true;
            tb_QT_ThuocNganh.ReadOnly = true;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;

        }

        private void button_QT_DoiMatKhau_Click(object sender, EventArgs e)
        {
            panelQT.Visible = true;
            //dataGridViewTraCuu.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelChinh.Visible = false;

            button_QT_DoiMatKhau.Enabled = false;
            labelMKC.Visible = true;
            labelMKM.Visible = true;
            labelXNMKM.Visible = true;
            labelNOTE1.Visible = true;
            labelNOTE2.Visible = true;
            labelNOTE3.Visible = true;
            tb_QT_MKC.Visible = true;
            tb_QT_MKM.Visible = true;
            tb_QT_XNMKM.Visible = true;
            buttonDoiMatKhau.Visible = true;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;

        }

        private void btnTraCuuDiem_Click(object sender, EventArgs e)
        {
            //dataGridViewTraCuu.Visible = true;
            groupBoxTraCuuTTDK.Visible = false;
            groupBoxTraCuuDiem.Visible = true;
            panelQT.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }

        private void btnTraCuuTT_Click(object sender, EventArgs e)
        {
            //dataGridViewTraCuu.Visible = true;
            groupBoxTraCuuTTDK.Visible = true;
            groupBoxTraCuuDiem.Visible = false;
            panelQT.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }

        private void btnCNSLLop_Click(object sender, EventArgs e)
        {
            panel_CapNhatSLLop.Visible = true;
            gbxCapNhatSLLop.Visible = true;
            panelQT.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            // dataGridViewTraCuu.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }

        private void GDChinhGiaoVien_Load(object sender, EventArgs e)
        {
            panel_CapNhatSLLop.Visible = true;
            gbxCapNhatSLLop.Visible = true;
            panelQT.Visible = false;
            //   dataGridViewTraCuu.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void button6_Click(object sender, EventArgs e)
        {

        }

        

        private void panel_CapNhatSLLop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCapNhatSLSV_Click(object sender, EventArgs e)
        {
            panel_CapNhatSLSV_N.Visible = true;
            gbxCapNhatSLSV.Visible = true;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelQT.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

            //dataGridViewTraCuu.Visible = false;
        }

        private void btnThemDead_Click(object sender, EventArgs e)
        {
            panelThemDead.Visible = true;
            gbxThemDead.Visible = true;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelQT.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }
        private void dataGridViewChuyenDe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadText();
        }
        private void LoadText()
        {
            IDChuyenDe = dataGridViewChuyenDe.CurrentRow.Cells["macd"].Value.ToString();
        }


        private void btnCapNhatDead_Click(object sender, EventArgs e)
        {
            panel_CapNhatDead.Visible = true;
            gbxCapNhatDead.Visible = true;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelQT.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }

        private void btnThemCDDay_Click(object sender, EventArgs e)
        {
            panel_KhaNang.Visible = true;
            gbxKhaNang.Visible = true;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelQT.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }


        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất!");
            Close();
        }

        private void buttonDoiMatKhau_Click(object sender, EventArgs e)
        {
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelQT.Visible = true;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            button_QT_DoiMatKhau.Enabled = true;
            panel_TraCuuDiem.Visible = false;
            panelChinh.Visible = false;

        }

        private void btnTraCuuDiem_act_Click(object sender, EventArgs e)
        {
            groupBoxTraCuuTTDK.Visible = false;
            groupBoxTraCuuDiem.Visible = true;
            panelQT.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = true;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;

        }

        private void btnTraCuuTTDK_act_Click(object sender, EventArgs e)
        {
            groupBoxTraCuuTTDK.Visible = false;
            groupBoxTraCuuDiem.Visible = true;
            panelQT.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = true;
            panelChinh.Visible = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBoxTraCuuTTDK.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            panelQT.Visible = false;
            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panelThemDead.Visible = false;
            gbxThemDead.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = true;
        }
        private void ComboxLop_Load(object sender, EventArgs e)
        {
            TT orders = new TT();
            DataTable dt = orders.LopCombobox(IDChuyenDe);

            dt.Columns.Add("malop", typeof(string));
            dt.Dispose();
            cbLopCapNhatDead.ValueMember = "malop";
            cbChonLopThemDead.ValueMember = "malop";
            cbLopCapNhatDead.DataSource = dt;
            cbChonLopThemDead.DataSource = dt;

        }

        private void txtMaDeadThem_Load(object sender, EventArgs e)
        {
            TT max = new TT();
            int x = max.GetMaxOrderIDDEAD();
            x++;
            txtMaDeadThem.Text = Convert.ToString(x);
        }

        private void btnCapNhatThemDead_Click(object sender, EventArgs e)
        {
            string malop = cbChonLopThemDead.Text;
            int id = Convert.ToInt32(txtMaDeadThem.Text);
            string tendead = txtTenDeadThem.Text;
            DateTime thoihanThemDead = Convert.ToDateTime(dtDeadThem.Text);

            if (malop == "" || tendead == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                TT addDead = new TT();
                addDead.InsertDead(malop, id, tendead, thoihanThemDead);
                MessageBox.Show("Đã Thêm Deadline thành công!");
            }
        }
    }
}
