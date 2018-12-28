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
    public partial class CapNhatThongTinLop : Form
    {
        ChuyenDeDuocMo cddm = new ChuyenDeDuocMo();
        public CapNhatThongTinLop(ChuyenDeDuocMo n)
        {
            InitializeComponent();
            

            //ChuyenDeDuocMo m = new ChuyenDeDuocMo();
            var ds = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            foreach(var tt in ds)
            {
                if(tt.MaLop == n.MaLop)
                {
                    SLNTD.Text = tt.SoNToiDa1Lop.ToString();
                    SLSV1L.Text = tt.slsv1lop.ToString();
                    break;
                }
            }
            tbTenLop.Text = n.MaLop;
            var dsnhom = Dao_GiaoVu.DSNhom();
            foreach(var tt in dsnhom)
            {
                if(tt.malop == n.MaLop)
                {
                    SLSVTD1N.Text = tt.sosvtoida1nhom.ToString();
                }
            }
            //SLSV1L.Text = n.slsv1lop.ToString();
            //SLNTD.Text = m.SoNToiDa1Lop.ToString();
            cddm.slsv1lop = Int32.Parse(SLSV1L.Text);
            cddm.SoNToiDa1Lop = Int32.Parse(SLNTD.Text);

        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cddm.SoNToiDa1Lop.ToString());
            bool co = true;
            if(Int32.Parse(SLSV1L.Text) != cddm.slsv1lop)
            {
                if(Dao_GiaoVu.SLSV1LopKhiCapNhatLop(tbTenLop.Text, Int32.Parse(SLSV1L.Text)) == false)
                {
                    co = false;
                }
            }

            if(Int32.Parse(SLNTD.Text) > cddm.SoNToiDa1Lop)
            {
                for(int i=cddm.SoNToiDa1Lop + 1;i<=Int32.Parse(SLNTD.Text);i++)
                {
                    string manhom = tbTenLop.Text + "_" + i;
                    Dao_GiaoVu.ThemNhomTheoLopKhiCapNhat(tbTenLop.Text, manhom, Int32.Parse(SLSVTD1N.Text));
                }
                for(int i=1;i<=cddm.SoNToiDa1Lop;i++)
                {
                    string manhom = tbTenLop.Text + "_" + i;
                    Dao_GiaoVu.SLSVNhomCapNhat(tbTenLop.Text, manhom, Int32.Parse(SLSVTD1N.Text));
                }
            }
            else if(Int32.Parse(SLNTD.Text) < cddm.SoNToiDa1Lop)
            {
                for (int i = cddm.SoNToiDa1Lop; i > Int32.Parse(SLNTD.Text); i--)
                {
                    string manhom = tbTenLop.Text + "_" + i;
                    Dao_GiaoVu.XoaNhomCapNhat(tbTenLop.Text, manhom);
                }
                for (int i = 1; i <= cddm.SoNToiDa1Lop; i++)
                {
                    string manhom = tbTenLop.Text + "_" + i;
                    Dao_GiaoVu.SLSVNhomCapNhat(tbTenLop.Text, manhom, Int32.Parse(SLSVTD1N.Text));
                }
            }
            else
            {
                for (int i = 1; i <= cddm.SoNToiDa1Lop; i++)
                {
                    string manhom = tbTenLop.Text + "_" + i;
                    Dao_GiaoVu.SLSVNhomCapNhat(tbTenLop.Text, manhom, Int32.Parse(SLSVTD1N.Text));
                }
            }
            if(co == false)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo");
                return;
            }
            else
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                return;
            }
        }
    }
}
