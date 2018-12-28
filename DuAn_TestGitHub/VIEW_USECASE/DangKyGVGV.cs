using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_BUS.DaoData;
using VIEW_DTO.LOGIN;
using VIEW_DTO.TT_TatCaChuyenDe;

namespace VIEW_USECASE
{
    public partial class DangKyGVGV : Form
    {
        string maxacthucmail = "";
        public DangKyGVGV()
        {
            InitializeComponent();
            tbMaXacThuc.TextChanged += new EventHandler(checktextMXT);
            cbbChucVu.TextChanged += new EventHandler(checkchucvu);
        }
        private void checkchucvu(object sender, EventArgs e)
        {
            if (cbbChucVu.Text == "Giáo Viên")
            {
                cbbNganh.Enabled = true;
                var dsnganh = Dao_GiaoVu.DSNganh();
                foreach (var tt in dsnganh)
                {
                    if(tt.manganh == "NG00")
                    {
                        continue;
                    }
                    cbbNganh.Items.Add(tt.tennganh);
                }
            }
            else
            {
                cbbNganh.Enabled = false;
            }
        }
        private void checktextMXT(object sender, EventArgs e)
        {
            if (tbMaXacThuc.Text != "")
            {
                tbMAND.Enabled = false;
                btnLayMaXacThuc.Enabled = false;
                tbTenND.Enabled = false;
                tbMail.Enabled = false;
                cbbChucVu.Enabled = false;
                cbbNganh.Enabled = false;
                NGAYBDCT.Enabled = false;
                lbNote.Text = "";
            }
        }
        private void btnLayMaXacThuc_Click(object sender, EventArgs e)
        {
            if (cbbChucVu.Text == "Giáo Viên")
            {
                if (tbMAND.Text == "" || tbTenND.Text == "" || cbbNganh.Text == "" || cbbChucVu.Text == "" || tbMail.Text == "" || tbMK.Text == "")
                {
                    lbNote.Text = "Thông báo: Không được bỏ trống 1 trong những mục trên.";
                    return;
                }
            }
            else
            {
                if (tbMAND.Text == "" || tbTenND.Text == "" || cbbChucVu.Text == "" || tbMail.Text == "" || tbMK.Text == "")
                {
                    lbNote.Text = "Thông báo: Không được bỏ trống 1 trong những mục trên.";
                    return;
                }
            }
            var dsnd = Dao_GiaoVu.DSGiaoVien();
            foreach (var tt in dsnd)
            {
                if (tt.MaND == tbMAND.Text)
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
                    if (tt.Mail == tbMail.Text)
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
                string loaitk = "1";

                GiaoVien gv = new GiaoVien();
                gv.MaND = tbMAND.Text;
                gv.Mail = tbMail.Text;
                var dsnganh = Dao_GiaoVu.DSNganh();
                foreach (var tt in dsnganh)
                {
                    if (tt.tennganh == cbbNganh.Text)
                    {
                        gv.MaNganh = tt.manganh;
                    }
                }
                gv.NgayBDCT = DateTime.Parse(NGAYBDCT.Text);
                gv.TenGV = tbTenND.Text;
                gv.ChucVu = cbbChucVu.Text;
                if (gv.ChucVu != "Giáo Viên")
                {
                    gv.MaNganh = "NG00";
                    loaitk = "0";
                }
                if (Dao_GiaoVu.DangKyMoiGVGV(tk, gv, loaitk))
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

            var dschucvu = Dao_GiaoVu.DSChucVu();
            foreach (var tt in dschucvu)
            {
                cbbChucVu.Items.Add(tt.chucvu);
            }
            cbbChucVu.Text = "";
        }

        private void XemDieuKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Bla Bla Bla - Bla Bla Bla.", "Điều khoản sử dụng ứng dụng");
            return;
        }
    }
}
