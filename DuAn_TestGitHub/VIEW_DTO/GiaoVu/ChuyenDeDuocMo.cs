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
        public int SoSVToiDa;
        public int SoSVToiDa1Lop;
        public int SoSVDaDK;
        public DateTime MoDkHP;
        public DateTime KtDkHP;
        public string GVPhuTrach;
        static int i0 = 0, i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5, i6 = 6, i7 = 7, i8 = 8, i9 = 9;
        public ChuyenDeDuocMo()
        {
            MaLop = "no";
            MaCD = "no";
            NamHoc = "no";
            HocKy = 0;
            SoSVToiDa = 0;
            SoSVToiDa1Lop = 0;
            SoSVDaDK = 0;
            MoDkHP = DateTime.Parse("01/01/1990");
            KtDkHP = DateTime.Parse("02/01/1990");
            GVPhuTrach = "no";
        }
        public static ChuyenDeDuocMo ReadChuyenDeDuocMo(SqlDataReader reader)
        {
            var qq = new ChuyenDeDuocMo()
            {
                MaCD = reader.GetString(i0),
                NamHoc = reader.GetString(i1),
                HocKy = reader.GetInt32(i2),
                SoSVToiDa = reader.GetInt32(i3),
                SoSVToiDa1Lop = reader.GetInt32(i4),
                SoSVDaDK = reader.GetInt32(i5),
                MoDkHP = reader.GetDateTime(i6),
                KtDkHP = reader.GetDateTime(i7),
                GVPhuTrach = reader.GetString(i8)
            };
            return qq;
        }
        public static ChuyenDeDuocMo ReadCacLopChuyenDeDuocMo(SqlDataReader reader)
        {
            var qq = new ChuyenDeDuocMo()
            {
                MaLop = reader.GetString(0),
                MaCD = reader.GetString(i1),
                NamHoc = reader.GetString(i2),
                HocKy = reader.GetInt32(i3),
                SoSVToiDa = reader.GetInt32(i4),
                SoSVToiDa1Lop = reader.GetInt32(i5),
                SoSVDaDK = reader.GetInt32(i6),
                MoDkHP = reader.GetDateTime(i7),
                KtDkHP = reader.GetDateTime(i8),
                GVPhuTrach = reader.GetString(i9)
            };
            return qq;
        }
    }
}
