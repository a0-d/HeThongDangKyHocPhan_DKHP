using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using VIEW_DTO.GiaoVu;
using VIEW_DTO.LOGIN;
using VIEW_DTO.TT_TatCaChuyenDe;

namespace VIEW_BUS.DaoData
{
    public class Dao_GiaoVu
    {
        static string cnString;
        static string nameCS = "HeThongDangKyHocPhan";
        static SqlConnection cn;
        static Dao_GiaoVu()
        {
            cnString = ConfigurationManager.ConnectionStrings[nameCS].ConnectionString;
            cn = new SqlConnection(cnString);
        }
        static SqlCommand CreateCommand()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }
            var cm = new SqlCommand();
            cm.Connection = cn;
            return cm;
        }

        public static string ToMD5(string str)
        {
            string result = "";
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer.Length; i++)
            {
                result += buffer[i].ToString();
            }
            return result;
        }

        /// <summary>
        /// Các danh sách cần dùng
        /// </summary>
        /// <returns></returns>
        public static List<ChuyenDeDuocMo> DSChuyenDeDuocMo()
        {
            var lqq = new List<ChuyenDeDuocMo>();
            var cm = CreateCommand();
            cm.CommandText = @"Select distinct MaCD,NamHoc,HocKy,SONTOIDA,SOSVTOIDA,MODKHP,DONGDKHP,TrangThai from CHUYENDEDUOCMO  where TrangThai = N'mở'";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(ChuyenDeDuocMo.ReadChuyenDeDuocMo(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<ChuyenDeDuocMo> DSCacLopChuyenDeDuocMo()
        {
            var lqq = new List<ChuyenDeDuocMo>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MaLop,MaCD,NamHoc,HocKy,SONTOIDA,SOSVTOIDA,MODKHP,DONGDKHP,GVPHUTRACH,TrangThai from CHUYENDEDUOCMO   where TrangThai = N'mở'";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(ChuyenDeDuocMo.ReadCacLopChuyenDeDuocMo(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<TatCaChuyenDe> DSTatCaChuyenDe()
        {
            var lqq = new List<TatCaChuyenDe>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MACD,TENCD,TINHTRANG from CHUYENDE";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(TatCaChuyenDe.ReadTatCaChuyenDe(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<GiaoVien> DSGiaoVien()
        {
            var lqq = new List<GiaoVien>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MAND,MANGANH,TENGV,CHUCVU,MAIL,NGAYBDCT from GiaoVien";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(GiaoVien.ReadGiaoVien(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<BaoGom> DSBaoGom()
        {
            var lqq = new List<BaoGom>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MANGANH,MACD from BaoGom";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(BaoGom.ReadBaoGom(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<Nganh> DSNganh()
        {
            var lqq = new List<Nganh>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MANGANH,TENNGANH,TONGSV,SOLUONGCDHT from Nganh";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(Nganh.ReadNganh(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<NamHoc> DSNamHoc()
        {
            var lqq = new List<NamHoc>();
            var cm = CreateCommand();
            cm.CommandText = @"Select distinct NAMHOC from HOCKY";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(NamHoc.ReadNamHoc(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<HocKy> DSHocKy()
        {
            var lqq = new List<HocKy>();
            var cm = CreateCommand();
            cm.CommandText = @"Select distinct HOCKY from HOCKY";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(HocKy.ReadHocKy(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<Nhom> DSNhom()
        {
            var lqq = new List<Nhom>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MALOP,MANHOM,SOSVDADKNHOM,SOSVTOIDANHOM from NHOM";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(Nhom.ReadNhom(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<Nhom> DSNhom(string mal)
        {
            var lqq = new List<Nhom>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MALOP,MANHOM,SOSVDADK from NHOM where MaLop = @malop1";
            cm.Parameters.Add(new SqlParameter("@malop1", mal));
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(Nhom.ReadNhom(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<KhanNang> DSKhaNang()
        {
            var lqq = new List<KhanNang>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MAND,MACD from KHANANG";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(KhanNang.ReadKhaNang(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<DangKy> DSDangKy()
        {
            var lqq = new List<DangKy>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MAND,MALOP,MANHOM,Diem from DANGKI";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(DangKy.ReadDangKy(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<DangKy> DSDangKy(VIEW_DTO.GiaoVu.TraCuuDiem n)
        {
            var lqq = new List<DangKy>();
            var cm = CreateCommand();
            cm.CommandText = @"Select dk.* from DANGKI dk,ChuyenDeDuocMo cd where dk.MaLop = cd.MaLop and cd.MaCD = @macd and cd.NamHoc = @ngay and cd.HocKy = @hocky";
            cm.Parameters.Add(new SqlParameter("@macd", n.macd));
            cm.Parameters.Add(new SqlParameter("@ngay", n.namhoc));
            cm.Parameters.Add(new SqlParameter("@hocky", n.hocky));
            var reader = cm.ExecuteReader();

            while (reader.Read())
            {
                lqq.Add(DangKy.ReadDangKy(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<DangKy> DSDangKySV(VIEW_DTO.GiaoVu.TraCuuDiemSV n)
        {
            var lqq = new List<DangKy>();
            var cm = CreateCommand();
            cm.CommandText = @"Select dk.MAND,dk.MALOP,dk.MANHOM,dk.Diem from DANGKI dk,ChuyenDeDuocMo cd where dk.MaLop = cd.MaLop and cd.MaCD = @macd and cd.NamHoc = @ngay and cd.HocKy = @hocky and dk.MaND = @mand";
            cm.Parameters.Add(new SqlParameter("@macd", n.macd));
            cm.Parameters.Add(new SqlParameter("@ngay", n.namhoc));
            cm.Parameters.Add(new SqlParameter("@hocky", n.hocky));
            cm.Parameters.Add(new SqlParameter("@mand", n.mand));
            var reader = cm.ExecuteReader();

            while (reader.Read())
            {
                lqq.Add(DangKy.ReadDangKy(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<SinhVien> DSSinhVien()
        {
            var lqq = new List<SinhVien>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MAND,MANGANH,HOTEN,PHAI,NGAYSINH,DIACHI,MAIL from SINHVIEN";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(SinhVien.ReadSinhVien(reader));
            }
            cn.Close();
            return lqq;
        }
        public static List<TraCuuTTDK> DSTTDKMaCD(VIEW_DTO.GiaoVu.TraCuuTTDK tc)
        {
            var lqq = new List<TraCuuTTDK>();
            var cm = CreateCommand();
            cm.CommandText = @"Select dk.MAND,dk.MALOP,dk.MANHOM from DangKi dk where dk.MALOP in (select cd.MALOP from ChuyenDeDuocMo cd where cd.MaCD = @macd)";
            cm.Parameters.Add(new SqlParameter("@macd", tc.macd));
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                var tt = new TraCuuTTDK();
                tt.masv = Convert.ToString(reader[0]);
                tt.malop = Convert.ToString(reader[1]);
                tt.manhom = Convert.ToString(reader[2]);
                lqq.Add(tt);
            }
            cn.Close();
            return lqq;
        }
        public static List<TraCuuTTDK> DSTTDKMaCDMaLop(TraCuuTTDK tc)
        {
            var lqq = new List<TraCuuTTDK>();
            var cm = CreateCommand();
            cm.CommandText = @"Select dk.MAND,dk.MALOP,dk.MANHOM from DangKi dk where dk.MALOP in (select cd.MALOP from ChuyenDeDuocMo cd where cd.MaCD = @macd) and dk.MALOP = @malop";
            cm.Parameters.Add(new SqlParameter("@macd", tc.macd));
            cm.Parameters.Add(new SqlParameter("@malop", tc.malop));
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                var tt = new TraCuuTTDK();
                tt.masv = Convert.ToString(reader[0]);
                tt.malop = Convert.ToString(reader[1]);
                tt.manhom = Convert.ToString(reader[2]);
                lqq.Add(tt);
            }
            cn.Close();
            return lqq;
        }
        public static List<TraCuuTTDK> DSTTDKMaCDMaLopMaSV(TraCuuTTDK tc)
        {
            var lqq = new List<TraCuuTTDK>();
            var cm = CreateCommand();
            cm.CommandText = @"Select dk.MAND,dk.MALOP,dk.MANHOM from DangKi dk where dk.MALOP in (select cd.MALOP from ChuyenDeDuocMo cd where cd.MaCD = @macd) and dk.MALOP = @malop and dk.MAND = @masv";
            cm.Parameters.Add(new SqlParameter("@macd", tc.macd));
            cm.Parameters.Add(new SqlParameter("@malop", tc.malop));
            cm.Parameters.Add(new SqlParameter("@masv", tc.masv));
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                var tt = new TraCuuTTDK();
                tt.masv = Convert.ToString(reader[0]);
                tt.malop = Convert.ToString(reader[1]);
                tt.manhom = Convert.ToString(reader[2]);
                lqq.Add(tt);
            }
            cn.Close();
            return lqq;
        }
        public static List<TraCuuTTDK> DSTTDKMaCDMaSV(TraCuuTTDK tc)
        {
            var lqq = new List<TraCuuTTDK>();
            var cm = CreateCommand();
            cm.CommandText = @"Select dk.MAND,dk.MALOP,dk.MANHOM from DangKi dk where dk.MALOP in (select cd.MALOP from ChuyenDeDuocMo cd where cd.MaCD = @macd) and dk.MAND = @masv";
            cm.Parameters.Add(new SqlParameter("@macd", tc.macd));
            cm.Parameters.Add(new SqlParameter("@masv", tc.masv));
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                var tt = new TraCuuTTDK();
                tt.masv = Convert.ToString(reader[0]);
                tt.malop = Convert.ToString(reader[1]);
                tt.manhom = Convert.ToString(reader[2]);
                lqq.Add(tt);
            }
            cn.Close();
            return lqq;
        }
        public static List<TaiKhoan> DSTaiKhoan()
        {
            var lqq = new List<TaiKhoan>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MAND,PASSWORD,TINHTRANGTK from TaiKhoan";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(TaiKhoan.ReadTaiKhoan(reader));
            }
            cn.Close();
            return lqq;
        }

        public static List<SOLUONGSVTHEOCHUYENDEDUOCMO> DSSLSVTheoChuyenDe()
        {
            var lqq = new List<SOLUONGSVTHEOCHUYENDEDUOCMO>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MACD,NAMHOC,HOCKY,SOSVTOIDA1CD from SOLUONGSV";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                lqq.Add(SOLUONGSVTHEOCHUYENDEDUOCMO.ReadSLSVTheoCD(reader));
            }
            cn.Close();
            return lqq;
        }
        
        public static List<ChucVu> DSChucVu()
        {
            var lqq = new List<ChucVu>();
            var cm = CreateCommand();
            cm.CommandText = @"select distinct CHUCVU from GIAOVIEN";
            var reader = cm.ExecuteReader();
            while(reader.Read())
            {
                lqq.Add(ChucVu.ReadChucVu(reader));
            }
            cn.Close();
            return lqq;
        }
        
        public static List<SinhVienDayDu> DSSinhVienDayDu()
        {
            var lqq = new List<SinhVienDayDu>();
            var cm = CreateCommand();
            cm.CommandText = @"Select MAND,HOTEN,NGAYSINH,MANGANH,PHAI,DIACHI,MAIL from SINHVIEN";
            var reader = cm.ExecuteReader();
            while(reader.Read())
            {
                lqq.Add(SinhVienDayDu.ReadSinhVienDayDu(reader));
            }
            cn.Close();
            return lqq;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        public static string LoginTK(VIEW_DTO.LOGIN.TaiKhoan tk)
        {
            if (LoaiTK(tk) == "KHONGTONTAI")
            {
                return "KHONGTONTAI";
            }
            else
            {
                if (LoaiTK(tk) == "KHOA")
                {
                    return "KHOA";
                }
                else
                {
                    if (LoaiTK(tk) == "GIAOVIEN")
                    {
                        return "GIAOVIEN";
                    }
                    else if (LoaiTK(tk) == "GIAOVU")
                    {
                        return "GIAOVU";
                    }
                }
            }
            return "false";
        }
        public static bool CheckTK(VIEW_DTO.LOGIN.TaiKhoan tk)
        {
            if (tk.tentk == "" || CheckSpace(tk.tentk) == 1)
            {
                return false;
            }
            if (tk.mk == "" || CheckSpace(tk.mk) == 1)
            {
                return false;
            }
            return true;
        }
        private static int CheckSpace(string n)
        {
            string[] arr = n.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var tt in arr)
            {
                if (tt != " ")
                {
                    return 0;
                }
            }
            return 1;
        }
        private static string LoaiTK(TaiKhoan tk)
        {
            var cm = CreateCommand();
            cm.CommandText = @"Select tk.MAND,tk.LoaiTK,tk.TinhTrangTK from TaiKhoan tk where tk.MAND = @mand and tk.PASSWORD = @mk";
            cm.Parameters.Add(new SqlParameter("@mand", tk.tentk));
            cm.Parameters.Add(new SqlParameter("@mk", tk.mk));
            string dem = "";
            int loai = 0;
            string tinhtrang = "";
            var reader = cm.ExecuteReader();
            while (reader.Read())
            {
                dem = reader[0].ToString();
                loai = Int32.Parse(reader[1].ToString());
                tinhtrang = reader[2].ToString();
            }
            cn.Close();


            var cm1 = CreateCommand();
            cm1.CommandText = @"Select tk.MAND from TaiKhoan tk where tk.MAND = @mand";
            cm1.Parameters.Add(new SqlParameter("@mand", tk.tentk));
            string tempTK = "";
            var reader1 = cm1.ExecuteReader();
            while (reader1.Read())
            {
                tempTK = reader1[0].ToString();
            }
            cn.Close();


            if (tempTK == "")
            {
                return "KHONGTONTAI";
            }
            else
            {
                if (dem == tk.tentk)
                {
                    if (tinhtrang == "Mo")
                    {
                        if (loai == 1)
                        {
                            return "GIAOVIEN";
                        }
                        else
                        {
                            return "GIAOVU";
                        }
                    }
                    else
                    {
                        return "KHOA";
                    }
                }
            }
            return "false";
        }
        /// <summary>
        /// Thao tác click
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="baogom"></param>
        /// <returns></returns>
        public static bool ThemChuyenDe(TatCaChuyenDe cd, BaoGom baogom)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = (@"Insert into ChuyenDe(MaCD,TenCD,TINHTRANG,SOSVTOIDA1CD) values(@macd,@tencd,@tinhtrang,0)");
                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                cm.Parameters.Add(new SqlParameter("@tencd", cd.TenCD));
                cm.Parameters.Add(new SqlParameter("@tinhtrang", cd.TinhTrang));
                int rs1 = cm.ExecuteNonQuery();

                var bg = CreateCommand();
                bg.CommandText = (@"Insert into BaoGom(MANGANH,MACD) values(@manganh,@macd)");
                bg.Parameters.Add(new SqlParameter("@manganh", baogom.MaNganh));
                bg.Parameters.Add(new SqlParameter("@macd", baogom.MaCD));
                int rs2 = bg.ExecuteNonQuery();
                cn.Close();

                return rs1 + rs2 > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        public static bool SuaChuyenDe(TatCaChuyenDe cd)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = (@"Update ChuyenDe set TenCD=@tencd,TinhTrang=@tinhtrang where MaCD = @macd");
                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                cm.Parameters.Add(new SqlParameter("@tencd", cd.TenCD));
                cm.Parameters.Add(new SqlParameter("@tinhtrang", cd.TinhTrang));
                int rs1 = cm.ExecuteNonQuery();
                cn.Close();
                return rs1 > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public static bool MoChuyenDe(ChuyenDeDuocMo cd)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = @"Insert into ChuyenDeDuocMo values(@malop,@macd,@namhoc,@hocky,@sontoida,@sosvtoida,@modkhp,@ktdkhp,@gvpt,@trangthai)";
                cm.Parameters.Add(new SqlParameter("@malop", cd.MaLop));
                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                cm.Parameters.Add(new SqlParameter("@namhoc", cd.NamHoc));
                cm.Parameters.Add(new SqlParameter("@hocky", cd.HocKy));
                cm.Parameters.Add(new SqlParameter("@sontoida", cd.SoNToiDa1Lop));
                cm.Parameters.Add(new SqlParameter("@sosvtoida", cd.slsv1lop));
                cm.Parameters.Add(new SqlParameter("@modkhp", cd.MoDkHP));
                cm.Parameters.Add(new SqlParameter("@ktdkhp", cd.KtDkHP));
                cm.Parameters.Add(new SqlParameter("@gvpt", cd.GVPhuTrach));
                cm.Parameters.Add(new SqlParameter("@trangthai", "mở"));
                int rs = cm.ExecuteNonQuery();
                cn.Close();
                return rs > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public static bool MoNhomThuocChuyenDe(Nhom nh)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = @"Insert into NHOM(MALOP,MANHOM,SOSVDADKNHOM,SOSVTOIDANHOM) values(@malop,@manhom,@sosvdadk,@sosvtoida1nhom)";
                cm.Parameters.Add(new SqlParameter("@malop", nh.malop));
                cm.Parameters.Add(new SqlParameter("@manhom", nh.manhom));
                cm.Parameters.Add(new SqlParameter("@sosvdadk", nh.sosvddk));
                cm.Parameters.Add(new SqlParameter("@sosvtoida1nhom", nh.sosvtoida1nhom));
                int rs = cm.ExecuteNonQuery();
                cn.Close();
                return rs > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public static bool XoaChuyenDe(TatCaChuyenDe cd)
        {
            try
            {
                var cmN = CreateCommand();
                cmN.CommandText = @"delete from NHOM where MaLop in (select cddm.MaLop from ChuyenDeDuocMo cddm where cddm.MaCD = @macd)";
                cmN.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                int rsN = cmN.ExecuteNonQuery();

                var cm = CreateCommand();
                cm.CommandText = @"delete from BaoGom where MaCD = @macd";
                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                int rs = cm.ExecuteNonQuery();

                var cmKN = CreateCommand();
                cmKN.CommandText = @"delete from KhaNang where MaCD = @macd";
                cmKN.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                int rsKN = cmKN.ExecuteNonQuery();

                var cmDL = CreateCommand();
                cmDL.CommandText = @"delete from DEADLINEBAITAP where MaLop in (select cddm.MaLop from ChuyenDeDuocMo cddm where cddm.MaCD = @macd)";
                cmDL.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                int rsDL = cmKN.ExecuteNonQuery();

                var cmCDDM = CreateCommand();
                cmCDDM.CommandText = @"delete from ChuyenDeDuocMo where MaCD =  @macd";
                cmCDDM.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                int rsCDDM = cmCDDM.ExecuteNonQuery();

                var cmcd = CreateCommand();
                cmcd.CommandText = @"delete from ChuyenDe where MaCD = @macd";
                cmcd.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                int rscd = cmcd.ExecuteNonQuery();

                cn.Close();
                return rs + rsKN + rsDL + rsN + rsCDDM + rscd > 0;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public static bool VoHieuHoa(string cd, string namhoc, string hocki)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = @"Update ChuyenDeDuocMo set TrangThai = N'Đóng' where MaCD = @macd and NamHoc = @namhoc and HocKy=@hocki";
                cm.Parameters.Add(new SqlParameter("@macd", cd));
                cm.Parameters.Add(new SqlParameter("@namhoc", namhoc));
                cm.Parameters.Add(new SqlParameter("@hocki", hocki));
                int rs = cm.ExecuteNonQuery();

                var cm1 = CreateCommand();
                cm1.CommandText = @"Update ChuyenDe set TinhTrang = 0 where MaCD = @macd";
                cm1.Parameters.Add(new SqlParameter("@macd", cd));
                int rs1 = cm1.ExecuteNonQuery();

                cn.Close();
                return rs + rs1 > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public static bool CapNhatGiaoVienPhuTrach(ChuyenDeDuocMo cd)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = @"Update ChuyenDeDuocMo set GVPhuTrach = @gvphutrach where MaLop = @malop and MaCD = @macd";
                cm.Parameters.Add(new SqlParameter("@gvphutrach", cd.GVPhuTrach));
                cm.Parameters.Add(new SqlParameter("@malop", cd.MaLop));
                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                int rs = cm.ExecuteNonQuery();
                cn.Close();
                return rs > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public static bool DoiMatKhau(TaiKhoan tk)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = @"Update TAIKHOAN set PASSWORD = @mkm where MAND = @mand";
                cm.Parameters.Add(new SqlParameter("@mkm", tk.mk));
                cm.Parameters.Add(new SqlParameter("@mand", tk.tentk));
                int rs = cm.ExecuteNonQuery();
                cn.Close();
                return rs > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public static bool CapNhatCDDuocMo(ChuyenDeDuocMo x, int SoNToiDa1Lop, int slsv1lop, int sll, int slsvtoida1nhom)
        {
            //MessageBox.Show(SoNToiDa1Lop.ToString());//4
            //MessageBox.Show(x.SoNToiDa1Lop.ToString());//0
            //MessageBox.Show(sll.ToString());//3
            var dscddm = Dao_GiaoVu.DSCacLopChuyenDeDuocMo();
            List<string> arrTenLop = new List<string>();
            int solop = 0;
            foreach (var tt in dscddm)
            {
                if (tt.MaCD == x.MaCD && tt.NamHoc == x.NamHoc && tt.HocKy == x.HocKy)
                {
                    arrTenLop.Add(tt.MaLop);
                    solop++;
                }
            }

            //MessageBox.Show(solop.ToString());//4
            if (sll <= solop)
            {
                //cập nhật nhóm khi số lượng lớp cần update ít hơn số lượng lớp cũ
                if (SoNToiDa1Lop < x.SoNToiDa1Lop)
                {
                    for (int j = 1; j <= solop; j++)
                    {
                        string malop = x.MaLop + j;
                        for (int i = 1; i <= SoNToiDa1Lop; i++)
                        {
                            string tennhom = malop + "_" + i;
                            Dao_GiaoVu.SLSVNhomCapNhat(malop, tennhom, slsvtoida1nhom);
                        }
                    }
                    for (int j = 1; j <= solop; j++)
                    {
                        string malop = x.MaLop + j;
                        var dsnhom = Dao_GiaoVu.DSNhom();
                        int nhommax = 0;
                        foreach(var tt in dsnhom)
                        {
                            if(malop == tt.malop)
                            {
                                for(int i= tt.manhom.Length-1;i>-1;i--)
                                {
                                    if(tt.manhom[i] == '_')
                                    {
                                        int nhommaxtemp = Int32.Parse(tt.manhom.Substring(i + 1));
                                        if(nhommaxtemp > nhommax)
                                        {
                                            nhommax = nhommaxtemp;
                                        }
                                    }
                                }
                            }
                        }
                        for (int i = nhommax; i > SoNToiDa1Lop; i--)
                        {
                            string tennhom = malop + "_" + i;
                            Dao_GiaoVu.XoaNhomCapNhat(malop, tennhom);
                        }
                    }
                }
                else if (SoNToiDa1Lop > x.SoNToiDa1Lop)
                {
                    for (int j = 1; j <= solop; j++)
                    {
                        string malop = x.MaLop + j;
                        for (int i = x.SoNToiDa1Lop + 1; i <= SoNToiDa1Lop; i++)
                        {
                            string tennhom = malop + "_" + i;
                            Dao_GiaoVu.ThemNhomCapNhat(malop, tennhom, slsvtoida1nhom);
                        }
                    }
                    for (int j = 1; j <= solop; j++)
                    {
                        string malop = x.MaLop + j;
                        for (int i = 1; i <= SoNToiDa1Lop; i++)
                        {
                            string tennhom = malop + "_" + i;
                            Dao_GiaoVu.SLSVNhomCapNhat(malop, tennhom, slsvtoida1nhom);
                        }
                    }
                }
                else
                {
                    for (int j = 1; j <= solop; j++)
                    {
                        string malop = x.MaLop + j;
                        for (int i = 1; i <= SoNToiDa1Lop; i++)
                        {
                            string tennhom = malop + "_" + i;
                            Dao_GiaoVu.SLSVNhomCapNhat(malop, tennhom, slsvtoida1nhom);
                        }
                    }
                }
                //cập nhật lại lớp
                for (int i = solop; i > sll; i--)
                {
                    string malop = x.MaLop + i;
                    Dao_GiaoVu.XoaLop(x, malop);
                }

            }
            else if (sll > solop)
            {
                //Thêm lớp và thêm nhóm ứng với lớp đó
                for (int i = solop + 1; i <= sll; i++)
                {
                    string malop = x.MaLop + i;
                    Dao_GiaoVu.ThemLopKhiCapNhat(x, malop, SoNToiDa1Lop, slsv1lop);
                    for (int j = 1; j <= SoNToiDa1Lop; j++)
                    {
                        string manhom = malop + "_" + j;
                        Dao_GiaoVu.ThemNhomTheoLopKhiCapNhat(malop, manhom, slsvtoida1nhom);
                    }
                }


                //Cập nhật lại nhóm của những nhóm đã có trước đó
                if (SoNToiDa1Lop > x.SoNToiDa1Lop)
                {
                    for (int i = 1; i <= solop; i++)
                    {
                        string malop = x.MaLop + i;
                        for (int j = x.SoNToiDa1Lop + 1; j <= SoNToiDa1Lop; j++)
                        {
                            string manhom = malop + "_" + j;
                            Dao_GiaoVu.ThemNhomTheoLopKhiCapNhat(malop, manhom, slsvtoida1nhom);
                        }
                    }
                    for (int i = 1; i <= solop; i++)
                    {
                        string malop = x.MaLop + i;
                        for (int j = 1; j <= SoNToiDa1Lop; j++)
                        {
                            string tennhom = malop + "_" + j;
                            Dao_GiaoVu.SLSVNhomCapNhat(malop, tennhom, slsvtoida1nhom);
                        }
                    }
                }
                else if (SoNToiDa1Lop < x.SoNToiDa1Lop)
                {
                    for (int i = 1; i <= solop; i++)
                    {
                        string malop = x.MaLop + i;
                        for (int j = x.SoNToiDa1Lop; j > SoNToiDa1Lop; j--)
                        {
                            string manhom = malop + "_" + j;
                            Dao_GiaoVu.XoaNhomCapNhat(malop, manhom);
                        }
                    }
                    for (int j = 1; j <= solop; j++)
                    {
                        string malop = x.MaLop + j;
                        for (int i = 1; i <= SoNToiDa1Lop; i++)
                        {
                            string tennhom = malop + "_" + i;
                            Dao_GiaoVu.SLSVNhomCapNhat(malop, tennhom, slsvtoida1nhom);
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= sll; i++)
                    {
                        string malop = x.MaLop + i;
                        for (int j = 1; j <= SoNToiDa1Lop; j++)
                        {
                            string tennhom = malop + "_" + j;
                            Dao_GiaoVu.SLSVNhomCapNhat(malop, tennhom, slsvtoida1nhom);
                        }
                    }
                }


            }
            if(SoNToiDa1Lop != x.SoNToiDa1Lop)
            {
                for(int i = 1;i<=sll;i++)
                {
                    string malop = x.MaLop + i;
                    var cm = CreateCommand();
                    cm.CommandText = @"update CHUYENDEDUOCMO set SONTOIDA = @sonhom where MALOP = @malop and MACD = @macd and NAMHOC = @namhoc and HOCKY = @hocky";
                    cm.Parameters.Add(new SqlParameter("@sonhom", SoNToiDa1Lop));
                    cm.Parameters.Add(new SqlParameter("@malop",malop));
                    cm.Parameters.Add(new SqlParameter("@macd", x.MaCD));
                    cm.Parameters.Add(new SqlParameter("@namhoc", x.NamHoc));
                    cm.Parameters.Add(new SqlParameter("@hocky", x.HocKy));
                    int rs = cm.ExecuteNonQuery();
                    cn.Close();
                }
                
                
            }
            if (slsv1lop != x.slsv1lop)
            {
                for (int i = 1; i <= sll; i++)
                {
                    string malop = x.MaLop + i;
                    Dao_GiaoVu.SLSV1LopKhiCapNhat(x, malop, slsv1lop);
                }
                int slsv = sll * slsv1lop;
                var cm = CreateCommand();
                cm.CommandText = @"update SOLUONGSV set SOSVTOIDA1CD = @slsv where MACD = @macd and NAMHOC = @namhoc and HOCKY = @hocky";
                cm.Parameters.Add(new SqlParameter("@macd", x.MaCD));
                cm.Parameters.Add(new SqlParameter("@namhoc", x.NamHoc));
                cm.Parameters.Add(new SqlParameter("@hocky", x.HocKy));
                cm.Parameters.Add(new SqlParameter("@slsv", slsv));
                int rs = cm.ExecuteNonQuery();

                if (rs == 0)
                {
                    return false;
                }
            }
            return true;

        }

        public static bool SLSV1LopKhiCapNhat(ChuyenDeDuocMo x, string malop, int slsv1lop)
        {
            var cm = CreateCommand();
            cm.CommandText = @"update CHUYENDEDUOCMO set SOSVTOIDA = @sosvtoida where MALOP = @malop and MACD = @macd and NAMHOC = @namhoc and HOCKY = @hocky";
            cm.Parameters.Add(new SqlParameter("@sosvtoida", slsv1lop));
            cm.Parameters.Add(new SqlParameter("@malop", malop));
            cm.Parameters.Add(new SqlParameter("@macd", x.MaCD));
            cm.Parameters.Add(new SqlParameter("@namhoc", x.NamHoc));
            cm.Parameters.Add(new SqlParameter("@hocky", x.HocKy));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }
        public static bool SLSV1LopKhiCapNhatLop(string malop, int slsv1lop)
        {
            var cm = CreateCommand();
            cm.CommandText = @"update CHUYENDEDUOCMO set SOSVTOIDA = @sosvtoida where MALOP = @malop";
            cm.Parameters.Add(new SqlParameter("@sosvtoida", slsv1lop));
            cm.Parameters.Add(new SqlParameter("@malop", malop));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }
        public static bool ThemNhomTheoLopKhiCapNhat(string tenlop, string manhom, int sosvtoida1nhom)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into NHOM(MALOP,MANHOM,SOSVDADKNHOM,SOSVTOIDANHOM) values(@malop,@manhom,0,@sosvtoidanhom)";
            cm.Parameters.Add(new SqlParameter("@malop", tenlop));
            cm.Parameters.Add(new SqlParameter("@manhom", manhom));
            cm.Parameters.Add(new SqlParameter("@sosvtoidanhom", sosvtoida1nhom));
            int rs = cm.ExecuteNonQuery();
            return rs > 0;
        }
        public static bool ThemLopKhiCapNhat(ChuyenDeDuocMo x, string tenlop, int sontoida, int sosvtoida)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into CHUYENDEDUOCMO(MALOP,MACD,NAMHOC,HOCKY,SONTOIDA,SOSVTOIDA,MODKHP,DONGDKHP,TRANGTHAI) values(@malop,@macd,@namhoc,@hocky,@sontoida,@sosvtoida,@modkhp,@dongdkhp,@trangthai)";
            cm.Parameters.Add(new SqlParameter("@malop", tenlop));
            cm.Parameters.Add(new SqlParameter("@macd", x.MaCD));
            cm.Parameters.Add(new SqlParameter("@namhoc", x.NamHoc));
            cm.Parameters.Add(new SqlParameter("@hocky", x.HocKy));
            cm.Parameters.Add(new SqlParameter("@sontoida", sontoida));
            cm.Parameters.Add(new SqlParameter("@sosvtoida", sosvtoida));
            cm.Parameters.Add(new SqlParameter("@modkhp", "1900-01-01"));
            cm.Parameters.Add(new SqlParameter("@dongdkhp", "1900-01-01"));
            cm.Parameters.Add(new SqlParameter("@trangthai", "mở"));
            int rs = cm.ExecuteNonQuery();
            return rs > 0;
        }

        public static bool XoaLop(ChuyenDeDuocMo x, string malop)
        {
            var cm1 = CreateCommand();
            cm1.CommandText = @"delete from NHOM where MALOP = @malop";
            cm1.Parameters.Add(new SqlParameter("@malop", malop));
            int rs1 = cm1.ExecuteNonQuery();

            var cm = CreateCommand();
            cm.CommandText = @"delete from CHUYENDEDUOCMO where MACD = @macd and MALOP = @malop and @namhoc = @namhoc and HOCKY = @hocky";
            cm.Parameters.Add(new SqlParameter("@macd", x.MaCD));
            cm.Parameters.Add(new SqlParameter("@malop", malop));
            cm.Parameters.Add(new SqlParameter("@namhoc", x.NamHoc));
            cm.Parameters.Add(new SqlParameter("@hocky", x.HocKy));
            int rs = cm.ExecuteNonQuery();

            cn.Close();
            return rs + rs1 > 0;
        }
        public static bool XoaNhomCapNhat(string x, string tennhom)
        {
            var cm = CreateCommand();
            cm.CommandText = @"delete from NHOM where MALOP = @malop and MANHOM = @manhom";
            cm.Parameters.Add(new SqlParameter("@malop", x));
            cm.Parameters.Add(new SqlParameter("@manhom", tennhom));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;

        }
        public static bool SLSVNhomCapNhat(string x, string tennhom, int slsv)
        {
            var cm = CreateCommand();
            cm.CommandText = @"update NHOM set SOSVTOIDANHOM = @sosv where MALOP = @malop and MANHOM = @manhom";
            cm.Parameters.Add(new SqlParameter("@sosv", slsv));
            cm.Parameters.Add(new SqlParameter("@malop", x));
            cm.Parameters.Add(new SqlParameter("@manhom", tennhom));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;

        }
        public static bool ThemNhomCapNhat(string x, string tennhom, int sosvtoida1nhom)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into NHOM(MALOP,MANHOM,SOSVDADKNHOM,SOSVTOIDANHOM) values(@malop,@manhom,0,@sosvtoida1nhom)";
            cm.Parameters.Add(new SqlParameter("@malop", x));
            cm.Parameters.Add(new SqlParameter("@manhom", tennhom));
            cm.Parameters.Add(new SqlParameter("@sosvtoida1nhom", sosvtoida1nhom));
            int rs = cm.ExecuteNonQuery();
            cn.Close();
            return rs > 0;
        }

        
        public static bool CapNhatThongTinNguoiDung(GiaoVien gv) //string mand,string ctk,string email,string chucvu,DateTime nbdct
        {
            try
            {
                var cm = CreateCommand();
                //cm.CommandType = System.Data.CommandType.Text;
                //cn.Open();
                cm.CommandText = @"Update GIAOVIEN set TENGV = @ten,CHUCVU = @cv, MAIL = @m, NGAYBDCT = @nbd where MAND = @ma";
                cm.Parameters.Add(new SqlParameter("@ten", gv.TenGV));
                cm.Parameters.Add(new SqlParameter("@cv", gv.ChucVu));
                cm.Parameters.Add(new SqlParameter("@m", gv.Mail));
                cm.Parameters.Add(new SqlParameter("@nbd", gv.NgayBDCT));
                cm.Parameters.Add(new SqlParameter("@ma", gv.MaND));
                int rs = cm.ExecuteNonQuery();
                cn.Close();
                return rs > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        //public static bool CapNhatThongTinChuyenDeDuocMo(ChuyenDeDuocMo cd, int slsvtd, int sllc, int sllm, string tenbd, int slnc, int slnm, int slsv1nhom)
        //{
        //    try
        //    {
        //        if (sllm - sllc != 0)
        //        {
        //            if (sllm - sllc > 0)
        //            {
        //                for (int i = sllc + 1; i <= sllm; i++)
        //                {
        //                    var insertlop = CreateCommand();
        //                    insertlop.CommandText = @"Insert into ChuyenDeDuocMo values(@malop,@macd,@namhoc,@hocki,@ntd,@svdadkcd,@modkhp,@dongdkhp,@gvphutrach,@tt,@slsv1lop";
        //                    insertlop.Parameters.Add(new SqlParameter("@malop", tenbd + i));
        //                    insertlop.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
        //                    insertlop.Parameters.Add(new SqlParameter("@namhoc", cd.NamHoc));
        //                    insertlop.Parameters.Add(new SqlParameter("@hocki", cd.HocKy));
        //                    insertlop.Parameters.Add(new SqlParameter("@ntd", slnm));
        //                    insertlop.Parameters.Add(new SqlParameter("@svdadkhp", cd.SoSVDaDK));
        //                    insertlop.Parameters.Add(new SqlParameter("@modkhp", cd.MoDkHP));
        //                    insertlop.Parameters.Add(new SqlParameter("@dongdkhp", cd.KtDkHP));
        //                    insertlop.Parameters.Add(new SqlParameter("@gvphutrach", cd.GVPhuTrach));
        //                    insertlop.Parameters.Add(new SqlParameter("@tt", cd.trangthai));
        //                    insertlop.Parameters.Add(new SqlParameter("@slsv1lop", cd.slsv1lop));
        //                    int rsinsertlop = insertlop.ExecuteNonQuery();
        //                    cn.Close();
        //                }
        //            }
        //            else if (sllm - sllc < 0)
        //            {
        //                for (int i = sllc; i > sllm; i--)
        //                {
        //                    var del = CreateCommand();
        //                    //del.CommandText = @""
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var cm = CreateCommand();
        //            cm.CommandText = @"Update ChuyenDeDuocMo set NAMHOC = @namhoc,HOCKI = @hocki, SLSV1LOP = @slsv1lop where MACD = @macd";
        //            cm.Parameters.Add(new SqlParameter("@namhoc", cd.NamHoc));
        //            cm.Parameters.Add(new SqlParameter("@hocki", cd.HocKy));
        //            cm.Parameters.Add(new SqlParameter("@slsv1lop", cd.slsv1lop));
        //            cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
        //            int rs = cm.ExecuteNonQuery();
        //        }


        //        var cm1 = CreateCommand();
        //        cm1.CommandText = @"Update ChuyenDe set SOSVTOIDA1CD = @slsvtd where MACD = @macd";
        //        cm1.Parameters.Add(new SqlParameter("@slsvtd", slsvtd));
        //        cm1.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
        //        int rs1 = cm1.ExecuteNonQuery();


        //        var cm2 = CreateCommand();


        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw ex;
        //    }
        //}

        public static bool CapNhatSLSVTrenSOLUONGSV(string macd,string namhoc,string hocki,int slsv)
        {
            var cm = CreateCommand();
            cm.CommandText = @"insert into SOLUONGSV(MACD,NAMHOC,HOCKY,SOSVTOIDA1CD) values(@macd,@namhoc,@hocki,@slsv)";
            cm.Parameters.Add(new SqlParameter("@macd", macd));
            cm.Parameters.Add(new SqlParameter("@namhoc", namhoc));
            cm.Parameters.Add(new SqlParameter("@hocki", hocki));
            cm.Parameters.Add(new SqlParameter("@slsv", slsv));
            int rs = cm.ExecuteNonQuery();
            return rs > 0;
        }

        public static bool DangKyMoiGVGV(TaiKhoan tk,GiaoVien gv,string loaitk)
        {
            string mk = tk.mk;
            tk.mk = ToMD5(mk).ToString();

            var cmnd = CreateCommand();
            cmnd.CommandText = @"insert into NGUOIDUNG(MAND) values(@mand)";
            cmnd.Parameters.Add(new SqlParameter("@mand", tk.tentk));
            int rsnd = cmnd.ExecuteNonQuery();

            var cmgv = CreateCommand();
            cmgv.CommandText = @"insert into GIAOVIEN(MAND,MANGANH,TENGV,CHUCVU,MAIL,NGAYBDCT) values(@mand,@manganh,@tengv,@chucvu,@mail,@ngaybdct)";
            cmgv.Parameters.Add(new SqlParameter("@mand", gv.MaND));
            cmgv.Parameters.Add(new SqlParameter("@manganh", gv.MaNganh));
            cmgv.Parameters.Add(new SqlParameter("@tengv", gv.TenGV));
            cmgv.Parameters.Add(new SqlParameter("@chucvu", gv.ChucVu));
            cmgv.Parameters.Add(new SqlParameter("@mail", gv.Mail));
            cmgv.Parameters.Add(new SqlParameter("@ngaybdct", gv.NgayBDCT));
            int rsgv = cmgv.ExecuteNonQuery();

            var cmtk = CreateCommand();
            cmtk.CommandText = @"insert into TAIKHOAN(MAND,PASSWORD,LOAITK,TINHTRANGTK) values(@mand,@mk,@loai,@tinhtrang)";
            cmtk.Parameters.Add(new SqlParameter("@mand", tk.tentk));
            cmtk.Parameters.Add(new SqlParameter("@mk", tk.mk));
            cmtk.Parameters.Add(new SqlParameter("@loai", loaitk));
            cmtk.Parameters.Add(new SqlParameter("@tinhtrang", tk.tinhtrang));
            int rstk = cmtk.ExecuteNonQuery();

            cn.Close();
            return rsgv + rsnd + rstk > 0;
        }

        public static bool DangKyMoiSV(TaiKhoan tk,SinhVienDayDu sv)
        {
            string mk = tk.mk;
            tk.mk = ToMD5(mk).ToString();

            var cmnd = CreateCommand();
            cmnd.CommandText = @"insert into NGUOIDUNG(MAND) values(@mand)";
            cmnd.Parameters.Add(new SqlParameter("@mand", tk.tentk));
            int rsnd = cmnd.ExecuteNonQuery();

            var cmsv = CreateCommand();
            cmsv.CommandText = @"insert into SINHVIEN(MAND,MANGANH,HOTEN,PHAI,NGAYSINH,DIACHI,MAIL) values(@mand,@manganh,@tengv,@phai,@ngaysinh,@diachi,@mail)";
            cmsv.Parameters.Add(new SqlParameter("@mand", sv.mand));
            cmsv.Parameters.Add(new SqlParameter("@manganh", sv.manganh));
            cmsv.Parameters.Add(new SqlParameter("@tengv", sv.hoten));
            cmsv.Parameters.Add(new SqlParameter("@phai", sv.phai));
            cmsv.Parameters.Add(new SqlParameter("@ngaysinh", sv.ngaysinh));
            cmsv.Parameters.Add(new SqlParameter("@diachi", sv.diachi));
            cmsv.Parameters.Add(new SqlParameter("@mail", sv.mail));
            int rssv = cmsv.ExecuteNonQuery();

            var cmtk = CreateCommand();
            cmtk.CommandText = @"insert into TAIKHOAN(MAND,PASSWORD,LOAITK,TINHTRANGTK) values(@mand,@mk,@loai,@tinhtrang)";
            cmtk.Parameters.Add(new SqlParameter("@mand", tk.tentk));
            cmtk.Parameters.Add(new SqlParameter("@mk", tk.mk));
            cmtk.Parameters.Add(new SqlParameter("@loai", "sv"));
            cmtk.Parameters.Add(new SqlParameter("@tinhtrang", tk.tinhtrang));
            int rstk = cmtk.ExecuteNonQuery();

            cn.Close();
            return rssv + rsnd + rstk > 0;
        }
        public static bool QuenMK(string tk,string mk)
        {
            string mk1 = Dao_GiaoVu.ToMD5(mk).ToString();
            mk = mk1;
            var cm = CreateCommand();
            cm.CommandText = @"update TAIKHOAN set PASSWORD = @mk where MAND = @mand";
            cm.Parameters.Add(new SqlParameter("@mk", mk));
            cm.Parameters.Add(new SqlParameter("@mand", tk));
            int rs = cm.ExecuteNonQuery();

            return rs > 0;
        }

    }
}



//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using VIEW_DTO.TT_TatCaChuyenDe;
//namespace VIEW_DTO.DaoData
//{
//    public class Dao_GiaoVu
//    {
//        static string cnString;
//        static string nameCS = "HeThongDangKyHocPhan";
//        static SqlConnection cn;
//        static Dao_GiaoVu()
//        {
//            cnString = ConfigurationManager.ConnectionStrings[nameCS].ConnectionString;
//            cn = new SqlConnection(cnString);
//        }
//        static SqlCommand CreateCommand()
//        {
//            if (cn.State == System.Data.ConnectionState.Closed)
//            {
//                cn.Open();
//            }
//            var cm = new SqlCommand();
//            cm.Connection = cn;
//            return cm;
//        }


//        /// <summary>
//        /// Các danh sách cần dùng
//        /// </summary>
//        /// <returns></returns>
//        public static List<ChuyenDeDuocMo> DSChuyenDeDuocMo()
//        {
//            var lqq = new List<ChuyenDeDuocMo>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select distinct MaCD,NamHoc,HocKy,SOSVTOIDA1CD,SONTOIDA1LOP,SOSVDADK1CD,MODKHP,DONGDKHP,GVPHUTRACH from CHUYENDEDUOCMO";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(ChuyenDeDuocMo.ReadChuyenDeDuocMo(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<ChuyenDeDuocMo> DSCacLopChuyenDeDuocMo()
//        {
//            var lqq = new List<ChuyenDeDuocMo>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select MaLop,MaCD,NamHoc,HocKy,SOSVTOIDA1CD,SONTOIDA1LOP,SOSVDADK1CD,MODKHP,DONGDKHP,GVPHUTRACH from CHUYENDEDUOCMO";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(ChuyenDeDuocMo.ReadCacLopChuyenDeDuocMo(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<TatCaChuyenDe> DSTatCaChuyenDe()
//        {
//            var lqq = new List<TatCaChuyenDe>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select MACD,TENCD,TINHTRANG from CHUYENDE";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(TatCaChuyenDe.ReadTatCaChuyenDe(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<GiaoVien> DSGiaoVien()
//        {
//            var lqq = new List<GiaoVien>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select MAND,MANGANH,TENGV,CHUCVU,MAIL,NGAYBDCT from GiaoVien";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(GiaoVien.ReadGiaoVien(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<BaoGom> DSBaoGom()
//        {
//            var lqq = new List<BaoGom>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select MANGANH,MACD from BaoGom";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(BaoGom.ReadBaoGom(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<Nganh> DSNganh()
//        {
//            var lqq = new List<Nganh>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select MANGANH,TENNGANH,TONGSV,SOLUONGCDHT from Nganh";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(Nganh.ReadNganh(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<NamHoc> DSNamHoc()
//        {
//            var lqq = new List<NamHoc>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select distinct NAMHOC from HOCKY";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(NamHoc.ReadNamHoc(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<HocKy> DSHocKy()
//        {
//            var lqq = new List<HocKy>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select distinct HOCKY from HOCKY";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(HocKy.ReadHocKy(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<Nhom> DSNhom()
//        {
//            var lqq = new List<Nhom>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select MALOP,MANHOM,SOSVDADK from NHOM";
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(Nhom.ReadNhom(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        public static List<Nhom> DSNhom(string mal)
//        {
//            var lqq = new List<Nhom>();
//            var cm = CreateCommand();
//            cm.CommandText = @"Select MALOP,MANHOM,SOSVDADK from NHOM where MaLop = @malop1";
//            cm.Parameters.Add(new SqlParameter("@malop1", mal));
//            var reader = cm.ExecuteReader();
//            while (reader.Read())
//            {
//                lqq.Add(Nhom.ReadNhom(reader));
//            }
//            cn.Close();
//            return lqq;
//        }
//        /// <summary>
//        /// Thao tác click
//        /// </summary>
//        /// <param name="cd"></param>
//        /// <param name="baogom"></param>
//        /// <returns></returns>
//        public static bool ThemChuyenDe(TatCaChuyenDe cd, BaoGom baogom)
//        {
//            try
//            {
//                var cm = CreateCommand();
//                cm.CommandText = (@"Insert into ChuyenDe(MaCD,TenCD,TINHTRANG) values(@macd,@tencd,@tinhtrang)");
//                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                cm.Parameters.Add(new SqlParameter("@tencd", cd.TenCD));
//                cm.Parameters.Add(new SqlParameter("@tinhtrang", cd.TinhTrang));
//                int rs1 = cm.ExecuteNonQuery();

//                var bg = CreateCommand();
//                bg.CommandText = (@"Insert into BaoGom(MANGANH,MACD) values(@manganh,@macd)");
//                bg.Parameters.Add(new SqlParameter("@manganh", baogom.MaNganh));
//                bg.Parameters.Add(new SqlParameter("@macd", baogom.MaCD));
//                int rs2 = bg.ExecuteNonQuery();
//                cn.Close();

//                return rs1 + rs2 > 0;
//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw ex;
//            }

//        }
//        public static bool SuaChuyenDe(TatCaChuyenDe cd)
//        {
//            try
//            {
//                var cm = CreateCommand();
//                cm.CommandText = (@"Update ChuyenDe set TenCD=@tencd,TinhTrang=@tinhtrang where MaCD = @macd");
//                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                cm.Parameters.Add(new SqlParameter("@tencd", cd.TenCD));
//                cm.Parameters.Add(new SqlParameter("@tinhtrang", cd.TinhTrang));
//                int rs1 = cm.ExecuteNonQuery();
//                cn.Close();
//                return rs1 > 0;
//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw ex;
//            }
//        }
//        public static bool MoChuyenDe(ChuyenDeDuocMo cd)
//        {
//            try
//            {
//                var cm = CreateCommand();
//                cm.CommandText = @"Insert into ChuyenDeDuocMo values(@malop,@macd,@namhoc,@hocky,@tsv,@tsv1lop,@sosvdadk,@modkhp,@ktdkhp,@gvpt)";
//                cm.Parameters.Add(new SqlParameter("@malop", cd.MaLop));
//                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                cm.Parameters.Add(new SqlParameter("@namhoc", cd.NamHoc));
//                cm.Parameters.Add(new SqlParameter("@hocky", cd.HocKy));
//                cm.Parameters.Add(new SqlParameter("@tsv", cd.SoSVToiDa));
//                cm.Parameters.Add(new SqlParameter("@tsv1lop", cd.SoNToiDa1Lop));
//                cm.Parameters.Add(new SqlParameter("@sosvdadk", cd.SoSVDaDK));
//                cm.Parameters.Add(new SqlParameter("@modkhp", cd.MoDkHP));
//                cm.Parameters.Add(new SqlParameter("@ktdkhp", cd.KtDkHP));
//                cm.Parameters.Add(new SqlParameter("@gvpt", cd.GVPhuTrach));
//                int rs = cm.ExecuteNonQuery();
//                cn.Close();
//                return rs > 0;
//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw ex;
//            }
//        }
//        public static bool MoNhomThuocChuyenDe(Nhom nh)
//        {
//            try
//            {
//                var cm = CreateCommand();
//                cm.CommandText = @"Insert into NHOM values(@malop,@manhom,0)";
//                cm.Parameters.Add(new SqlParameter("@malop", nh.malop));
//                cm.Parameters.Add(new SqlParameter("@manhom", nh.manhom));
//                int rs = cm.ExecuteNonQuery();
//                cn.Close();
//                return rs > 0;
//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw ex;
//            }
//        }
//        public static bool XoaChuyenDe(TatCaChuyenDe cd)
//        {
//            try
//            {
//                var cmN = CreateCommand();
//                cmN.CommandText = @"delete from NHOM where MaLop in (select cddm.MaLop from ChuyenDeDuocMo cddm where cddm.MaCD = @macd)";
//                cmN.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                int rsN = cmN.ExecuteNonQuery();

//                var cm = CreateCommand();
//                cm.CommandText = @"delete from BaoGom where MaCD = @macd";
//                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                int rs = cm.ExecuteNonQuery();

//                var cmKN = CreateCommand();
//                cmKN.CommandText = @"delete from KhaNang where MaCD = @macd";
//                cmKN.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                int rsKN = cmKN.ExecuteNonQuery();

//                var cmDL = CreateCommand();
//                cmDL.CommandText = @"delete from DEADLINEBAITAP where MaLop in (select cddm.MaLop from ChuyenDeDuocMo cddm where cddm.MaCD = @macd)";
//                cmDL.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                int rsDL = cmKN.ExecuteNonQuery();

//                var cmCDDM = CreateCommand();
//                cmCDDM.CommandText = @"delete from ChuyenDeDuocMo where MaCD =  @macd";
//                cmCDDM.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                int rsCDDM = cmCDDM.ExecuteNonQuery();

//                var cmcd = CreateCommand();
//                cmcd.CommandText = @"delete from ChuyenDe where MaCD = @macd";
//                cmcd.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
//                int rscd = cmcd.ExecuteNonQuery();

//                cn.Close();
//                return rs + rsKN + rsDL + rsN + rsCDDM + rscd > 0;

//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw ex;
//            }
//        }
//        public static bool VoHieuHoa(string cd)
//        {
//            try
//            {
//                var cm = CreateCommand();
//                cm.CommandText = @"Update ChuyenDe set TinhTrang = 0 where MaCD = @macd";
//                cm.Parameters.Add(new SqlParameter("@macd", cd));
//                int rs = cm.ExecuteNonQuery();
//                return rs > 0;
//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw ex;
//            }
//        }
//    }
//}
