using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEW_DTO.TT_TatCaChuyenDe;
using VIEW_BUS.DaoData;
using VIEW_USECASE.GiaoVu;
using VIEW_USECASE.GiaoVu.TraCuu;
using VIEW_DTO.GiaoVu;
using VIEW_DTO.LOGIN;
using System.Threading;

namespace VIEW_USECASE
{
    public partial class FrmGiaoVu : Form
    {
        TaiKhoan tk = new TaiKhoan();
        Thread th;
        string ctk = "";
        string email = "";
        string chucvu = "";
        DateTime nbdct = DateTime.Now;
        public FrmGiaoVu(TaiKhoan tk1)
        {
            //update
            InitializeComponent();
            tk = tk1;
            LoadDGV();
            tabMenu.SelectedIndexChanged += new EventHandler(TabMenu_Selected);
            tb_TTD_MaCD.SelectedIndexChanged += new EventHandler(selectionTenCD);
            tb_TTD_MaSV.TextChanged += new EventHandler(selectionTenND);
            tb_TTDK_MaCD.TextChanged += new EventHandler(LoadLopTheoChuyenDe);
            tb_TTDK_MaSV.TextChanged += new EventHandler(LoadTenSV);

            //Load thoong tin nguowfi dufng
            LoadTTND();

        }

