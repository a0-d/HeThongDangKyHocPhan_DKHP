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
using VIEW_DTO.GiaoVu;

namespace VIEW_USECASE.GiaoVu.TraCuu
{
    public partial class ContentTraCuuTTDK : Form
    {
        public ContentTraCuuTTDK(VIEW_DTO.GiaoVu.TraCuuTTDK tc)
        {
            InitializeComponent();
            CreateColumn();
            if(tc.malop == "" && tc.masv == "")
            {
                LoadDGV1(tc);
            }
            else if(tc.malop != "" && tc.masv == "")
            {
                LoadDGV2(tc);
            }
            else if(tc.malop == "" && tc.masv != "")
            {
                LoadDGV3(tc);
            }
            else if(tc.malop != "" && tc.masv != "")
            {
                LoadDGV4(tc);
            }
        }
        void CreateColumn()
        {
            dataGridViewTraCuuTTDK.Columns.Clear();
            var macd = new DataGridViewTextBoxColumn();
            macd.HeaderText = "Mã SV";
            dataGridViewTraCuuTTDK.Columns.Add(macd);

            var tencd = new DataGridViewTextBoxColumn();
            tencd.HeaderText = "Tên SV";
            dataGridViewTraCuuTTDK.Columns.Add(tencd);

            var lop = new DataGridViewTextBoxColumn();
            lop.HeaderText = "Lớp";
            dataGridViewTraCuuTTDK.Columns.Add(lop);

            var cd = new DataGridViewTextBoxColumn();
            cd.HeaderText = "Chuyên đề";
            dataGridViewTraCuuTTDK.Columns.Add(cd);

            var tinhtrang = new DataGridViewTextBoxColumn();
            tinhtrang.HeaderText = "Nhóm";
            dataGridViewTraCuuTTDK.Columns.Add(tinhtrang);
            

            //dataGridViewTraCuuDiem.Columns[0].Width = 100;
            //dataGridViewTraCuuDiem.Columns[2].Width = 300;
        }
        void LoadDGV1(VIEW_DTO.GiaoVu.TraCuuTTDK tc)
        {
            dataGridViewTraCuuTTDK.Rows.Clear();
            var ds = Dao_GiaoVu.DSTTDKMaCD(tc);
            var dssv = Dao_GiaoVu.DSSinhVien();
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            var dscddm = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            if (ds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Thông báo");
                dataGridViewTraCuuTTDK.Columns.Clear();
                return;
            }
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var tt in ds)
            {
                row = new DataGridViewRow();
                row.Tag = tt;

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.masv;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt1 in dssv)
                {
                    if (tt1.mand == tt.masv)
                    {
                        cell.Value = tt1.hoten;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.malop;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt2 in dscddm)
                {
                    if (tt2.MaLop == tt.malop)
                    {
                        foreach(var tt3 in dscd)
                        {
                            if(tt3.MaCD == tt2.MaCD)
                            {
                                cell.Value = tt3.TenCD;
                                break;
                            }
                        }
                        break;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.manhom;
                row.Cells.Add(cell);
                
                dataGridViewTraCuuTTDK.Rows.Add(row);
            }
        }
        void LoadDGV2(VIEW_DTO.GiaoVu.TraCuuTTDK tc)
        {
            dataGridViewTraCuuTTDK.Rows.Clear();
            var ds = Dao_GiaoVu.DSTTDKMaCDMaLop(tc);
            var dssv = Dao_GiaoVu.DSSinhVien();
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            var dscddm = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            if (ds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Thông báo");
                dataGridViewTraCuuTTDK.Columns.Clear();
                return;
            }
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var tt in ds)
            {
                row = new DataGridViewRow();
                row.Tag = tt;

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.masv;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt1 in dssv)
                {
                    if (tt1.mand == tt.masv)
                    {
                        cell.Value = tt1.hoten;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.malop;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt2 in dscddm)
                {
                    if (tt2.MaLop == tt.malop)
                    {
                        foreach (var tt3 in dscd)
                        {
                            if (tt3.MaCD == tt2.MaCD)
                            {
                                cell.Value = tt3.TenCD;
                                break;
                            }
                        }
                        break;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.manhom;
                row.Cells.Add(cell);

                dataGridViewTraCuuTTDK.Rows.Add(row);
            }
        }
        void LoadDGV3(VIEW_DTO.GiaoVu.TraCuuTTDK tc)
        {
            dataGridViewTraCuuTTDK.Rows.Clear();
            var ds = Dao_GiaoVu.DSTTDKMaCDMaSV(tc);
            var dssv = Dao_GiaoVu.DSSinhVien();
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            var dscddm = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            if (ds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Thông báo");
                dataGridViewTraCuuTTDK.Columns.Clear();
                return;
            }
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var tt in ds)
            {
                row = new DataGridViewRow();
                row.Tag = tt;

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.masv;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt1 in dssv)
                {
                    if (tt1.mand == tt.masv)
                    {
                        cell.Value = tt1.hoten;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.malop;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt2 in dscddm)
                {
                    if (tt2.MaLop == tt.malop)
                    {
                        foreach (var tt3 in dscd)
                        {
                            if (tt3.MaCD == tt2.MaCD)
                            {
                                cell.Value = tt3.TenCD;
                                break;
                            }
                        }
                        break;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.manhom;
                row.Cells.Add(cell);

                dataGridViewTraCuuTTDK.Rows.Add(row);
            }
        }
        void LoadDGV4(VIEW_DTO.GiaoVu.TraCuuTTDK tc)
        {
            dataGridViewTraCuuTTDK.Rows.Clear();
            var ds = Dao_GiaoVu.DSTTDKMaCDMaLopMaSV(tc);
            var dssv = Dao_GiaoVu.DSSinhVien();
            var dscd = Dao_GiaoVu.DSTatCaChuyenDe();
            var dscddm = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            if (ds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Thông báo");
                dataGridViewTraCuuTTDK.Columns.Clear();
                return;
            }
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            foreach (var tt in ds)
            {
                row = new DataGridViewRow();
                row.Tag = tt;

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.masv;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt1 in dssv)
                {
                    if (tt1.mand == tt.masv)
                    {
                        cell.Value = tt1.hoten;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.malop;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                foreach (var tt2 in dscddm)
                {
                    if (tt2.MaLop == tt.malop)
                    {
                        foreach (var tt3 in dscd)
                        {
                            if (tt3.MaCD == tt2.MaCD)
                            {
                                cell.Value = tt3.TenCD;
                                break;
                            }
                        }
                        break;
                    }
                }
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = tt.manhom;
                row.Cells.Add(cell);

                dataGridViewTraCuuTTDK.Rows.Add(row);
            }
        }
    }
}
