using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VIEW_BUS.DAO_GiaoVien;
using VIEW_BUS.DAO_GiaoVien.DAOGiaoVien;

namespace VIEW_BUS
{
    public class BUSGiaoVien
    {
        public string MaNguoiDung;

        public DataTable LayDSChuyeDe()
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayDSChuyeDe();
            
        }
        public DataTable LayDSChuyeDeDuocMo()
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayDSChuyeDeDuocMo();

        }

        public DataTable LayDSChuyeDeDangDayCOLOP(string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayDSChuyeDeDangDayCOLOP(mand);

        }
        public DataTable LayDSChuyeDeDangDay(string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayDSChuyeDeDangDay(mand);
        }
        public DataTable LayKetQuaDiem(string mand, string macd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayKetQuaDiem(mand, macd);

        }
        public DataTable LayKetQuaDiemKoSV(string macd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayKetQuaDiemKoSV(macd);

        }
        public DataTable LayThongTinDangKy(string macd, string nam, int hocki, string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayThongTinDangKy(macd,nam,hocki,macd);

        }
        public DataTable LayThongTinTimKiem(string items)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayThongTinTimKiem(items);

        }

        //Combobox
        public DataTable LopCombobox(string macd, string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LopCombobox(macd, mand);
        }
        public DataTable DeadCombobox(string malop, string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.DeadCombobox(malop, mand);
        }
        public DataTable NamCombobox()
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.NamCombobox();
        }
        public DataTable MaCDDayCombobox()
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.MaCDDayCombobox();
        }
        public DataTable TenCDCombobox()
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.TenCDCombobox();
        }

        //Load txt
        public string TenCDtxt(string macd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.TenCDtxt(macd);
        }
        public string TenNguoiDungtxt(string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.TenNguoiDungtxt(mand);

        }
        public string MailNguoiDungtxt(string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.MailNguoiDungtxt(mand);

        }
        public string NganhNguoiDungtxt(string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.NganhNguoiDungtxt(mand);

        }
        public DateTime NgayCTNguoiDungtxt(string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.NgayCTNguoiDungtxt(mand);

        }
        public string TenSinhVien(string masv)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.TenSinhVien(masv);
        }
        public int SoLuongSinhVien(string macd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.SoLuongSinhVien(macd);
        }
        public int SoLuongNhom(string macd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.SoLuongNhom(macd);
        }
        public int SoLuongLop(string macd, string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.SoLuongLop(macd, mand);
        }
        public int SoLuongLopDayDu(string macd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.SoLuongLopDayDu(macd);
        }

        public int GetMaxIDDEAD(string malop)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.GetMaxIDDEAD(malop);

        }
        public string LayTenLop(string macd, int solop)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayTenLop(macd, solop);

        }
        public string LayMatKhau(string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayMatKhau(mand);

        }
        public int CheckKhaNang(string mand, string tencd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.CheckKhaNang(mand, tencd);
        }
        public int CheckKhaNangXoa(string mand, string tencd)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.CheckKhaNangXoa(mand, tencd);
        }
        public string LayTenDead(string madead, string malop)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayTenDead(madead, malop);

        }
        public DateTime LayThoiHanDead(string madead, string malop)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            return a.LayThoiHanDead(madead, malop);

        }


        //Insert, Update, Delete

        public void InsertDead(string malop, int madead, string tendead, DateTime hanThemdead)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.InsertDead(malop,  madead,  tendead,  hanThemdead);
        }
        public void InsertLop(string macd, string malop, string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.InsertLop(macd,  malop,  mand);
        }

        public void DeleteLop(string macd, string malop)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.DeleteLop(macd, malop);
        }
        public void UpdateDead(int madead, string tendead, DateTime hanThemdead, string malop)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.UpdateDead(madead, tendead, hanThemdead, malop);
        }
        public void UpdateNhomVsSV(string macd, int sosv, int sonhom, string mand)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.UpdateNhomVsSV(macd, sosv, sonhom, mand);
        }
        public void UpdateThongTinNguoiDung(string mand, string ten, string mail, DateTime ngay)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.UpdateThongTinNguoiDung(mand, ten,mail, ngay);
        }
        public void UpdateMatKhau(string mand, string pass)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.UpdateMatKhau(mand, pass);
        }
        public void InsertKhaNang(string tencd, string magv)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.InsertKhaNang(tencd, magv);
        }
        public void DeleteKhaNang(string tencd, string magv)
        {
            DAOGiaoVien a = new DAOGiaoVien();
            a.DeleteKhaNang(tencd, magv);
        }

        
    }
}