        private void LoadTTND()
        {
            var dsnd = Dao_GiaoVu.DSGiaoVien();
            btnThongTinNguoiDung.LabelText = tk.tentk;
            tbTenTK.Text = tk.tentk;
            foreach (var tt in dsnd)
            {
                if (tt.MaND == tk.tentk)
                {
                    tbCTK.Text = tt.TenGV;
                    ctk = tt.TenGV;
                    tbEmail.Text = tt.Mail;
                    email = tt.Mail;
                    tbChucVu.Text = tt.ChucVu;
                    chucvu = tt.ChucVu;
                    tbNgayBatDau.Text = tt.NgayBDCT.ToString();
                    nbdct = tt.NgayBDCT;
                    break;
                }
            }
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

            //var gvpt = new DataGridViewTextBoxColumn();
            //gvpt.HeaderText = "Giáo viên phụ trách";
            //dataGridViewChuyenDeDuocMo.Columns.Add(gvpt);

            dataGridViewChuyenDeDuocMo.Columns[1].Width = 200;
            dataGridViewChuyenDeDuocMo.Columns[2].Width = 120;
            dataGridViewChuyenDeDuocMo.Columns[3].Width = 220;
            dataGridViewChuyenDeDuocMo.Columns[0].Width = 500;
            //dataGridViewChuyenDeDuocMo.Columns[5].Width = 300;
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

                //SL SV Toi da cua chuyen de + namhoc + hocki
                var dsslsv = Dao_GiaoVu.DSSLSVTheoChuyenDe();
                int slsvtoida1cd = 0;
                foreach(var tt in dsslsv)
                {
                    if(tt.macd == cd.MaCD && tt.namhoc == cd.NamHoc && tt.hocki == cd.HocKy)
                    {
                        slsvtoida1cd = tt.sosvtoida1cd;
                    }

                }
                cell = new DataGridViewTextBoxCell();
                cell.Value = slsvtoida1cd;
                row.Cells.Add(cell);


                //so sv da dangky
                cell = new DataGridViewTextBoxCell();
                var dslopcuacd = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
                List<string> arrlop = new List<string>();
                foreach(var tt in dslopcuacd)
                {
                    if(tt.MaCD == cd.MaCD)
                    {
                        arrlop.Add(tt.MaLop);
                    }
                }
                int svdadk = 0;
                var dsdk = Dao_GiaoVu.DSDangKy();
                foreach(var tt in dsdk)
                {
                    foreach (var tt1 in arrlop)
                    {
                        if(tt1 == tt.malop)
                        {
                            svdadk++;
                        }
                    }
                }
                cell.Value = svdadk.ToString();
                row.Cells.Add(cell);

                //GV phu trach
                //cell = new DataGridViewTextBoxCell();
                //string tengv = "";
                //var dsgv = Dao_GiaoVu.DSGiaoVien();
                //foreach (var tt in dsgv)
                //{
                //    if (cd.GVPhuTrach == tt.MaND)
                //    {
                //        tengv = tt.TenGV;
                //        break;
                //    }
                //}
                //cell.Value = tengv;
                //row.Cells.Add(cell);

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

            var svddk = new DataGridViewTextBoxColumn();
            svddk.HeaderText = "Sinh viên đã đăng ký";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(svddk);

            var gvpt = new DataGridViewTextBoxColumn();
            gvpt.HeaderText = "Giáo viên phụ trách";
            dataGridViewCacLopChuyenDeDangMo.Columns.Add(gvpt);

            //dataGridViewCacLopChuyenDeDangMo.Columns[0].Width = 150;
            //dataGridViewCacLopChuyenDeDangMo.Columns[1].Width = 500;
            //dataGridViewCacLopChuyenDeDangMo.Columns[5].Width = 300;
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

                //
                var dsndk = Dao_GiaoVu.DSNhom();
                int sosvtoida1lop = 0;
                foreach(var tt in dsndk)
                {
                    if(tt.malop == cd.MaLop)
                    {
                        sosvtoida1lop = tt.sosvtoida1nhom;
                    }
                }
                cell = new DataGridViewTextBoxCell();
                cell.Value = sosvtoida1lop;
                row.Cells.Add(cell);

                //
                var dsdk = Dao_GiaoVu.DSDangKy();
                int svdadk1lop = 0;
                foreach (var tt in dsdk)
                {
                    if (tt.malop == cd.MaLop)
                    {
                        svdadk1lop++;
                    }
                }
                cell = new DataGridViewTextBoxCell();
                cell.Value = svdadk1lop;
                row.Cells.Add(cell);

                //
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
                if(tengv == "" || tengv == "no")
                {
                    cell.Value = "Chưa có";
                }
                else
                {
                    cell.Value = tengv;
                }
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
        private void btn_ThemCD_Click(object sender, EventArgs e)
        {
            btn_ThemCD.Enabled = false;
            btnXoaCD.Enabled = false;
            btnSuaCD.Enabled = false;
            btnMoCD.Enabled = false;
            btnVoHieuHoaCD.Enabled = false;
            btnCapNhatCD.Enabled = false;
            btnCapNhatGiaoVienPhuTrach.Enabled = false;
            btnCapNhatThongTinLop.Enabled = false;


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

        private void btnXoaCD_Click_1(object sender, EventArgs e)
        {
            btn_ThemCD.Enabled = false;
            btnXoaCD.Enabled = false;
            btnSuaCD.Enabled = false;
            btnMoCD.Enabled = false;
            btnVoHieuHoaCD.Enabled = false;
            btnCapNhatCD.Enabled = false;
            btnCapNhatGiaoVienPhuTrach.Enabled = false;
            btnCapNhatThongTinLop.Enabled = false;

            if (dataGridViewTatCaChuyenDe.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Tất cả chuyên đề!", "Thông báo");
                tabControlData.SelectedTab = tabPage1;
                return;
            }
            int VT = dataGridViewTatCaChuyenDe.CurrentCell.RowIndex;
            if (dataGridViewTatCaChuyenDe.Rows[VT].Cells[2].Value.ToString() == "Đang mở")
            {
                MessageBox.Show("Chuyên đề đang được mở không được xoá!", "Thông báo");
                return;
            }
            string ndxoa = "Bạn có chắc chắn muốn xoá chuyên đề này?";
            var rs = MessageBox.Show(ndxoa, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            int ttrang = 0;
            if (rs == DialogResult.OK)
            {
                var qq = new TatCaChuyenDe
                {
                    MaCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[0].Value.ToString(),
                    TenCD = dataGridViewTatCaChuyenDe.Rows[VT].Cells[1].Value.ToString(),
                    TinhTrang = ttrang
                };
                if (Dao_GiaoVu.XoaChuyenDe(qq))
                {
                    MessageBox.Show("Xoá thành công.", "Thông báo");
                    kich_TrangChu();
                }

            }
            else
            {
                kich_TrangChu();
            }

        }

        private void btnSuaCD_Click_1(object sender, EventArgs e)
        {
            btn_ThemCD.Enabled = false;
            btnXoaCD.Enabled = false;
            btnSuaCD.Enabled = false;
            btnMoCD.Enabled = false;
            btnVoHieuHoaCD.Enabled = false;
            btnCapNhatCD.Enabled = false;
            btnCapNhatGiaoVienPhuTrach.Enabled = false;
            btnCapNhatThongTinLop.Enabled = false;

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
            if (ttrang == "Vô hiệu hoá")
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

        private void btnMoCD_Click_1(object sender, EventArgs e)
        {
            btn_ThemCD.Enabled = false;
            btnXoaCD.Enabled = false;
            btnSuaCD.Enabled = false;
            btnMoCD.Enabled = false;
            btnVoHieuHoaCD.Enabled = false;
            btnCapNhatCD.Enabled = false;
            btnCapNhatGiaoVienPhuTrach.Enabled = false;
            btnCapNhatThongTinLop.Enabled = false;

            if (dataGridViewTatCaChuyenDe.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Tất cả chuyên đề!");
                tabControlData.SelectedTab = tabPage1;
                return;
            }

            int VT = dataGridViewTatCaChuyenDe.CurrentCell.RowIndex;
            string ttrang = dataGridViewTatCaChuyenDe.Rows[VT].Cells[2].Value.ToString();
            if (ttrang == "Đang mở")
            {
                //MessageBox.Show("Chuyên đề đã được mở!", "Thông báo");
                //kich_TrangChu();
                //return;
            }
            int tinhtr = 1;
            if (ttrang == "Vô hiệu hoá")
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

        private void btnVoHieuHoaCD_Click_1(object sender, EventArgs e)
        {
            //btn_ThemCD.Enabled = false;
            //btnXoaCD.Enabled = false;
            //btnSuaCD.Enabled = false;
            //btnMoCD.Enabled = false;
            //btnVoHieuHoaCD.Enabled = false;
            //btnCapNhatCD.Enabled = false;
            //btnCapNhatGiaoVienPhuTrach.Enabled = false;
            //btnCapNhatThongTinLop.Enabled = false;

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
            string namhoc = dataGridViewChuyenDeDuocMo.Rows[VT].Cells[1].Value.ToString();
            string hocki = dataGridViewChuyenDeDuocMo.Rows[VT].Cells[2].Value.ToString();
            string macd = "";
            var dsmacd = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in dsmacd)
            {
                if (tt.TenCD == tencd)
                {
                    macd = tt.MaCD;
                }
            }
            if (rs == DialogResult.OK)
            {
                if (Dao_GiaoVu.VoHieuHoa(macd,namhoc,hocki))
                {
                    MessageBox.Show("Cập nhật thành công.", "Thông báo");
                    LoadDGV();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Thông báo");
                    LoadDGV();
                }

            }
            else
            {
                kich_TrangChu();
            }
        }

        private void btnCapNhatCD_Click_1(object sender, EventArgs e)
        {
            btn_ThemCD.Enabled = false;
            btnXoaCD.Enabled = false;
            btnSuaCD.Enabled = false;
            btnMoCD.Enabled = false;
            btnVoHieuHoaCD.Enabled = false;
            btnCapNhatCD.Enabled = false;
            btnCapNhatGiaoVienPhuTrach.Enabled = false;
            btnCapNhatThongTinLop.Enabled = false;

            if (dataGridViewChuyenDeDuocMo.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Chuyên đề được mở!");
                return;
            }
            int VT = dataGridViewChuyenDeDuocMo.CurrentCell.RowIndex;
            string macd = "";
            var ds = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in ds)
            {
                if (tt.TenCD == dataGridViewChuyenDeDuocMo.Rows[VT].Cells[0].Value.ToString())
                {
                    macd = tt.MaCD;
                    break;
                }
            }
            ChuyenDeDuocMo tab = new ChuyenDeDuocMo
            {
                MaCD = macd,
                NamHoc = dataGridViewChuyenDeDuocMo.Rows[VT].Cells[1].Value.ToString(),
                HocKy = Int32.Parse(dataGridViewChuyenDeDuocMo.Rows[VT].Cells[2].Value.ToString())
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

        private void btnCapNhatThongTinLop_Click(object sender, EventArgs e)
        {
            btn_ThemCD.Enabled = false;
            btnXoaCD.Enabled = false;
            btnSuaCD.Enabled = false;
            btnMoCD.Enabled = false;
            btnVoHieuHoaCD.Enabled = false;
            btnCapNhatCD.Enabled = false;
            btnCapNhatGiaoVienPhuTrach.Enabled = false;
            btnCapNhatThongTinLop.Enabled = false;

            panelTrangChu.Visible = false;
            panel.Visible = true;
            panel.Controls.Clear();
            if (dataGridViewCacLopChuyenDeDangMo.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Chuyên đề được mở!");
                return;
            }
            int VT = dataGridViewCacLopChuyenDeDangMo.CurrentCell.RowIndex;
            string macd = "";
            var ds = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in ds)
            {
                if (tt.TenCD == dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[1].Value.ToString())
                {
                    macd = tt.MaCD;
                    break;
                }
            }
            ChuyenDeDuocMo tab = new ChuyenDeDuocMo
            {
                MaLop = dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[0].Value.ToString(),
                MaCD = macd,
                NamHoc = dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[2].Value.ToString(),
                HocKy = Int32.Parse(dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[3].Value.ToString()),
                GVPhuTrach = dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[5].Value.ToString()
            };
            CapNhatThongTinLop frm = new CapNhatThongTinLop(tab);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }

        private void btnCapNhatGiaoVienPhuTrach_Click(object sender, EventArgs e)
        {
            btn_ThemCD.Enabled = false;
            btnXoaCD.Enabled = false;
            btnSuaCD.Enabled = false;
            btnMoCD.Enabled = false;
            btnVoHieuHoaCD.Enabled = false;
            btnCapNhatCD.Enabled = false;
            btnCapNhatGiaoVienPhuTrach.Enabled = false;
            btnCapNhatThongTinLop.Enabled = false;

            panelTrangChu.Visible = false;
            panel.Visible = true;
            panel.Controls.Clear();
            if (dataGridViewCacLopChuyenDeDangMo.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Chưa chọn dòng nào trong bảng dữ liệu Chuyên đề được mở!");
                return;
            }
            int VT = dataGridViewCacLopChuyenDeDangMo.CurrentCell.RowIndex;
            string macd = "";
            var ds = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in ds)
            {
                if (tt.TenCD == dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[1].Value.ToString())
                {
                    macd = tt.MaCD;
                    break;
                }
            }
            ChuyenDeDuocMo tab = new ChuyenDeDuocMo
            {
                MaLop = dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[0].Value.ToString(),
                MaCD = macd,
                NamHoc = dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[2].Value.ToString(),
                HocKy = Int32.Parse(dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[3].Value.ToString()),
                GVPhuTrach = dataGridViewCacLopChuyenDeDangMo.Rows[VT].Cells[5].Value.ToString()
            };
            CapNhatGiaoVienPhuTrach frm = new CapNhatGiaoVienPhuTrach(tab);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm);
            frm.Show();
        }


        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            kich_TrangChu();
            tc_menu();
        }
        private void kich_TrangChu()
        {
            btn_ThemCD.Enabled = true;
            btnXoaCD.Enabled = true;
            btnSuaCD.Enabled = true;
            btnMoCD.Enabled = true;
            btnVoHieuHoaCD.Enabled = true;
            btnCapNhatCD.Enabled = true;
            btnCapNhatGiaoVienPhuTrach.Enabled = true;
            btnCapNhatThongTinLop.Enabled = true;

            panel.Controls.Clear();
            panel.Visible = false;
            panelTrangChu.Visible = true;
            LoadDGV();
        }
        private void tc_menu()
        {
            tabMenu.SelectedTab = TabPageQLCD;
            tabControlData.SelectedTab = tabPage1;
        }
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            tbCTK.Enabled = true;
            tbEmail.Enabled = true;
            tbChucVu.Enabled = true;
            tbNgayBatDau.Enabled = true;
            btnLuuChinhSua.Enabled = true;
            btnDoiMatKhau.Enabled = false;
            btnChinhSua.Enabled = false;
        }
        private void btnLuuChinhSua_Click_1(object sender, EventArgs e)
        {
            tbCTK.Enabled = false;
            tbEmail.Enabled = false;
            tbChucVu.Enabled = false;
            tbNgayBatDau.Enabled = false;
            btnLuuChinhSua.Enabled = false;
            btnDoiMatKhau.Enabled = true;
            btnChinhSua.Enabled = true;

            //string mand = tbTenTK.Text;
            //string ctk1 = tbCTK.Text;
            //string email1 = tbEmail.Text;
            //string chucvu1 = tbChucVu.Text;
            //DateTime nbdct1 = DateTime.Parse(tbNgayBatDau.Text);
            GiaoVien gv = new GiaoVien();
            gv.TenGV = tbCTK.Text;
            gv.ChucVu = tbChucVu.Text;
            gv.Mail = tbEmail.Text;
            gv.NgayBDCT = DateTime.Parse(tbNgayBatDau.Text);
            gv.MaND = tbTenTK.Text;
            if (gv.TenGV == ctk && gv.Mail == email && gv.ChucVu == chucvu && gv.NgayBDCT == nbdct)
            {
                MessageBox.Show("Chưa có gì thay đổi để lưu", "Thông báo");
            }
            else
            {
                if (Dao_GiaoVu.CapNhatThongTinNguoiDung(gv)) //mand, ctk1, email1, chucvu1, nbdct1
                {
                    MessageBox.Show("Cập nhật thành công.", "Thông báo");
                    LoadTTND();
                    return;
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật thông tin.", "Thông báo");
                    LoadTTND();
                    return;
                }
            }

        }

