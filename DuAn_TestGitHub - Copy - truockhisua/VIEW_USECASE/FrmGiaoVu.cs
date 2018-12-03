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
using VIEW_USECASE.GiaoVu;
using VIEW_USECASE.GiaoVu.TraCuu;
using VIEW_USECASE.TT_TatCaChuyenDe;

namespace VIEW_USECASE
{
    public partial class FrmGiaoVu : Form
    {
        public FrmGiaoVu()
        {
            //update
            InitializeComponent();
            LoadDGV();
        }

        public void LoadDGV()
        {
            InitTatCaChuyenDe();
            InitChuyenDeDuocMo();
            InitCacLopChuyenDeDuocMo();
        }
        /// <summary>
        /// Tất cả chuyên đề
        /// </summary>
        void CreateColumnTatCaChuyenDe()
        {
            dataGridViewTatCaChuyenDe.Columns.Clear();
            var macd = new DataGridViewTextBoxColumn();
            macd.HeaderText = "Mã chuyên đề";
            dataGridViewTatCaChuyenDe.Columns.Add(macd);

            var tencd = new DataGridViewTextBoxColumn();
            tencd.HeaderText = "Tên chuyên đề";
            dataGridViewTatCaChuyenDe.Columns.Add(tencd);

            var tinhtrang = new DataGridViewTextBoxColumn();
            tinhtrang.HeaderText = "Tình trạng";
            dataGridViewTatCaChuyenDe.Columns.Add(tinhtrang);

            dataGridViewTatCaChuyenDe.Columns[0].Width = 100;
            dataGridViewTatCaChuyenDe.Columns[2].Width = 300;
        }
        void LoadDGVTatCaChuyenDe()
        {
            dataGridViewTatCaChuyenDe.Rows.Clear();
            var ds = Dao_GiaoVu.DSTatCaChuyenDe();
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var cd in ds)
            {
                row = new DataGridViewRow();
                row.Tag = cd;

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.MaCD;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.TenCD;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                int temp = cd.TinhTrang;
                if (temp == 0)
                {
                    cell.Value = "Vô hiệu hoá";
                }
                else
                {
                    cell.Value = "Đang mở";
                }
                row.Cells.Add(cell);

                dataGridViewTatCaChuyenDe.Rows.Add(row);
            }
        }
        void InitTatCaChuyenDe()
        {
            CreateColumnTatCaChuyenDe();
            LoadDGVTatCaChuyenDe();
        }
        /// <summary>
        /// Chuyên đề được mở
        /// </summary>
        void CreateColumnChuyenDeDuocMo()
        {
            dataGridViewChuyenDeDuocMo.Columns.Clear();
            //var malop = new DataGridViewTextBoxColumn();
            //malop.HeaderText = "Lớp";
           // dataGridViewChuyenDeDuocMo.Columns.Add(malop);

            var cd = new DataGridViewTextBoxColumn();
            cd.HeaderText = "Chuyên đề";
            dataGridViewChuyenDeDuocMo.Columns.Add(cd);

            var nh = new DataGridViewTextBoxColumn();
            nh.HeaderText = "Năm học";
            dataGridViewChuyenDeDuocMo.Columns.Add(nh);

            var hk = new DataGridViewTextBoxColumn();
            hk.HeaderText = "Học kì";
            dataGridViewChuyenDeDuocMo.Columns.Add(hk);

            var svtd = new DataGridViewTextBoxColumn();
            svtd.HeaderText = "Sinh viên tối đa";
            dataGridViewChuyenDeDuocMo.Columns.Add(svtd);

            var svddk = new DataGridViewTextBoxColumn();
            svddk.HeaderText = "Sinh viên đã đăng ký";
            dataGridViewChuyenDeDuocMo.Columns.Add(svddk);

            var gvpt = new DataGridViewTextBoxColumn();
            gvpt.HeaderText = "Giáo viên phụ trách";
            dataGridViewChuyenDeDuocMo.Columns.Add(gvpt);

            dataGridViewChuyenDeDuocMo.Columns[1].Width = 200;
            dataGridViewChuyenDeDuocMo.Columns[2].Width = 120;
            dataGridViewChuyenDeDuocMo.Columns[3].Width = 220;
            dataGridViewChuyenDeDuocMo.Columns[0].Width = 500;
            dataGridViewChuyenDeDuocMo.Columns[5].Width = 300;
        }
        void LoadDGVChuyenDeDuocMo()
        {
            dataGridViewChuyenDeDuocMo.Rows.Clear();
            var ds = Dao_GiaoVu.DSChuyenDeDuocMo();
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var cd in ds)
            {
                row = new DataGridViewRow();
                row.Tag = cd;

                //cell = new DataGridViewTextBoxCell();
                //cell.Value = cd.MaLop;
                //row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                string tencd = "";
                var lqq = Dao_GiaoVu.DSTatCaChuyenDe();
                foreach(var tt in lqq)
                {
                    if(cd.MaCD == tt.MaCD)
                    {
                        tencd = tt.TenCD;
                        break;
                    }
                }
                cell.Value = tencd;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.NamHoc;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.HocKy;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.SoSVToiDa;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.SoSVDaDK;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                string tengv = "";
                var dsgv = Dao_GiaoVu.DSGiaoVien();
                foreach(var tt in dsgv)
                {
                    if(cd.GVPhuTrach == tt.MaND)
                    {
                        tengv = tt.TenGV;
                        break;
                    }
                }
                cell.Value = tengv;
                row.Cells.Add(cell);

                dataGridViewChuyenDeDuocMo.Rows.Add(row);
            }
        }
        void InitChuyenDeDuocMo()
        {
            CreateColumnChuyenDeDuocMo();
            LoadDGVChuyenDeDuocMo();
        }
        /// <summary>
        /// Các lớp thuộc các huyên đề được mở
        /// </summary>
        void CreateColumnCacLopChuyenDeDuocMo()
        {
            dataGridViewCacLopChuyenDeDangMo.Columns.Clear();
            var malop = new DataGridViewTextBoxColumn();
            malop.HeaderText = "Lớp";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(malop);

            var cd = new DataGridViewTextBoxColumn();
            cd.HeaderText = "Chuyên đề";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(cd);

            var nh = new DataGridViewTextBoxColumn();
            nh.HeaderText = "Năm học";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(nh);

            var hk = new DataGridViewTextBoxColumn();
            hk.HeaderText = "Học kì";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(hk);

            var svtd = new DataGridViewTextBoxColumn();
            svtd.HeaderText = "Sinh viên tối đa";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(svtd);

            //var svddk = new DataGridViewTextBoxColumn();
            //svddk.HeaderText = "Sinh viên đã đăng ký";
            //dataGridViewCacLopChuyenDeDangMo.Columns.Add(svddk);

            var gvpt = new DataGridViewTextBoxColumn();
            gvpt.HeaderText = "Giáo viên phụ trách";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(gvpt);

            dataGridViewCacLopChuyenDeDangMo.Columns[0].Width = 150;
            dataGridViewCacLopChuyenDeDangMo.Columns[1].Width = 500;
            dataGridViewCacLopChuyenDeDangMo.Columns[5].Width = 300;
        }
        void LoadDGVCacLopChuyenDeDuocMo()
        {
            dataGridViewCacLopChuyenDeDangMo.Rows.Clear();
            var ds = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var cd in ds)
            {
                row = new DataGridViewRow();
                row.Tag = cd;

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.MaLop;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                string tencd = "";
                var lqq = Dao_GiaoVu.DSTatCaChuyenDe();
                foreach (var tt in lqq)
                {
                    if (cd.MaCD == tt.MaCD)
                    {
                        tencd = tt.TenCD;
                        break;
                    }
                }
                cell.Value = tencd;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.NamHoc;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.HocKy;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = cd.SoSVToiDa;
                row.Cells.Add(cell);

                //cell = new DataGridViewTextBoxCell();
                //cell.Value = cd.SoSVDaDK;
                //row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                string tengv = "";
                var dsgv = Dao_GiaoVu.DSGiaoVien();
                foreach (var tt in dsgv)
                {
                    if (cd.GVPhuTrach == tt.MaND)
                    {
                        tengv = tt.TenGV;
                        break;
                    }
                }
                cell.Value = tengv;
                row.Cells.Add(cell);

                dataGridViewCacLopChuyenDeDangMo.Rows.Add(row);
            }
        }
        void InitCacLopChuyenDeDuocMo()
        {
            CreateColumnCacLopChuyenDeDuocMo();
            LoadDGVCacLopChuyenDeDuocMo();
        }
        /// <summary>
        /// Xử lí các sự kiện click thao tác usecase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemCD_Click(object sender, EventArgs e)
        {
            panelTrangChu.Visible = false;
            panel.Visible = true;
            this.panel.Controls.Clear();
            ThemChuyenDe frm = new ThemChuyenDe();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            this.panel.Controls.Add(frm);
            frm.Show();
        }

        //Button tra cứu điểm . vì chưa đổi tên button
        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            panelTraCuu.Controls.Clear();
            TraCuuDiem frm = new TraCuuDiem();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            panelTraCuu.Controls.Add(frm);
            frm.Show();
        }

        //Button tra cứu thông tin đăng ký . vì chưa đổi tên button
        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            panelTraCuu.Controls.Clear();
            TraCuuThongTinDangKy frm = new TraCuuThongTinDangKy();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panelTraCuu.Controls.Add(frm);
            frm.Show();
        }

        private void btnSuaCD_Click(object sender, EventArgs e)
        {
            if (dataGridViewTatCaChuyenDe.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Tất cả chuyên đề!");
                tabControlData.SelectedTab = tabPage1;
                return;
            }
            panelTrangChu.Visible = false;
            panel.Visible = true;
            panel.Controls.Clear();

            TatCaChuyenDe tab = new TatCaChuyenDe();
            int VT = dataGridViewTatCaChuyenDe.CurrentCell.RowIndex;
            tab.MaCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[0].Value.ToString();
            tab.TenCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[1].Value.ToString();
            string ttrang = dataGridViewTatCaChuyenDe.Rows[VT].Cells[2].Value.ToString();
            if(ttrang == "Vô hiệu hoá")
            {
                tab.TinhTrang = 0;
            }
            else
            {
                tab.TinhTrang = 1;
            }


            SuaChuyenDe frm = new SuaChuyenDe(tab);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
            
        }

        private void btnMoCD_Click(object sender, EventArgs e)
        {
            if (dataGridViewTatCaChuyenDe.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Tất cả chuyên đề!");
                tabControlData.SelectedTab = tabPage1;
                return;
            }

            int VT = dataGridViewTatCaChuyenDe.CurrentCell.RowIndex;
            string ttrang = dataGridViewTatCaChuyenDe.Rows[VT].Cells[2].Value.ToString();
            if(ttrang == "Đang mở")
            {
                MessageBox.Show("Chuyên đề đã được mở!", "Thông báo");
                return;
            }
            int tinhtr = 1;
            if(ttrang == "Vô hiệu hoá")
            {
                tinhtr = 0;
            }
            TatCaChuyenDe cd = new TatCaChuyenDe
            {
                MaCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[0].Value.ToString(),
                TenCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[1].Value.ToString(),
                TinhTrang = tinhtr
            };

            panelTrangChu.Visible = false;
            panel.Visible = true;
            this.panel.Controls.Clear();
            MoChuyenDe frm = new MoChuyenDe(cd);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            this.panel.Controls.Add(frm);
            frm.Show();
        }

        private void btnCapNhatCD_Click(object sender, EventArgs e)
        {
            if (dataGridViewChuyenDeDuocMo.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Chuyên đề được mở!");
                return;
            }
            int VT = dataGridViewChuyenDeDuocMo.CurrentCell.RowIndex;
            string macd = "";
            var ds = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach(var tt in ds)
            {
                if(tt.TenCD == dataGridViewChuyenDeDuocMo.Rows[VT].Cells[0].Value.ToString())
                {
                    macd = tt.MaCD;
                    break;
                }
            }
            ChuyenDeDuocMo tab = new ChuyenDeDuocMo
            {
                MaCD = macd,
                NamHoc = dataGridViewChuyenDeDuocMo.Rows[VT].Cells[1].Value.ToString(),
                HocKy = Int32.Parse(dataGridViewChuyenDeDuocMo.Rows[VT].Cells[2].Value.ToString()),
                SoSVToiDa = Convert.ToInt32(dataGridViewChuyenDeDuocMo.Rows[VT].Cells[3].Value.ToString()),
                SoSVDaDK = Convert.ToInt32(dataGridViewChuyenDeDuocMo.Rows[VT].Cells[4].Value.ToString()),
                GVPhuTrach = dataGridViewChuyenDeDuocMo.Rows[VT].Cells[5].Value.ToString()
            };


            panelTrangChu.Visible = false;
            panel.Visible = true;
            panel.Controls.Clear();
            CapNhatChuyenDeDangDuocMo frm = new CapNhatChuyenDeDangDuocMo(tab);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }
        private void btnCapNhatGiaoVienPhuTrachCD_Click(object sender, EventArgs e)
        {
            panelTrangChu.Visible = false;
            panel.Visible = true;
            panel.Controls.Clear();
            if (dataGridViewChuyenDeDuocMo.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Chuyên đề được mở!");
                return;
            }
            var tab = new ChuyenDeDuocMo
            {

            };
            CapNhatGiaoVienPhuTrach frm = new CapNhatGiaoVienPhuTrach();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Visible = false;
            panelTrangChu.Visible = true;
            LoadDGV();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            tbTenTK.Enabled = true;
            tbCTK.Enabled = true;
            tbEmail.Enabled = true;
            tbChucVu.Enabled = true;
            tbNgayBatDau.Enabled = true;
            btnLuuChinhSua.Enabled = true;
            btnDoiMatKhau.Enabled = false;
            btnChinhSua.Enabled = false;
        }

        private void btnLuuChinhSua_Click(object sender, EventArgs e)
        {
            tbTenTK.Enabled = false;
            tbCTK.Enabled = false;
            tbEmail.Enabled = false;
            tbChucVu.Enabled = false;
            tbNgayBatDau.Enabled = false;
            btnLuuChinhSua.Enabled = false;
            btnDoiMatKhau.Enabled = true;
            btnChinhSua.Enabled = true;
        }

        private void FrmGiaoVu_Load_1(object sender, EventArgs e)
        {
            panel.Visible = false;
            panelTrangChu.Visible = true;
        }

        private void btnXoaCD_Click(object sender, EventArgs e)
        {
            if (dataGridViewTatCaChuyenDe.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Tất cả chuyên đề!","Thông báo");
                tabControlData.SelectedTab = tabPage1;
                return;
            }
            int VT = dataGridViewTatCaChuyenDe.CurrentCell.RowIndex;
            if (dataGridViewTatCaChuyenDe.Rows[VT].Cells[2].Value.ToString() == "Đang mở")
            {
                MessageBox.Show("Chuyên đề đang được mở không được xoá!","Thông báo");
                return;
            }
            string ndxoa = "Bạn có chắc chắn muốn xoá chuyên đề này?";
            var rs = MessageBox.Show(ndxoa, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            int ttrang = 0;
            if(rs == DialogResult.OK)
            {
                var qq = new TatCaChuyenDe
                {
                    MaCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[0].Value.ToString(),
                    TenCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[1].Value.ToString(),
                    TinhTrang = ttrang
                };
                if(Dao_GiaoVu.XoaChuyenDe(qq))
                {
                    MessageBox.Show("Xoá thành công.", "Thông báo");
                    LoadDGV();
                }
                
            }

        }

        private void btnVoHieuHoaCD_Click(object sender, EventArgs e)
        {
            tabControlData.SelectedTab = tabPageChuyenDeDuocMo;
            if (dataGridViewTatCaChuyenDe.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Tất cả chuyên đề!", "Thông báo");
                return;
            }
            int VT = dataGridViewChuyenDeDuocMo.CurrentCell.RowIndex;
            string ndxoa = "Bạn có chắc chắn muốn vô hiệu hoá chuyên đề này?";
            var rs = MessageBox.Show(ndxoa, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string tencd = dataGridViewChuyenDeDuocMo.Rows[VT].Cells[0].Value.ToString();
            string macd = "";
            var dsmacd = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach(var tt in dsmacd)
            {
                if(tt.TenCD == tencd)
                {
                    macd = tt.MaCD;
                }
            }
            if (rs == DialogResult.OK)
            {
                if (Dao_GiaoVu.VoHieuHoa(macd))
                {
                    MessageBox.Show("Cập nhật thành công.", "Thông báo");
                    LoadDGV();
                }

            }
        }

        private void btnTab1_Click(object sender, EventArgs e)
        {
            tabControlData.SelectedTab = tabPage1;
        }

        private void btnTab2_Click(object sender, EventArgs e)
        {
            tabControlData.SelectedTab = tabPageChuyenDeDuocMo;
        }

        private void btnTab3_Click(object sender, EventArgs e)
        {
            tabControlData.SelectedTab = tabPage2;
        }
    }
}
