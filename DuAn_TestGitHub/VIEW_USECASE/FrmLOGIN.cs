using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_BUS.DaoData;
using VIEW_DTO.LOGIN;
using VIEW_USECASE;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Thread th;
        TaiKhoan tk = new TaiKhoan();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void openFormLoadGiaoVu(object sender)
        {
            Application.Run(new FrmGiaoVu(tk));
        }
        
        private void openFormLoadGiaoVien(object sender)
        {
            Application.Run(new GDChinhGiaoVien());
        }
        private void DangNhap()
        {
            tk.tentk = tb_TenTK.Text;
            tk.mk = tb_MK.Text;
            string mk = tk.mk;
            tk.mk = Dao_GiaoVu.ToMD5(mk).ToString();

            if (Dao_GiaoVu.CheckTK(tk) == false)
            {
                lbNote.Text = "Thông báo: Tài khoản hoặc mật khẩu không hợp lệ.";
                return;
            }
            else
            {

                if (Dao_GiaoVu.LoginTK(tk) == "KHONGTONTAI")
                {
                    lbNote.Text = "Thông báo: Tài khoản không tồn tại.";
                    return;
                }
                else if (Dao_GiaoVu.LoginTK(tk) == "KHOA")
                {
                    lbNote.Text = "Thông báo: Tài khoản đang bị khoá.";
                    return;
                }
                else if (Dao_GiaoVu.LoginTK(tk) == "GIAOVIEN")
                {
                    th = new Thread(openFormLoadGiaoVien);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    this.Close();
                    return;
                }
                else if (Dao_GiaoVu.LoginTK(tk) == "GIAOVU")
                {
                    th = new Thread(openFormLoadGiaoVu);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    this.Close();
                    return;
                }
                else
                {
                    lbNote.Text = "Thông báo: Sai mật khẩu!";
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //btn Đăng ký
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChonLoaiTaiKhoan_DangKy frm = new ChonLoaiTaiKhoan_DangKy();
            frm.ShowDialog();
        }

        //btn Quên mật khẩu
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau frm = new QuenMatKhau();
            frm.ShowDialog();
        }
    }
}


//this.Show();
//            try
//            {
//    th = new Thread(openFormLoad);
//    th.SetApartmentState(ApartmentState.STA);
//    th.Start();
//    this.Close();
//}
//            catch(Exception ec)
//            {
//    throw ec;
//}