        private void FrmGiaoVu_Load_1(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = TabPageQLCD;
            tabControlData.SelectedTab = tabPage1;
            panel.Visible = false;
            panelTrangChu.Visible = true;
            var dsnh = Dao_GiaoVu.DSNamHoc();
            foreach (var tt in dsnh)
            {
                tb_TTD_NamHoc.Items.Add(tt.namhoc);
            }
            var dshk = Dao_GiaoVu.DSHocKy();
            foreach (var tt in dshk)
            {
                tb_TTD_HocKy.Items.Add(tt.hocky);
            }
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in dscd)
            {
                tb_TTD_MaCD.Items.Add(tt.MaCD);
            }
            var dscddm = Dao_GiaoVu.DSChuyenDeDuocMo();
            foreach(var tt in dscddm)
            {
                tb_TTDK_MaCD.Items.Add(tt.MaCD);
            }

        }
        private void LoadLopTheoChuyenDe(object sender, System.EventArgs e)
        {
            tb_TTDK_MaLop.Text = "";
            //load tên lớp
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in dscd)
            {
                if (tt.MaCD == tb_TTDK_MaCD.Text)
                {
                    tb_TTDK_TenCD.Text = tt.TenCD;
                    tb_TTDK_TenCD.Enabled = false;
                    break;
                }
            }

