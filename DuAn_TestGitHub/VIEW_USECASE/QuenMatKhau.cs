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

namespace VIEW_USECASE
{
    public partial class QuenMatKhau : Form
    {
        private string maxacthucmail;
        public QuenMatKhau()
        {
            InitializeComponent();
            tbXNMKM.TextChanged += new EventHandler(checkmk);
            tbMKM.TextChanged += new EventHandler(changmkm);
        }

        private void changmkm(object sender,EventArgs e)
        {
            tbXNMKM.BackColor = System.Drawing.Color.White;
            lbNote2.Text = "";
            lbNote2.ForeColor = System.Drawing.Color.Black;
            return;
        }
        private void checkmk(object sender,EventArgs e)
        {
            if(tbXNMKM.Text == tbMKM.Text)
            {
                tbXNMKM.BackColor = System.Drawing.Color.DeepSkyBlue;
                lbNote2.Text = "Thông báo: Xác nhận mật khẩu trùng khớp.";
                lbNote2.ForeColor = System.Drawing.Color.Blue;
                return;
            }
            else
            {
                tbXNMKM.BackColor = System.Drawing.Color.White;
                lbNote2.Text = "";
                lbNote2.ForeColor = System.Drawing.Color.Black;
                return;
            }
        }

        private void btnLayMaXacThuc_Click(object sender, EventArgs e)
        {
            if (tbTK.Text == "")
            {
                lbNote.Text = "Thông báo: Không được bỏ tên tài khoản.";
                lbNote.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                var ds = Dao_GiaoVu.DSGiaoVien();
                var ds1 = Dao_GiaoVu.DSSinhVienDayDu();
                string mail = "";
                int temp = 0;
                foreach(var tt in ds)
                {
                    if(tt.MaND == tbTK.Text)
                    {
                        mail = tt.Mail;
                        temp = 1;
                        break;
                    }
                }
                if(temp == 0)
                {
                    foreach(var tt in ds1)
                    {
                        if(tt.mand == tbTK.Text)
                        {
                            mail = tt.mail;
                            break;
                        }
                    }
                }
                if(mail == "")
                {
                    lbNote.Text = "Thông báo: Tài khoản không tồn tại.";
                    lbNote.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string mail1 = "";
                string mail2 = "";
                int sosao = 0;
                for(int i=0;i<mail.Length;i++)
                {
                    if(mail[i] == '@')
                    {
                        mail1 = mail[0].ToString();
                        mail2 = mail.Substring(i - 1);
                        sosao = i - 1;
                        break;
                    }
                }
                string tb = "Thông báo: Mã xác thực đã được gửi về địa chỉ mail: " + mail1;
                for(int i=1;i<=sosao;i++)
                {
                    tb += "*";
                }
                tb += mail2;
                if(tb.Length > 75)
                {
                    string t1 = tb.Substring(0, 75);
                    string t2 = tb.Substring(75);
                    tb = t1 + "\n" + t2;
                }
                lbNote.Text = tb;
                lbNote.ForeColor = System.Drawing.Color.Blue;

                lbMXT.Enabled = true;
                lbMKM.Enabled = true;
                lbXNMKM.Enabled = true;
                lbNote2.Enabled = true;
                btnLayMaXacThuc.Enabled = false;
                tbTK.Enabled = false;
                tbMaXacNhan.Enabled = true;
                tbMKM.Enabled = true;
                tbXNMKM.Enabled = true;

                btnDoiMatKhau.Enabled = true;

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
                MailMessage mailnd = new MailMessage("nguyentongtrieu9@gmail.com", mail, "Mã xác thực đổi mật khẩu cho tài khoản " + tbTK.Text + " sử dụng ứng dụng của trường ĐH KHTN TPHCM.", "Mã xác thực của bạn là: " + body + " . Đừng để lộ mã xác thực tránh tình trạng bị đánh cắp thông tin người dùng");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential("nguyentongtrieu9@gmail.com", "Tongtrieu1998");
                client.EnableSsl = true;
                client.Send(mailnd);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(tbMaXacNhan.Text == "" || tbMKM.Text == "" || tbXNMKM.Text == "")
            {
                lbNote2.Text = "Thông báo: Không được bỏ trống các trường ở trên.";
                lbNote2.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if(tbXNMKM.Text != tbMKM.Text)
            {
                lbNote2.Text = "Thông báo: Xác nhận mật khẩu không trùng khớp.";
                lbNote2.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                if (tbMaXacNhan.Text == maxacthucmail)
                {
                    if(Dao_GiaoVu.QuenMK(tbTK.Text,tbXNMKM.Text))
                    {
                        var rs = MessageBox.Show("Bạn đã đổi mật khẩu thành công. Bây giờ bạn có thể đăng nhập bằng mật khẩu đó.", "Thông báo", MessageBoxButtons.OK);
                        if(rs == DialogResult.OK)
                        {
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình cập nhật mật khẩu.", "Thông báo");
                        return;
                    }
                }
                else
                {
                    lbNote2.Text = "Thông báo: Mã xác nhận không đúng.";
                    lbNote2.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            
        }
    }
}
