using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.TT_TatCaChuyenDe
{
    public class ChuyenDeDuocMo
    {
        public string MaLop;
        public string MaCD;
        public string NamHoc;
        public int HocKy;
        public int SoNToiDa1Lop;
        public int slsv1lop;
        public DateTime MoDkHP;
        public DateTime KtDkHP;
        public string GVPhuTrach;
        public string trangthai;
        static int i0 = 0, i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5, i6 = 6, i7 = 7, i8 = 8, i9 = 9;
        public ChuyenDeDuocMo()
        {
            MaLop = "no";
            MaCD = "no";
            NamHoc = "no";
            HocKy = 0;
            SoNToiDa1Lop = 0;
            slsv1lop = 0;
            MoDkHP = DateTime.Parse("01/01/1990");
            KtDkHP = DateTime.Parse("02/01/1990");
            GVPhuTrach = "no";
            trangthai = "no";
        }
        public static ChuyenDeDuocMo ReadChuyenDeDuocMo(SqlDataReader reader)
        {
            var qq = new ChuyenDeDuocMo()
            {
                MaCD = reader.GetString(i0),
                NamHoc = reader.GetString(i1),
                HocKy = reader.GetInt32(i2),
                SoNToiDa1Lop = reader.GetInt32(i3),
                slsv1lop = reader.GetInt32(i4),
                MoDkHP = reader.GetDateTime(i5),
                KtDkHP = reader.GetDateTime(i6),
                trangthai = reader.GetString(i7),

            };
            return qq;
        }
        public static ChuyenDeDuocMo ReadCacLopChuyenDeDuocMo(SqlDataReader reader)
        {
            var qq = new ChuyenDeDuocMo()
            {
                MaLop = reader.GetString(i0),
                MaCD = reader.GetString(i1),
                NamHoc = reader.GetString(i2),
                HocKy = reader.GetInt32(i3),
                SoNToiDa1Lop = reader.GetInt32(i4),
                slsv1lop = reader.GetInt32(i5),
                MoDkHP = reader.GetDateTime(i6),
                KtDkHP = reader.GetDateTime(i7),
                GVPhuTrach = reader.GetString(i8),
                trangthai = reader.GetString(i9)
            };
            return qq;
        }
    }
}
