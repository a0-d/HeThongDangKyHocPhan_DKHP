using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_USECASE.DaoData;
using VIEW_USECASE.TT_TatCaChuyenDe;

namespace VIEW_USECASE.GiaoVu
{
    public partial class ThemChuyenDe : Form
    {
        public ThemChuyenDe()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemChuyenDe_Load(object sender, EventArgs e)
        {
            TTGiaoVu tuongtac = new TTGiaoVu();

            DataTable dt = new DataTable();
            dt = tuongtac.DSChuyenDeThuocNganh();
            dt.Columns.Add("tennganh", typeof(string));
            dt.Dispose();
            cbbThuocNganh.ValueMember = "tennganh";
            cbbThuocNganh.DataSource = dt;
        }

        private void btnThemChuyenDe_Click(object sender, EventArgs e)
        {
            if(tbTenCD.Text != "" && KiemtraSpace(tbTenCD.Text) == 1)
            {
                if(tbMaCD.Text != "" && KiemtraSpace(tbMaCD.Text) == 1)
                {
                    if(rdoMo.IsChecked == true)
                    {

                    }
                    else
                    {
                        var lqq = Dao_GiaoVu.DSTatCaChuyenDe();
                        foreach(var tt in lqq)
                        {
                            if(tbMaCD.Text == tt.MaCD || KiemtraCheckTest(tbMaCD.Text,tt.MaCD) == 1)
                            {
                                lbNote.Text = "Thông báo: Mã chuyên đề đã tồn tại!";
                                return;
                            }
                        }
                        TatCaChuyenDe cd = new TatCaChuyenDe();
                        var cdAdd = new TatCaChuyenDe
                        {
                            MaCD = tbMaCD.Text,
                            TenCD = tbTenCD.Text,
                            TinhTrang = 0
                        };
                        var dsbg = Dao_GiaoVu.DSNganh();
                        string manganhadd = "";
                        foreach(var tt in dsbg)
                        {
                            if(tt.tennganh == cbbThuocNganh.Text)
                            {
                                manganhadd = tt.manganh;
                                break;
                            }
                        }
                        BaoGom bg = new BaoGom
                        {
                            MaNganh = manganhadd,
                            MaCD = tbMaCD.Text
                        };
                        if(Dao_GiaoVu.ThemChuyenDe(cdAdd,bg))
                        {
                            lbNote.Text = "Thông báo: Đã thêm thành công!";
                            lbNote.ForeColor = System.Drawing.Color.Blue;
                            tbMaCD.Text = "";
                            tbTenCD.Text = "";
                            rdoVoHieuHoa.IsChecked = true;
                            cbbThuocNganh.Text = "Văn Phòng";
                        }
                        else
                        {
                            lbNote.Text = "Thông báo: Không thể thêm!";
                        }

                    }
                }
                else
                {
                    lbNote.Text = "Thông báo: Mã chuyên đề không hợp lệ!";
                }
            }
            else
            {
                lbNote.Text = "Thông báo: Tên chuyên đề không hợp lệ!";
            }
        }
        private int KiemtraSpace(string n)
        {
            foreach(char x in n)
            {
                if(x != ' ')
                {
                    return 1;
                }
            }
            return 0;
        }
        private int KiemtraCheckTest(string x,string y)
        {
            string[] arrx;
            string[] arry;
            arrx = x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            arry = y.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int sl = 0;
            if(arrx.Length > arry.Length)
            {
                sl = arrx.Length;
            }
            else
            {
                sl = arry.Length;
            }
            for(int i=0;i<sl;i++)
            {
                if(arrx[i] != arry[i])
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
