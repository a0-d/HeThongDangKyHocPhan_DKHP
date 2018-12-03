using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_USECASE.DaoData;
using VIEW_USECASE.TT_TatCaChuyenDe;

namespace VIEW_USECASE.GiaoVu
{
    public partial class CapNhatChuyenDeDangDuocMo : Form
    {
        public CapNhatChuyenDeDangDuocMo(ChuyenDeDuocMo n)
        {
            InitializeComponent();
            
            //Mã cd
            tbMaCD.Text = n.MaCD.ToString();

            //Tên cd
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach(var tt in dscd)
            {
                if(tt.MaCD == n.MaCD)
                {
                    tbTenCD.Text = tt.TenCD;
                    break;
                }
            }
            
            //Thuộc ngành
            var dsBaogom = Dao_GiaoVu.DSBaoGom();
            var dsThuocNganh = Dao_GiaoVu.DSNganh();
            string manganh = "";
            foreach(var tt in dsBaogom)
            {
                if(tt.MaCD==n.MaCD)
                {
                    manganh = tt.MaNganh;
                    break;
                }
            }
            foreach(var tt in dsThuocNganh)
            {
                if(tt.manganh == manganh)
                {
                    manganh = tt.tennganh;
                }
            }
            tbThuocNganh.Text = manganh;

            //Năm học
            TTGiaoVu tuongtac = new TTGiaoVu();
            var dsNH = Dao_GiaoVu.DSNamHoc();
            foreach(var tt in dsNH)
            {
                cbbNamHoc.Items.Add(tt.namhoc);
            }
            cbbNamHoc.Text = n.NamHoc;

            //Học kỳ
            var dsHK = Dao_GiaoVu.DSHocKy();
            foreach(var tt in dsHK)
            {
                cbbHocKi.Items.Add(tt.hocky);
            }
            cbbHocKi.Text = n.HocKy.ToString();

            //Tên bắt đầu

            //cbbTenBatDau.Items.Add("CK");
            //SL lớp
            //SLLop.Text = n.S
            //SLL.Text = n.S



        }
        
    }
}
