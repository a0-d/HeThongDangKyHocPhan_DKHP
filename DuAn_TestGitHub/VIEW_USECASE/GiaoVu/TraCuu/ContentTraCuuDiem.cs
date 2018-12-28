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

namespace VIEW_USECASE.GiaoVu.TraCuu
{
    public partial class ContentTraCuuDiem : Form
    {
        public ContentTraCuuDiem(VIEW_DTO.GiaoVu.TraCuuDiem n)
        {
            InitializeComponent();
            Init(n);
        }
        public ContentTraCuuDiem(VIEW_DTO.GiaoVu.TraCuuDiemSV n)
        {
            InitializeComponent();
            InitSV(n);
        }
        public ContentTraCuuDiem()
        {
            InitializeComponent();
        }
        void CreateColumn()
        {
            dataGridViewTraCuuDiem.Columns.Clear();
            var macd = new DataGridViewTextBoxColumn();
            macd.HeaderText = "Mã SV";
            dataGridViewTraCuuDiem.Columns.Add(macd);

            var tencd = new DataGridViewTextBoxColumn();
            tencd.HeaderText = "Tên SV";
            dataGridViewTraCuuDiem.Columns.Add(tencd);

            var lop = new DataGridViewTextBoxColumn();
            lop.HeaderText = "Lớp";
            dataGridViewTraCuuDiem.Columns.Add(lop);

            var cd = new DataGridViewTextBoxColumn();
            cd.HeaderText = "Chuyên đề";
            dataGridViewTraCuuDiem.Columns.Add(cd);

            var tinhtrang = new DataGridViewTextBoxColumn();
            tinhtrang.HeaderText = "Nhóm";
            dataGridViewTraCuuDiem.Columns.Add(tinhtrang);

            var diem = new DataGridViewTextBoxColumn();
            diem.HeaderText = "Điểm";
            dataGridViewTraCuuDiem.Columns.Add(diem);

            //dataGridViewTraCuuDiem.Columns[0].Width = 100;
            //dataGridViewTraCuuDiem.Columns[2].Width = 300;
        }
        void LoadDGV(VIEW_DTO.GiaoVu.TraCuuDiem n)
        {
            dataGridViewTraCuuDiem.Rows.Clear();
            var ds = Dao_GiaoVu.DSDangKy(n);
            var dssv = Dao_GiaoVu.DSSinhVien();
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            var dscddm = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            if (ds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Thông báo");
                dataGridViewTraCuuDiem.Columns.Clear();
                return;
            }
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var tc in ds)
            {
                row = new DataGridViewRow();
                row.Tag = tc;

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.mand;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt in dssv)
                {
                    if (tt.mand == tc.mand)
                    {
                        cell.Value = tt.hoten;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.malop;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt in dscd)
                {
                    if (tt.MaCD == n.macd)
                    {
                        cell.Value = tt.TenCD;
                        break;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.manhom;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.diem;
                row.Cells.Add(cell);

                dataGridViewTraCuuDiem.Rows.Add(row);
            }
        }
        void Init(VIEW_DTO.GiaoVu.TraCuuDiem n)
        {
            CreateColumn();
            LoadDGV(n);
        }
        /// <summary>
        /// Sv
        /// </summary>
        void CreateColumnSV()
        {
            dataGridViewTraCuuDiem.Columns.Clear();
            var macd = new DataGridViewTextBoxColumn();
            macd.HeaderText = "Mã SV";
            dataGridViewTraCuuDiem.Columns.Add(macd);

            var tencd = new DataGridViewTextBoxColumn();
            tencd.HeaderText = "Tên SV";
            dataGridViewTraCuuDiem.Columns.Add(tencd);

            var lop = new DataGridViewTextBoxColumn();
            lop.HeaderText = "Lớp";
            dataGridViewTraCuuDiem.Columns.Add(lop);

            var cd = new DataGridViewTextBoxColumn();
            cd.HeaderText = "Chuyên đề";
            dataGridViewTraCuuDiem.Columns.Add(cd);

            var tinhtrang = new DataGridViewTextBoxColumn();
            tinhtrang.HeaderText = "Nhóm";
            dataGridViewTraCuuDiem.Columns.Add(tinhtrang);

            var diem = new DataGridViewTextBoxColumn();
            diem.HeaderText = "Điểm";
            dataGridViewTraCuuDiem.Columns.Add(diem);

            //dataGridViewTraCuuDiem.Columns[0].Width = 100;
            //dataGridViewTraCuuDiem.Columns[2].Width = 300;
        }
        
        void LoadDGVSV(VIEW_DTO.GiaoVu.TraCuuDiemSV n)
        {
            dataGridViewTraCuuDiem.Rows.Clear();
            var ds = Dao_GiaoVu.DSDangKySV(n);
            var dssv = Dao_GiaoVu.DSSinhVien();
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            var dscddm = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            if (ds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Thông báo");
                dataGridViewTraCuuDiem.Columns.Clear();
                return;
            }
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var tc in ds)
            {
                row = new DataGridViewRow();
                row.Tag = tc;

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.mand;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt in dssv)
                {
                    if (tt.mand == tc.mand)
                    {
                        cell.Value = tt.hoten;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.malop;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt in dscd)
                {
                    if (tt.MaCD == n.macd)
                    {
                        cell.Value = tt.TenCD;
                        break;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.manhom;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tc.diem;
                row.Cells.Add(cell);

                dataGridViewTraCuuDiem.Rows.Add(row);
            }
        }
        void InitSV(VIEW_DTO.GiaoVu.TraCuuDiemSV n)
        {
            CreateColumn();
            LoadDGVSV(n);
        }
    }
}
