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
using VIEW_DTO.TT_TatCaChuyenDe;

namespace VIEW_USECASE.GiaoVu
{
    public partial class MoChuyenDe : Form
    {
        public MoChuyenDe(TatCaChuyenDe cd)
        {
            //Mã chuyên đề
            InitializeComponent();
            tbMaCD.Text = cd.MaCD;
            tbTenCD.Text = cd.TenCD;
            var dsbg = Dao_GiaoVu.DSBaoGom();
            var dsnganh = Dao_GiaoVu.DSNganh();
            string nganh = "";
            foreach (var tt in dsbg)
            {
                if (tt.MaCD == cd.MaCD)
                {
                    nganh = tt.MaNganh;
                    break;
                }
            }
            foreach (var tt in dsnganh)
            {
                if (tt.manganh == nganh)
                {
                    nganh = tt.tennganh;
                    break;
                }
            }
            tbThuocNganh.Text = nganh;
            var dshk = Dao_GiaoVu.DSNamHoc();
            foreach (var tt in dshk)
            {
                cbbNamHoc.Items.Add(tt.namhoc);
            }
            var dsnh = Dao_GiaoVu.DSHocKy();
            foreach (var tt in dsnh)
            {
                cbbHocKi.Items.Add(tt.hocky.ToString());
            }
        }


        private void MoChuyenDe_Load(object sender, EventArgs e)
        {

        }
        private void dong()
        {
            this.Close();
        }
        private bool Check(string n)
        {
            if (n == null)
            {
                return false;
            }
            if (n == "0" || n == "00" || n == "000" || n == "0000" || n == "000000" || n == "0000000")
            {
                return false;
            }
            string[] arr = n.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length <= 0)
            {
                return false;
            }
            return true;
        }
        private void btnThemChuyenDe_Click_1(object sender, EventArgs e)
        {
            //var dscddmdektra = Dao_GiaoVu.Ds
            if (Check(cbbNamHoc.Text) == true)
            {
                if (Check(cbbHocKi.Text) == true)
                {
                    if (Check(SLL.Text) == true)
                    {
                        if (Check(cbbTenBatDau.Text) == true)
                        {
                            if (Check(cbbTenBatDau.Text) == true)
                            {
                                if (Check(SLSV1L.Text) == true)
                                {
                                    if (Check(SLNTD.Text) == true)
                                    {
                                        if (Check(SLSVTD1N.Text) == true)
                                        {
                                            if(Int32.Parse(SLNTD.Text)*Int32.Parse(SLSVTD1N.Text) < Int32.Parse(SLSV1L.Text))
                                            {
                                                lbNote.Text = "Thông báo: Số lượng nhóm và số sinh viên 1 nhóm không đủ cho tất cả sinh viên!";
                                                return;
                                            }
                                            //if(Int32.Parse(SLL.Text) * Int32.Parse(SLSV1L.Text) != Int32.Parse(SLTSV.Text) && Int32.Parse(SLTSV.Text) != 0)
                                            //{
                                            //    lbNote.Text = "Thông báo: Số lượng lớp * số lượng sinh viên 1 lớp khác với tổng sinh viên 1 chuyên đề!";
                                            //    return;
                                            //}
                                            int sll = Int32.Parse(SLL.Text);
                                            int sln = Int32.Parse(SLNTD.Text);
                                            int tong_sln = sll * sln;
                                            int sl_thanhcong = 0;
                                            int sl_n_thanhcong = 0;
                                            //if (Int32.Parse(SLTSV.Text) == 0)
                                            //{
                                            //    tsv = Int32.Parse(SLL.Text) * Int32.Parse(SLSV1L.Text);
                                            //}
                                            //else
                                            //{
                                            //    tsv = Int32.Parse(SLTSV.Text);
                                            //}
                                            for (int i=1;i<=sll;i++)
                                            {
                                                var cddm = new ChuyenDeDuocMo
                                                {
                                                    MaLop = cbbTenBatDau.Text + i.ToString(),
                                                    MaCD = tbMaCD.Text,
                                                    NamHoc = cbbNamHoc.Text,
                                                    HocKy = Int32.Parse(cbbHocKi.Text),
                                                    SoNToiDa1Lop = Int32.Parse(SLNTD.Text),
                                                    slsv1lop = Int32.Parse(SLSV1L.Text),
                                                    MoDkHP = new DateTime(1900, 01, 01),
                                                    KtDkHP = new DateTime(1900, 01, 01),
                                                    GVPhuTrach = "chưa có"
                                                };
                                                if (Dao_GiaoVu.MoChuyenDe(cddm))
                                                {
                                                    sl_thanhcong++;
                                                }
                                                for (int j = 1; j <= sln; j++)
                                                {
                                                    var nh = new Nhom
                                                    {
                                                        malop = cddm.MaLop,
                                                        manhom = cddm.MaLop + "_" + j,
                                                        sosvddk = 0,
                                                        sosvtoida1nhom = Int32.Parse(SLSVTD1N.Text)
                                                    };
                                                    if(Dao_GiaoVu.MoNhomThuocChuyenDe(nh))
                                                    {
                                                        sl_n_thanhcong++;
                                                    }
                                                }
                                            }
                                            int sltsv = Int32.Parse(SLL.Text) * Int32.Parse(SLSV1L.Text);
                                            Dao_GiaoVu.CapNhatSLSVTrenSOLUONGSV(tbMaCD.Text, cbbNamHoc.Text, cbbHocKi.Text,sltsv);
                                            MessageBox.Show(string.Format("Đã mở thành công {0}/{1} lớp trong chuyên đề {2} \nMở thành công {3}/{4} nhóm!", sl_thanhcong, sll,tbTenCD.Text,sl_n_thanhcong,tong_sln), "Thông báo");
                                            
                                        }
                                        else
                                        {
                                            lbNote.Text = "Thông báo: Số lượng sinh viên của 1 nhóm không hợp lệ!";
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        lbNote.Text = "Thông báo: Số lượng nhóm tối đa của 1 lớp không hợp lệ!";
                                        return;
                                    }
                                }
                                else
                                {
                                    lbNote.Text = "Thông báo: Số lượng sinh viên của 1 lớp không hợp lệ!";
                                    return;
                                }
                            }
                            else
                            {
                                lbNote.Text = "Thông báo: Tên bắt đầu của 1 lớp không hợp lệ!";
                                return;
                            }
                        }
                        else
                        {
                            lbNote.Text = "Thông báo: Tên bắt đầu của 1 lớp không hợp lệ!";
                            return;
                        }
                    }
                    else
                    {
                        lbNote.Text = "Thông báo: Số lượng lớp của 1 chuyên đề không hợp lệ!";
                        return;
                    }
                }
                else
                {
                    lbNote.Text = "Thông báo: Học kỳ không hợp lệ!";
                    return;
                }
            }
            else
            {
                lbNote.Text = "Thông báo: Năm học không hợp lệ!";
                return;
            }
        }
    }
}
