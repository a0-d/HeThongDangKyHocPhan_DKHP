using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_BUS.DaoData;
using VIEW_DTO.GiaoVu;
using VIEW_DTO.LOGIN;

namespace VIEW_USECASE
{
    public partial class DangKySV : Form
    {
        string maxacthucmail = "";
        public DangKySV()
        {
            InitializeComponent();
            tbMaXacThuc.TextChanged += new EventHandler(checktextMXT);
        }
        private void checktextMXT(object sender, EventArgs e)
        {
            if (tbMaXacThuc.Text != "")
            {
                tbMAND.Enabled = false;
                tbMK.Enabled = false;
                btnLayMaXacThuc.Enabled = false;
                tbTenND.Enabled = false;
                tbMail.Enabled = false;
                cbbPhai.Enabled = false;
                cbbNganh.Enabled = false;
                tbMail.Enabled = false;
                tbDiaChi.Enabled = false;
                NgaySinh.Enabled = false;
                DongYDieuKhoan.Enabled = false;
                lbNote.Text = "";
            }
            else
            {
                tbMAND.Enabled = true;
                tbMK.Enabled = true;
                btnLayMaXacThuc.Enabled = true;
                tbTenND.Enabled = true;
                tbMail.Enabled = true;
                cbbPhai.Enabled = true;
                cbbNganh.Enabled = true;
                tbMail.Enabled = true;
                tbDiaChi.Enabled = true;
                NgaySinh.Enabled = true;
                DongYDieuKhoan.Enabled = true;
                lbNote.Text = "";
            }
        }
        private void btnLayMaXacThuc_Click(object sender, EventArgs e)
        {
            if (tbMAND.Text == "" || tbTenND.Text == "" || cbbNganh.Text == "" || tbDiaChi.Text == "" || cbbPhai.Text == "" || tbMail.Text == "" || tbMK.Text == "")
            {
                lbNote.Text = "Thông báo: Không được bỏ trống 1 trong những mục trên.";
                return;
            }

            var dsnd = Dao_GiaoVu.DSSinhVienDayDu();
            foreach (var tt in dsnd)
            {
                if (tt.mand == tbMAND.Text)
                {
                    lbNote.Text = "Thông báo: Mã người dùng đã tồn tại.";
                    lbNote.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            if (DongYDieuKhoan.Checked != true)
            {
                lbNote.Text = "Thông báo: Bạn phải đọc và đồng ý điều khoản sử dụng.";
                return;
            }
            string duoimail = "";
            for (int i = tbMail.Text.Length - 1; i > -1; i--)
            {
                if (tbMail.Text[i] == '@')
                {
                    duoimail = tbMail.Text.Substring(i + 1);
                    break;
                }
            }
            string duoi1 = "";
            for (int i = 0; i < duoimail.Length; i++)
            {
                if (duoimail[i] == '.')
                {
                    duoi1 = duoimail.Substring(i + 1);
                    break;
                }
            }
            if (duoimail == "fit.hcmus.edu.vn" || duoimail == "hcmus.edu.vn" || duoi1 == "hcmus.edu.vn")
            {
                foreach (var tt in dsnd)
                {
                    if (tt.mail == tbMail.Text)
                    {
                        lbNote.Text = "Thông báo: Mail này đã có tài khoản.";
                        lbNote.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                string body = "";
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                body = new String(stringChars);
                maxacthucmail = body;
                MailMessage mail = new MailMessage("nguyentongtrieu9@gmail.com", tbMail.Text, "Mã xác thực tạo tài khoản sử dụng ứng dụng của trường ĐH KHTN TPHCM.", "Mã xác thực của bạn là: " + body + " . Đừng để lộ mã xác thực tránh tình trạng bị đánh cắp thông tin người dùng");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential("nguyentongtrieu9@gmail.com", "Tongtrieu1998");
                client.EnableSsl = true;
                client.Send(mail);

                lbNote.Text = "Thông báo: Vui lòng check mail để lấy mã xác thực.";
                lbNote.ForeColor = System.Drawing.Color.Blue;

                btnLayMaXacThuc.Text = "Gửi lại";

                lbMaXacThuc.Enabled = true;
                tbMaXacThuc.Enabled = true;
                btnHoanTatDangKy.Enabled = true;
                return;
            }
            else
            {
                lbNote.Text = "Thông báo: Mail phải là mail của trường \"...hcmus.edu.vn\".";
                return;
            }

        }

        private void btnHoanTatDangKy_Click(object sender, EventArgs e)
        {
            if (tbMaXacThuc.Text == maxacthucmail)
            {
                TaiKhoan tk = new TaiKhoan();
                tk.tentk = tbMAND.Text;
                tk.mk = tbMK.Text;
                tk.tinhtrang = "Mo";

                SinhVienDayDu sv = new SinhVienDayDu();
                sv.hoten = tbTenND.Text;
                sv.mail = tbMail.Text;
                sv.mand = tbMAND.Text;
                var dsnganh = Dao_GiaoVu.DSNganh();
                foreach(var tt in dsnganh)
                {
                    if(tt.tennganh == cbbNganh.Text)
                    {
                        sv.manganh = tt.manganh;
                    }
                }
                sv.ngaysinh = DateTime.Parse(NgaySinh.Text);
                sv.phai = cbbPhai.Text;
                sv.diachi = tbDiaChi.Text;
                if (Dao_GiaoVu.DangKyMoiSV(tk, sv))
                {
                    var rs = MessageBox.Show("Đăng ký thành công. Bây giờ bạn có thể đăng nhập bằng Mã Giáo Viên/Mật khẩu vừa tạo.", "Thông báo", MessageBoxButtons.OK);
                    if (DialogResult.OK == rs)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi!", "Thông báo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại.", "Thông báo");
                    return;
                }

            }
            else
            {
                lbNote2.Text = "Sai mã xác thực.";
                return;
            }
        }

        private void DangKy_Load(object sender, EventArgs e)
        {

            var dsnganh = Dao_GiaoVu.DSNganh();
            foreach (var tt in dsnganh)
            {
                cbbNganh.Items.Add(tt.tennganh);
            }
            cbbNganh.Text = "";
        }

        private void XemDieuKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Bla Bla Bla - Bla Bla Bla.", "Điều khoản sử dụng ứng dụng");
            return;
        }
        
    }
}
