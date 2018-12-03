using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIEW_USECASE.TT_TatCaChuyenDe;

namespace VIEW_USECASE.DaoData
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


        /// <summary>
        /// Các danh sách cần dùng
        /// </summary>
        /// <returns></returns>
        public static List<ChuyenDeDuocMo> DSChuyenDeDuocMo()
        {
            var lqq = new List<ChuyenDeDuocMo>();
            var cm = CreateCommand();
            cm.CommandText = @"Select distinct MaCD,NamHoc,HocKy,SOSVTOIDA1CD,SONTOIDA1LOP,SOSVDADK1CD,MODKHP,DONGDKHP,GVPHUTRACH from CHUYENDEDUOCMO";
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
            cm.CommandText = @"Select MaLop,MaCD,NamHoc,HocKy,SOSVTOIDA1CD,SONTOIDA1LOP,SOSVDADK1CD,MODKHP,DONGDKHP,GVPHUTRACH from CHUYENDEDUOCMO";
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
        public  static List<NamHoc> DSNamHoc()
        {
            var lqq = new List<NamHoc>();
            var cm = CreateCommand();
            cm.CommandText = @"Select distinct NAMHOC from HOCKY";
            var reader = cm.ExecuteReader();
            while(reader.Read())
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
            while(reader.Read())
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
            cm.CommandText = @"Select MALOP,MANHOM,SOSVDADK from NHOM";
            var reader = cm.ExecuteReader();
            while(reader.Read())
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
        /// <summary>
        /// Thao tác click
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="baogom"></param>
        /// <returns></returns>
        public static bool ThemChuyenDe(TatCaChuyenDe cd,BaoGom baogom)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = (@"Insert into ChuyenDe(MaCD,TenCD,TINHTRANG) values(@macd,@tencd,@tinhtrang)");
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
            catch(Exception ex)
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
                return rs1>0;
            }
            catch(Exception ex)
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
                cm.CommandText = @"Insert into ChuyenDeDuocMo values(@malop,@macd,@namhoc,@hocky,@tsv,@tsv1lop,@sosvdadk,@modkhp,@ktdkhp,@gvpt)";
                cm.Parameters.Add(new SqlParameter("@malop", cd.MaLop));
                cm.Parameters.Add(new SqlParameter("@macd", cd.MaCD));
                cm.Parameters.Add(new SqlParameter("@namhoc", cd.NamHoc));
                cm.Parameters.Add(new SqlParameter("@hocky", cd.HocKy));
                cm.Parameters.Add(new SqlParameter("@tsv", cd.SoSVToiDa));
                cm.Parameters.Add(new SqlParameter("@tsv1lop", cd.SoSVToiDa1Lop));
                cm.Parameters.Add(new SqlParameter("@sosvdadk", cd.SoSVDaDK));
                cm.Parameters.Add(new SqlParameter("@modkhp", cd.MoDkHP));
                cm.Parameters.Add(new SqlParameter("@ktdkhp", cd.KtDkHP));
                cm.Parameters.Add(new SqlParameter("@gvpt", cd.GVPhuTrach));
                int rs = cm.ExecuteNonQuery();
                cn.Close();
                return rs > 0;
            }
            catch(Exception ex)
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
                cm.CommandText = @"Insert into NHOM values(@malop,@manhom,0)";
                cm.Parameters.Add(new SqlParameter("@malop", nh.malop));
                cm.Parameters.Add(new SqlParameter("@manhom", nh.manhom));
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
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public static bool VoHieuHoa(string cd)
        {
            try
            {
                var cm = CreateCommand();
                cm.CommandText = @"Update ChuyenDe set TinhTrang = 0 where MaCD = @macd";
                cm.Parameters.Add(new SqlParameter("@macd", cd));
                int rs = cm.ExecuteNonQuery();
                return rs > 0;
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
