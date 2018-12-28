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
    public partial class CapNhatGiaoVienPhuTrach : Form
    {
        public CapNhatGiaoVienPhuTrach(ChuyenDeDuocMo n)
        {
            InitializeComponent();
            //Mã cd
            tbMaCD.Text = n.MaCD.ToString();

            //Tên cd
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in dscd)
            {
                if (tt.MaCD == n.MaCD)
                {
                    tbTenCD.Text = tt.TenCD;
                    break;
                }
            }

            //Thuộc ngành
            var dsBaogom = Dao_GiaoVu.DSBaoGom();
            var dsThuocNganh = Dao_GiaoVu.DSNganh();
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
           tbNamHoc.Text = n.NamHoc;

            //Học kỳ
            tbHocKi.Text = n.HocKy.ToString();

            //Lớp
            cbbLop.Text = n.MaLop;

            //GVPhu trách
            var ds = Dao_GiaoVu.DSKhaNang();
            List<string> arr = new List<string>();
            foreach(var tt in ds)
            {
                if(tt.macd == tbMaCD.Text)
                {
                    arr.Add(tt.mand);
                }
            }
            var dsgv = Dao_GiaoVu.DSGiaoVien();
            foreach(var tt in dsgv)
            {
                foreach(var tt1 in arr)
                {
                    if(tt.MaND == tt1)
                    {
                        cbbGiaoVienPhuTrach.Items.Add(tt.TenGV);
                    }
                }
            }
            cbbGiaoVienPhuTrach.Text = n.GVPhuTrach;

        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            ChuyenDeDuocMo cd = new ChuyenDeDuocMo();
            var dsgv = Dao_GiaoVu.DSGiaoVien();
            foreach(var tt in dsgv)
            {
                if(tt.TenGV == cbbGiaoVienPhuTrach.Text)
                {
                    cd.GVPhuTrach = tt.MaND;
                }
            }
            cd.MaLop = cbbLop.Text;
            cd.MaCD = tbMaCD.Text;
            if(Dao_GiaoVu.CapNhatGiaoVienPhuTrach(cd))
            {
                MessageBox.Show("Cập nhật thành công.", "Thông báo");
            }
            else
            {
                MessageBox.Show("Không thể cập nhật.", "Thông báo");
                return;
            }
        }
    }
}
