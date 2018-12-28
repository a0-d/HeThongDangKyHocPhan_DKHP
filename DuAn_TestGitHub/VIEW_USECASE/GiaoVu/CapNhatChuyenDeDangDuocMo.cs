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
    public partial class CapNhatChuyenDeDangDuocMo : Form
    {
        int sll = 0, sln = 0;
        public ChuyenDeDuocMo x = new ChuyenDeDuocMo();
        public CapNhatChuyenDeDangDuocMo(ChuyenDeDuocMo n)
        {
            InitializeComponent();
            x = n;
            //Mã cd
            tbMaCD.Text = n.MaCD.ToString();
            //Tên cd
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            var dsBaogom = Dao_GiaoVu.DSBaoGom();
            var dsThuocNganh = Dao_GiaoVu.DSNganh();
            var dsNH = Dao_GiaoVu.DSNamHoc();
            var dsHK = Dao_GiaoVu.DSHocKy();
            var ds = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();

            foreach (var tt in dscd)
            {
                if (tt.MaCD == n.MaCD)
                {
                    tbTenCD.Text = tt.TenCD;
                    break;
                }
            }

            //Thuộc ngành
            string manganh = "";
            foreach (var tt in dsBaogom)
            {
                if (tt.MaCD == n.MaCD)
                {
                    manganh = tt.MaNganh;
                    break;
                }
            }
            foreach (var tt in dsThuocNganh)
            {
                if (tt.manganh == manganh)
                {
                    manganh = tt.tennganh;
                }
            }
            tbThuocNganh.Text = manganh;

            //Năm học
            foreach (var tt in dsNH)
            {
                cbbNamHoc.Items.Add(tt.namhoc);
            }
            cbbNamHoc.Text = n.NamHoc;

            //Học kỳ
            foreach (var tt in dsHK)
            {
                cbbHocKi.Items.Add(tt.hocky);
            }
            cbbHocKi.Text = n.HocKy.ToString();

            //SL lớp
            List<string> dslophoc = new List<string>();
            int demlop = 0;
            foreach (var tt in ds)
            {
                if (tt.MaCD == tbMaCD.Text && tt.NamHoc == cbbNamHoc.Text && tt.HocKy.ToString() == cbbHocKi.Text)
                {
                    dslophoc.Add(tt.MaLop);
                    demlop++;
                }
            }
            SLL.Text = demlop.ToString();

            //Tên bắt đầu
            string tenlop = "";
            foreach (var tt in ds)
            {
                if (tt.MaCD == tbMaCD.Text && tt.NamHoc == cbbNamHoc.Text && tt.HocKy.ToString() == cbbHocKi.Text)
                {
                    tenlop = tt.MaLop;
                }
            }
            int VT = 0;
            for (int i = tenlop.Length - 1; i >= 0; i--)
            {
                if (Char.IsNumber(tenlop[i]))
                {
                    VT = i;
                    break;
                }
            }
            string abc = tenlop.Substring(0, VT);
            cbbTenBatDau.Text = abc;

            //SLSV1Lop
            foreach (var tt in ds)
            {
                if (tt.MaCD == tbMaCD.Text)
                {
                    SLSV1L.Text = tt.slsv1lop.ToString();
                    break;
                }
            }

            //SLSV 1lop
            foreach (var tt in ds)
            {
                if (tt.MaCD == tbMaCD.Text && tt.NamHoc == cbbNamHoc.Text && tt.HocKy.ToString() == cbbHocKi.Text)
                {
                    //SLSV1L.Text = tt.slsv1lop.ToString();
                }
            }
            SLL.Text = demlop.ToString();

            //SL Nhóm 1 lớp
            foreach (var tt in ds)
            {
                if (tt.MaCD == tbMaCD.Text && tt.NamHoc == cbbNamHoc.Text && tt.HocKy.ToString() == cbbHocKi.Text)
                {
                    SLNTD.Text = tt.SoNToiDa1Lop.ToString();
                    break;
                }
            }

            //SLSV TD 1 nhóm
            var dsn = Dao_GiaoVu.DSNhom();
            int maxnhom = 0;
            foreach (var tt in dslophoc)
            {
                int maxnhomtemp = 0;
                foreach (var tt1 in dsn)
                {
                    if (tt1.malop == tt)
                    {
                        maxnhomtemp = tt1.sosvtoida1nhom;
                        break;
                    }
                }
                if (maxnhomtemp > maxnhom)
                {
                    maxnhom = maxnhomtemp;
                }
            }
            SLSVTD1N.Text = maxnhom.ToString();

            x.SoNToiDa1Lop = Int32.Parse(SLNTD.Text);

            sll = Int32.Parse(SLL.Text);
            sln = Int32.Parse(SLNTD.Text);
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            if ((Check(cbbTenBatDau.Text) == false) || Check(cbbNamHoc.Text) == false || Check(cbbHocKi.Text) == false)
            {
                MessageBox.Show("Dữ liệu cập nhật sai!","Thông báo");
                return;
            }
            else
            {
                string note = "Bạn có chắc chắn với thao tác này, một số nhóm hoặc lớp nhỏ hơn số lượng cũ sẽ bị xoá.";
                var result = MessageBox.Show(note, "Thông báo", MessageBoxButtons.YesNo);
                if(result == DialogResult.No)
                {

                }
                else
                {
                    x.MaLop = cbbTenBatDau.Text;
                    x.NamHoc = cbbNamHoc.Text;
                    x.HocKy = Int32.Parse(cbbHocKi.Text);
                    int SoNToiDa1Lop1 = Int32.Parse(SLNTD.Text);
                    int slsv1lop = Int32.Parse(SLSV1L.Text);
                    int sll = Int32.Parse(SLL.Text);
                    int slsvtoida1nhom = Int32.Parse(SLSVTD1N.Text);

                    if(Dao_GiaoVu.CapNhatCDDuocMo(x, SoNToiDa1Lop1, slsv1lop, sll, slsvtoida1nhom) == true)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Thông báo");
                        return;
                    }
                    
                }
            }
        }

        private bool Check(string n)
        {
            if (n == "" || n == " ")
            {
                return false;
            }
            return true;
        }
    }
}
