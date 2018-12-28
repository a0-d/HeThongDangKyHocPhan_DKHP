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
using VIEW_BUS.DAO_GiaoVien.TTGiaoVien;

namespace VIEW_USECASE
{
    public partial class GDChinhGiaoVien : Form
    {
        string IDChuyenDe = "";

        public string IDNguoiDung = "ND07";
        public GDChinhGiaoVien()
        {
            InitializeComponent();
            tabcontrolChucNang.SelectedIndex = 0;
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

        private void GDChinhGiaoVien_Load(object sender, EventArgs e)
        {


            TTGiaoVien chuyende = new TTGiaoVien();
            DataTable dt = chuyende.LayDSChuyeDeDuocMo();
            DataTable dt1 = chuyende.LayDSChuyeDe();
            DataTable dt2 = chuyende.LayDSChuyeDeDangDay(IDNguoiDung);
            DataTable dt3 = chuyende.LayDSChuyeDeDangDayCOLOP(IDNguoiDung);


            chuyende.MaNguoiDung = IDNguoiDung;



            dataGridViewDangMo.DataSource = dt;
            dataGridViewCDAll.DataSource = dt1;
            dataGridViewDangDay.DataSource = dt3;
            dgvDSChuyenDeDay.DataSource = dt2;
        }
        private void ChuyenTab_Load(object sender, EventArgs e)
        {
            if (tabcontrolChucNang.SelectedIndex == 0)
            {
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
            if (tabcontrolChucNang.SelectedIndex == 1)
            {
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
            if (tabcontrolChucNang.SelectedIndex == 2)
            {
                panelChinh.Visible = false;

                panelQT.Visible = false;
                button_QT_LuuChinhSua.Enabled = false;
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

                tb_QT_TenTK.Text = IDNguoiDung;
                TTGiaoVien info = new TTGiaoVien();
                tb_QT_TenChuTK.Text = info.TenNguoiDungtxt(IDNguoiDung);
                tb_QT_Email.Text = info.MailNguoiDungtxt(IDNguoiDung);
                tb_QT_ThuocNganh.Text = info.NganhNguoiDungtxt(IDNguoiDung);
                dateTimePickerNgCT.Value = info.NgayCTNguoiDungtxt(IDNguoiDung);

            }


        }



        private void dataGridViewChuyenDe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadText();
            btnCapNhatDead.Enabled = true;
            btnThemDead.Enabled = true;
            btnCNSLLop.Enabled = true;
            btnCapNhatSLSV.Enabled = true;
        }
        private void dataGridViewChuyenDeFalse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadText();
            btnCapNhatDead.Enabled = false;
            btnThemDead.Enabled = false;
            btnCNSLLop.Enabled = false;
            btnCapNhatSLSV.Enabled = false;
        }
        private void LoadText()
        {
            IDChuyenDe = dataGridViewDangDay.CurrentRow.Cells["clMaCD"].Value.ToString();
        }



        //Set Mã Dead Auto tăng dần


        private void txtMaDeadThem_Load(object sender, EventArgs e)
        {


        }
        private int checkmk()
        {
            int kq = 0;
            TTGiaoVien mk = new TTGiaoVien();
            string mktemp = mk.LayMatKhau(IDNguoiDung);
            mktemp = mktemp.Replace(" ", "");
            if (mktemp == tb_QT_MKC.Text)
            {
                kq = 1;
            }
            return kq;
        }
        //Load Combobox
        private void ComboxLop_Load(object sender, EventArgs e)
        {
            TTGiaoVien orders = new TTGiaoVien();
            DataTable dt = orders.LopCombobox(IDChuyenDe);

            dt.Columns.Add("malop", typeof(string));
            dt.Dispose();
            cbLopCapNhatDead.ValueMember = "malop";
            cbChonLopThemDead.ValueMember = "malop";
            cbLopCapNhatDead.DataSource = dt;
            cbChonLopThemDead.DataSource = dt;

        }

        private void ComboxDead_Load(object sender, EventArgs e)
        {
            TTGiaoVien a = new TTGiaoVien();
            DataTable dt = a.DeadCombobox(cbLopCapNhatDead.Text);

            dt.Columns.Add("madead", typeof(string));
            dt.Dispose();
            cbMaDead.ValueMember = "madead";
            cbMaDead.DataSource = dt;

        }
        private void ComboxNam_Load(object sender, EventArgs e)
        {
            TTGiaoVien a = new TTGiaoVien();
            DataTable dt = a.NamCombobox();

            dt.Columns.Add("namhoc", typeof(string));
            dt.Dispose();
            cbxNamHocTTDK.ValueMember = "namhoc";
            cbxNamHocTTDK.DataSource = dt;

        }
        private void ComboxMaCD_Load(object sender, EventArgs e)
        {
            TTGiaoVien a = new TTGiaoVien();
            DataTable dt = a.MaCDDayCombobox();

            dt.Columns.Add("macd", typeof(string));
            dt.Dispose();
            cbxMaChuyenDeTTDK.ValueMember = "macd";
            cbxMaChuyenDeTTDK.DataSource = dt;
            cbxMaCDDiem.ValueMember = "macd";
            cbxMaCDDiem.DataSource = dt;

        }
        private void ComboxTenCDCoSan_Load(object sender, EventArgs e)
        {
            TTGiaoVien a = new TTGiaoVien();
            DataTable dt = a.TenCDCombobox();

            dt.Columns.Add("tencd", typeof(string));
            dt.Dispose();
            cbxTenCD.ValueMember = "tencd";
            cbxTenCD.DataSource = dt;

        }


        //Load txt theo dữ liệu chọn
        private void AddItems_Load(object sender, EventArgs e)
        {
            TTGiaoVien ten = new TTGiaoVien();
            txtTenCDCNSV.Text = ten.TenCDtxt(IDChuyenDe);
            txtTenCD.Text = ten.TenCDtxt(IDChuyenDe);
            txtSLSVCNLop.Text = ten.SoLuongLop(IDChuyenDe).ToString();
            txtNhomCapNhat.Text = ten.SoLuongNhom(IDChuyenDe).ToString();
            txtSinhVienCN.Text = ten.SoLuongSinhVien(IDChuyenDe).ToString();
        }
        private void cbxMaChuyenDeTTDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTGiaoVien ten = new TTGiaoVien();
            txtTenChuyenDeTTDK.Text = ten.TenCDtxt(cbxMaChuyenDeTTDK.Text);
        }
        private void cbxMaCDDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTGiaoVien ten = new TTGiaoVien();
            txtTenCDDiem.Text = ten.TenCDtxt(cbxMaCDDiem.Text);
        }
        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            TTGiaoVien ten = new TTGiaoVien();
            txtTenSinhVien.Text = ten.TenSinhVien(txtMaSV.Text);
        }



        //ButtonClick

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
            AddItems_Load(sender, e);

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
        private void btnHuyDoiMatKhau_Click(object sender, EventArgs e)
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
            panelQT.Visible = false;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = false;
            button_QT_DoiMatKhau.Enabled = true;
            panel_TraCuuDiem.Visible = false;
            panelChinh.Visible = false;
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

            if (tb_QT_MKM.Text == "" || tb_QT_MKC.Text == "" || tb_QT_XNMKM.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                if (tb_QT_MKM.Text != tb_QT_XNMKM.Text)
                {
                    MessageBox.Show("Bạn Đã Xác Nhận Lại Mật Khẩu Sai!");
                }
                else
                {
                    if (checkmk() == 1)
                    {

                        TTGiaoVien updatemk = new TTGiaoVien();
                        updatemk.UpdateMatKhau(IDNguoiDung, tb_QT_MKM.Text, tb_QT_MKC.Text);
                        MessageBox.Show("Đã Cập Nhật Mật Khẩu thành công!");
                        tb_QT_MKM.ResetText();
                        tb_QT_MKC.ResetText();
                        tb_QT_XNMKM.ResetText();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ sai!");

                    }
                }
            }
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
            if (txtMaSV.Text == "")
            {
                TTGiaoVien kq = new TTGiaoVien();
                DataTable dt = kq.LayKetQuaDiemKoSV(cbxMaCDDiem.Text);
                dataGridViewTraCuuDiem.DataSource = dt;
            }
            else
            {
                TTGiaoVien kq = new TTGiaoVien();
                DataTable dt = kq.LayKetQuaDiem(txtMaSV.Text, cbxMaCDDiem.Text);
                dataGridViewTraCuuDiem.DataSource = dt;
            }
        }

        private void btnTraCuuTTDK_act_Click(object sender, EventArgs e)
        {
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
            panelTraCuuTTDK.Visible = true;
            panelChinh.Visible = false;
            if (cbxHocKiTTDK.Text == "" || cbxNamHocTTDK.Text == "")
            {
                MessageBox.Show("Bạn vui lòng chọn đủ thông tin!");
                return;
            }

            TTGiaoVien tt = new TTGiaoVien();
            DataTable dt = tt.LayThongTinDangKy(cbxMaChuyenDeTTDK.Text, cbxNamHocTTDK.Text, Convert.ToInt32(cbxHocKiTTDK.Text), IDNguoiDung);


            dataGridViewTraCuuTTDK.DataSource = dt;
        }

        private void btnVeTrangChu_Click(object sender, EventArgs e)
        {
            tabcontrolChucNang.SelectedIndex = 0;
            panelSearch.Visible = false;
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
            panelSearch.Visible = false;
            tabControl1.Visible = true;

        }
        private void button_QT_ChinhSua_Click(object sender, EventArgs e)
        {
            panelChinh.Visible = false;

            panelQT.Visible = false;
            button_QT_LuuChinhSua.Enabled = true;
            button_QT_ChinhSua.Enabled = false;
            tb_QT_TenChuTK.ReadOnly = false;
            dateTimePickerNgCT.Enabled = true;
            tb_QT_Email.ReadOnly = false;
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
            panelChinh.Visible = false;

            panel_CapNhatSLLop.Visible = false;
            gbxCapNhatSLLop.Visible = false;
            panelQT.Visible = false;
            button_QT_ChinhSua.Enabled = true;
            tb_QT_TenTK.ReadOnly = true;
            tb_QT_TenChuTK.ReadOnly = true;
            dateTimePickerNgCT.Enabled = false;
            button_QT_LuuChinhSua.Enabled = false;
            tb_QT_Email.ReadOnly = true;
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

            if (tb_QT_TenTK.Text == "" || tb_QT_Email.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                TTGiaoVien update = new TTGiaoVien();
                update.UpdateThongTinNguoiDung(IDNguoiDung, tb_QT_TenChuTK.Text, tb_QT_Email.Text, dateTimePickerNgCT.Value);
                MessageBox.Show("Đã Cập Nhật Thông Tin Thành công!");
            }
            GDChinhGiaoVien_Load(sender, e);

        }

        private void button_QT_DoiMatKhau_Click(object sender, EventArgs e)
        {
            panelQT.Visible = true;
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
            panel_CapNhatSLSV_N.Visible = false;
            gbxCapNhatSLSV.Visible = false;
            panel_CapNhatDead.Visible = false;
            gbxCapNhatDead.Visible = false;
            panel_KhaNang.Visible = false;
            gbxKhaNang.Visible = false;
            panel_TraCuuDiem.Visible = false;
            panelTraCuuTTDK.Visible = false;
            panelChinh.Visible = false;
            AddItems_Load(sender, e);

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
            AddItems_Load(sender, e);
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
            AddItems_Load(sender, e);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng xuất!");
            Close();
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
                TTGiaoVien addDead = new TTGiaoVien();
                addDead.InsertDead(malop, id, tendead, thoihanThemDead);
                MessageBox.Show("Đã Thêm Deadline thành công!");
            }

            cbChonLopThemDead.ResetText();
            txtTenDeadThem.ResetText();
            txtMaDeadThem_Load(sender, e);
        }

        private void btnUpdateDead_Click(object sender, EventArgs e)
        {
            string malop = cbChonLopThemDead.Text;
            int id = Convert.ToInt32(cbMaDead.Text);
            string tendead = txtTenDead.Text;
            DateTime thoihanThemDead = Convert.ToDateTime(dtThoiHanCapNhat.Text);

            if (malop == "" || tendead == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                TTGiaoVien addDead = new TTGiaoVien();
                addDead.UpdateDead(id, tendead, thoihanThemDead, cbLopCapNhatDead.Text);
                MessageBox.Show("Đã Cập Nhật Deadline thành công!");
            }

        }

        private void btnCapNhatNhom_Click(object sender, EventArgs e)
        {
            if (txtSinhVienCN.Text == "" || txtNhomCapNhat.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                TTGiaoVien update = new TTGiaoVien();
                update.UpdateNhomVsSV(IDChuyenDe, Convert.ToInt32(txtSinhVienCN.Text), Convert.ToInt32(txtNhomCapNhat.Text));
                MessageBox.Show("Đã Cập Nhật Thông Tin Thành công!");
            }
            GDChinhGiaoVien_Load(sender, e);
            btnVeTrangChu_Click(sender, e);

        }

        private void btnCapNhatLH_Click(object sender, EventArgs e)
        {
            TTGiaoVien a = new TTGiaoVien();

            int solopcu = a.SoLuongLop(IDChuyenDe);
            string tenlop = a.LayTenLop(IDChuyenDe, solopcu);
            int temp = solopcu;

            int solop = Convert.ToInt32(txtSLSVCNLop.Text);
            string lopid;
            if (solop > 20)
            {
                MessageBox.Show("Số lượng lớp phải nhỏ hơn 20!");
                return;
            }
            if (solop <= 0)
            {
                MessageBox.Show("Số lượng lớp lớn hơn 0!");
                return;

            }
            if (solop > solopcu)
            {
                while (solop != temp)
                {
                    temp++;
                    lopid = tenlop.Replace(IDChuyenDe + solopcu.ToString(), "");
                    lopid = lopid.Replace(" ", "") + IDChuyenDe + temp;
                    a.InsertLop(IDChuyenDe, lopid);
                }
            }
            if (solop < solopcu)
            {
                while (solop != temp)
                {
                    lopid = tenlop.Replace(IDChuyenDe + solopcu.ToString(), "");
                    lopid = lopid.Replace(" ", "") + IDChuyenDe + temp;

                    a.DeleteLop(IDChuyenDe, lopid);
                    temp--;

                }

            }


            MessageBox.Show("Số Lượng Lớp Đã Được Cập Nhật!");

            GDChinhGiaoVien_Load(sender, e);
            btnVeTrangChu_Click(sender, e);
        }

        private void btnThemCDKhaNang_Click(object sender, EventArgs e)
        {
            if (cbxTenCD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên chuyên đề!");
            }
            else
            {


                TTGiaoVien khanang = new TTGiaoVien();
                int temp = khanang.CheckKhaNang(IDNguoiDung, cbxTenCD.Text);
                if (khanang.CheckKhaNang(IDNguoiDung, cbxTenCD.Text) == 1)
                {
                    MessageBox.Show("Giáo Viên Đã Có Sẵn Khả Năng Dạy Môn Học Này!");

                }
                else
                {
                    khanang.InsertKhaNang(cbxTenCD.Text, IDNguoiDung);
                    MessageBox.Show("Đã Thêm Thông Tin Thành công!");
                }

            }
            GDChinhGiaoVien_Load(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panelSearch.Visible = true;
            tabControl1.Visible = false;
            TTGiaoVien tt = new TTGiaoVien();
            DataTable dt = tt.LayThongTinTimKiem(txtSearch.Text);


            dataGridViewSearch.DataSource = dt;
            if (dataGridViewSearch.RowCount == 1)
            {
                MessageBox.Show("Dữ liệu cần tìm không có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbMaDead_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTGiaoVien ma = new TTGiaoVien();
            txtTenDead.Text = ma.LayTenDead(cbMaDead.Text, cbLopCapNhatDead.Text);
            dtThoiHanCapNhat.Value = ma.LayThoiHanDead(cbMaDead.Text, cbLopCapNhatDead.Text);
        }

        private void btnXoaCDKhaNang_Click(object sender, EventArgs e)
        {
            if (cbxTenCD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên chuyên đề!");
            }
            else
            {

                TTGiaoVien khanang = new TTGiaoVien();
                int temp = khanang.CheckKhaNangXoa(IDNguoiDung, cbxTenCD.Text);
                if (khanang.CheckKhaNangXoa(IDNguoiDung, cbxTenCD.Text) == 1)
                {
                    MessageBox.Show("Không thể xóa môn học này trong khả năng, vì bạn đang có lớp môn này!");
                    return;
                }
                if (khanang.CheckKhaNang(IDNguoiDung, cbxTenCD.Text) == 0)
                {
                    MessageBox.Show("Giáo Viên Chưa Có Sẵn Khả Năng Dạy Môn Học Này!");

                }
                else
                {
                    khanang.DeleteKhaNang(cbxTenCD.Text, IDNguoiDung);
                    MessageBox.Show("Đã Xóa Thông Tin Thành công!");
                }

            }
            GDChinhGiaoVien_Load(sender, e);
        }

        private void cbChonLopThemDead_TextChanged(object sender, EventArgs e)
        {
            TTGiaoVien max = new TTGiaoVien();
            int x = max.GetMaxIDDEAD(cbChonLopThemDead.Text);
            x++;
            txtMaDeadThem.Text = Convert.ToString(x);
        }


        private void cbLopCapNhatDead_TextChanged(object sender, EventArgs e)
        {
            cbMaDead.Text = "1";
            TTGiaoVien ma = new TTGiaoVien();
            txtTenDead.Text = ma.LayTenDead("1", cbLopCapNhatDead.Text);
            dtThoiHanCapNhat.Value = ma.LayThoiHanDead("1", cbLopCapNhatDead.Text);
        }

        private void GDChinhGiaoVien_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (panelChinh.Visible == true)
                {
                    btnSearch_Click(sender, e);
                    return;
                }
                if (groupBoxTraCuuTTDK.Visible == true)
                {
                    btnTraCuuTTDK_act_Click(sender, e);
                    return;
                }
                if (groupBoxTraCuuDiem.Visible == true)
                {
                    btnTraCuuDiem_act_Click(sender, e);
                    return;
                }
                if (gbxKhaNang.Visible == true)
                {
                    btnThemCDKhaNang_Click(sender, e);
                    return;
                }
                if (panelThemDead.Visible == true)
                {
                    btnCapNhatThemDead_Click(sender, e);
                    return;
                }
                if (panel_CapNhatDead.Visible == true)
                {
                    btnUpdateDead_Click(sender, e);
                    return;
                }

                if (panel_CapNhatSLSV_N.Visible == true)
                {
                    btnCapNhatNhom_Click(sender, e);
                    return;
                }
                if (panel_CapNhatSLLop.Visible == true)
                {
                    btnCapNhatLH_Click(sender, e);
                    return;
                }


            }
        }
    }
}
