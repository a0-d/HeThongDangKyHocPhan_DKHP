using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_BUS.DaoData;
using VIEW_DTO.LOGIN;

namespace VIEW_USECASE.GiaoVu
{
    public partial class DoiMatKhau : Form
    {
        string tentk;
        public DoiMatKhau(string tentk1)
        {
            InitializeComponent();
            tentk = tentk1;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string mkc = "";

            var dstk = Dao_GiaoVu.DSTaiKhoan();
            foreach (var tt in dstk)
            {
                if (tt.tentk == tentk)
                {
                    mkc = tt.mk;
                }
            }
            if (tbMatKhauCu.Text == "" || tb_MatKhauMoi.Text == "" || tbXacNhanMatKhauMoi.Text == "")
            {
                lbNote.Text = "Thông báo: Không được bỏ trống trường dấu dấu (*)!";
                return;
            }
            if (Dao_GiaoVu.ToMD5(tbMatKhauCu.Text).ToString() != mkc)
            {
                lbNote.Text = "Thông báo: Sai mật khẩu cũ!";
                return;
            }
            if (tb_MatKhauMoi.Text == tbMatKhauCu.Text)
            {
                lbNote.Text = "Thông báo: Mật khẩu mới không được trùng với mật khẩu cũ!";
                return;
            }
            else if (tb_MatKhauMoi.Text != tbXacNhanMatKhauMoi.Text)
            {
                lbNote.Text = "Thông báo: Xác nhận mật khẩu không trùng khớp!";
                return;
            }
            else if (Dao_GiaoVu.ToMD5(tbMatKhauCu.Text).ToString() == mkc && tb_MatKhauMoi.Text == tbXacNhanMatKhauMoi.Text)
            {
                var tk = new TaiKhoan();
                tk.tentk = tentk;
                tk.mk = Dao_GiaoVu.ToMD5(tbXacNhanMatKhauMoi.Text).ToString();
                if (Dao_GiaoVu.DoiMatKhau(tk))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                    tbMatKhauCu.Text = "";
                    tb_MatKhauMoi.Text = "";
                    tbXacNhanMatKhauMoi.Text = "";
                    return;
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình đổi mật khẩu\nVui lòng thử lại.", "Thông báo");
                    return;
                }
            }
            else
            {
                lbNote.Text = "Thông báo: Xảy ra lỗi trong quá trình đổi mật khẩu!";
                return;
            }
        }


    }
}