            //load lớp
            tb_TTDK_MaLop.Items.Clear();
            var dscd1 = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            string temp = tb_TTDK_MaCD.Text;
            foreach (var tt in dscd1)
            {
                if (tt.MaCD == temp)
                {
                    tb_TTDK_MaLop.Items.Add(tt.MaLop);
                }
            }
        }
        private void LoadTenSV(object sender, EventArgs e)
        {
            var ds = Dao_GiaoVu.DSSinhVien();
            foreach (var tt in ds)
            {
                if (tt.mand == tb_TTDK_MaSV.Text)
                {
                    tb_TTDK_TenSV.Text = tt.hoten;
                    break;
                }
            }
        }

        private void selectionTenCD(object sender, System.EventArgs e)
        {
            var ds = Dao_GiaoVu.DSTatCaChuyenDe();
            foreach (var tt in ds)
            {
                if (tt.MaCD == tb_TTD_MaCD.Text)
                {
                    tb_TTD_TenCD.Text = tt.TenCD;
                    break;
                }
            }
        }
        private void selectionTenND(object sender, System.EventArgs e)
        {
            var ds = Dao_GiaoVu.DSSinhVien();
            foreach (var tt in ds)
            {
                if (tt.mand == tb_TTD_MaSV.Text)
                {
                    tb_TTD_TenSV.Text = tt.hoten;
                    break;
                }
                else
                {
                    tb_TTD_TenSV.Text = "";
                }
            }
        }

        /// <summary>
        /// Tab control hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Click button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTraCuuDiem_Click(object sender, EventArgs e)
        {
            groupBoxTraCuuDiem.Visible = true;
            groupBoxTraCuuThongTinDK.Visible = false;
            //kick_contentTraCuu();
        }

        private void btnTraCuuDangKy_Click(object sender, EventArgs e)
        {
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuThongTinDK.Visible = true;
            //kick_contentTraCuu();
            //panelTraCuu.Controls.Clear();
            //TraCuuThongTinDangKy frm = new TraCuuThongTinDangKy();
            //frm.TopLevel = false;
            //frm.FormBorderStyle = FormBorderStyle.None;
            //panelTraCuu.Controls.Add(frm);
            //frm.Show();
        }

        private void kick_contentTraCuu()
        {
            panelTrangChu.Visible = false;
            panel.Visible = true;
            panel.Controls.Clear();
            ContentTraCuuDiem frm1 = new ContentTraCuuDiem();
            frm1.TopLevel = false;
            frm1.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm1);
            frm1.Show();
        }
        private void kick_contentTraCuuSV()
        {
            panelTrangChu.Visible = false;
            panel.Visible = true;
            panel.Controls.Clear();
            ContentTraCuuDiem frm1 = new ContentTraCuuDiem();
            frm1.TopLevel = false;
            frm1.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(frm1);
            frm1.Show();
        }
        private void TabMenu_Selected(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab == TabPageQLCD)
            {
                kich_TrangChu();
            }
            if (tabMenu.SelectedTab == TabPageTC)
            {
                kick_contentTraCuu();
            }
            if (tabMenu.SelectedTab == TabPageQT)
            {
                kich_TrangChu();
            }
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            tabMenu.SelectedTab = TabPageQT;
        }


        private void btnTraCuuDataDiem_Click(object sender, EventArgs e)
        {
            if (tb_TTD_NamHoc.Text == "" || KiemtraSpace(tb_TTD_NamHoc.Text) == 0 || tb_TTD_HocKy.Text == "" || KiemtraSpace(tb_TTD_HocKy.Text) == 0 || tb_TTD_MaCD.Text == "" || KiemtraSpace(tb_TTD_MaCD.Text) == 0)

            {
                MessageBox.Show("Thông tin tra cứu không hợp lệ.", "Thông báo");
                return;
            }
            if (tb_TTD_MaSV.Text == "" || KiemtraSpace(tb_TTD_MaSV.Text) == 0)
            {
                var tab = new VIEW_DTO.GiaoVu.TraCuuDiem
                {
                    namhoc = tb_TTD_NamHoc.Text,
                    hocky = Int32.Parse(tb_TTD_HocKy.Text),
                    macd = tb_TTD_MaCD.Text,
                    tencd = tb_TTD_TenCD.Text
                };
                if (tb_TTD_TenCD.Text == "" || KiemtraSpace(tb_TTD_TenCD.Text) == 0)
                {
                    tab.tencd = "no";
                }

                panelTrangChu.Visible = false;
                panel.Visible = true;
                this.panel.Controls.Clear();
                ContentTraCuuDiem frm = new ContentTraCuuDiem(tab);
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.AutoScroll = true;
                this.panel.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                var tab = new VIEW_DTO.GiaoVu.TraCuuDiemSV
                {
                    namhoc = tb_TTD_NamHoc.Text,
                    hocky = Int32.Parse(tb_TTD_HocKy.Text),
                    macd = tb_TTD_MaCD.Text,
                    tencd = tb_TTD_TenCD.Text,
                    mand = tb_TTD_MaSV.Text,
                    tennd = tb_TTD_TenSV.Text
                };
                panelTrangChu.Visible = false;
                panel.Visible = true;
                this.panel.Controls.Clear();
                ContentTraCuuDiem frm = new ContentTraCuuDiem(tab);
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.AutoScroll = true;
                this.panel.Controls.Add(frm);
                frm.Show();

            }

        }
        private void btn_TTDK_TraCuuDK_Click(object sender, EventArgs e)
        {
            TraCuuTTDK lqq = new TraCuuTTDK();
            if (KiemtraSpace(tb_TTDK_MaCD.Text) == 0)
            {
                MessageBox.Show("Mã chuyên đề bắt buộc phải nhập để tra cứu!", "Thông báo");
            }
            var tt = new TraCuuTTDK();
            tt.macd = tb_TTDK_MaCD.Text;
            tt.malop = tb_TTDK_MaLop.Text;
            tt.masv = tb_TTDK_MaSV.Text;
            panelTrangChu.Visible = false;
            panel.Visible = true;
            this.panel.Controls.Clear();
            ContentTraCuuTTDK frm = new ContentTraCuuTTDK(tt);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            this.panel.Controls.Add(frm);
            frm.Show();
        }
        private int KiemtraSpace(string n)
        {
            foreach (char x in n)
            {
                if (x != ' ')
                {
                    return 1;
                }
            }
            return 0;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            string thongbao = "Bạn có chắc chắn muốn đăng xuất?";
            DialogResult rs = MessageBox.Show(thongbao, "Thông báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                th = new Thread(openFormLogin);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
                return;
            }
            else
            {

            }
        }
        private void openFormLogin(object sender)
        {
            Application.Run(new WindowsFormsApplication1.Form1());
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            panelTrangChu.Visible = false;
            panel.Visible = true;
            this.panel.Controls.Clear();
            DoiMatKhau frm = new DoiMatKhau(tbTenTK.Text);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            this.panel.Controls.Add(frm);
            frm.Show();
        }




    }
}
