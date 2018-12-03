using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.TT_TatCaChuyenDe
{
    public class GiaoVien
    {
        public string MaND;
        public string MaNganh;
        public string Mail;
        public string TenGV;
        public string ChucVu;
        public DateTime NgayBDCT;
        static int i0 = 0, i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5;
        public GiaoVien()
        {
            MaND = "";
            MaNganh = "";
            Mail = "";
            TenGV = "";
            ChucVu = "";
            NgayBDCT = new DateTime(1900,01,01);
        }
        public static GiaoVien ReadGiaoVien(SqlDataReader reader)
        {
            var qq = new GiaoVien()
            {
                MaND = reader.GetString(i0),
                MaNganh = reader.GetString(i1),
                TenGV = reader.GetString(i2),
                ChucVu = reader.GetString(i3),
                Mail = reader.GetString(i4),
                NgayBDCT = reader.GetDateTime(i5)
            };
            return qq;
        }
    }
}
