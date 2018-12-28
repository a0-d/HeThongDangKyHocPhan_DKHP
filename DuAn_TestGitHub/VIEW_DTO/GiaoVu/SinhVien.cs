using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.GiaoVu
{
    public class SinhVien
    {
        public string mand;
        public string hoten;
        public DateTime ngaysinh;
        static int i0 = 0, i2 = 2, i4 = 4;
        public SinhVien()
        {
            mand = "no";
            hoten = "no";
            ngaysinh = new DateTime(1900, 01, 01);
        }
        public static SinhVien ReadSinhVien(SqlDataReader reader)
        {
            var qq = new SinhVien
            {
                mand = reader.GetString(i0),
                hoten = reader.GetString(i2),
                ngaysinh = reader.GetDateTime(i4)
            };
            return qq;
        }
    }
}
