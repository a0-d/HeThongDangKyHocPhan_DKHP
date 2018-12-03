using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_DTO.DaoData;
using VIEW_DTO.TT_TatCaChuyenDe;

namespace VIEW_USECASE.GiaoVu
{
    public partial class SuaChuyenDe : Form
    {
        public TatCaChuyenDe tccd;
        public SuaChuyenDe(TatCaChuyenDe n)
        {
            InitializeComponent();
            tccd = n;
            tbTenCD.Text = n.TenCD;
            tbMaCD.Text = n.MaCD;
            if(n.TinhTrang == 0)
            {
                rdoVoHieuHoa.Checked = true;
            }
            else
            {
                rdoMo.Checked = true;
            }
            var dsbg = Dao_GiaoVu.DSBaoGom();
            string ma = "";
            foreach (var tt in dsbg)
            {
                if (tt.MaCD == n.MaCD)
                {
                    ma = tt.MaNganh;
                }
            }
            var ds = Dao_GiaoVu.DSNganh();
            foreach (var tt in ds)
            {
                cbbThuocNganh.Items.Add(tt.tennganh);
                if(tt.manganh == ma)
                {
                    ma = tt.tennganh;
                }
            }
            cbbThuocNganh.Text = ma;
            
        }

        private void SuaChuyenDe_Load(object sender, EventArgs e)
        {
           
        }

        private void btnThemChuyenDe_Click(object sender, EventArgs e)
        {
            int ttrang = 0;
            if(rdoMo.Checked == true)
            {
                ttrang = 1;
            }
            TatCaChuyenDe cd = new TatCaChuyenDe
            {
                MaCD = tbMaCD.Text,
                TenCD = tbTenCD.Text,
                TinhTrang = ttrang
            };
            if (CheckChange(tccd,cd) == false && CheckNganh(tccd.MaCD,cbbThuocNganh.Text) == true)
            {
                lbNote.Text = "Thông báo: Chuyên đề chưa có gì thay đổi!";
            }
            else
            {
                if(Dao_GiaoVu.SuaChuyenDe(cd))
                {
                    MessageBox.Show("Cập nhật thành công!","Thông báo");
                }
                else
                {
                    lbNote.Text = "Thông báo: Không thể cập nhật!";
                }
            }
        }
        private bool CheckChange(TatCaChuyenDe cd1,TatCaChuyenDe cd2)
        {
            if(cd1.MaCD != cd2.MaCD || cd1.TenCD != cd2.TenCD || cd1.TinhTrang != cd2.TinhTrang)
            {
                return true;
            }
            return false;
        }
        private bool CheckNganh(string macd,string tennganh1)
        {
            string ma = "";
            var ds = Dao_GiaoVu.DSNganh();
            foreach(var tt in ds)
            {
                if(tt.tennganh == tennganh1)
                {
                    ma = tt.manganh;
                    break;
                }
            }
            var dsbg = Dao_GiaoVu.DSBaoGom();
            foreach(var tt in dsbg)
            {
                if (tt.MaNganh == ma)
                {
                    ma = tt.MaCD;
                }
            }
            if(macd == ma)
            {
                return true;
            }
            return false;
        }
    }
}
