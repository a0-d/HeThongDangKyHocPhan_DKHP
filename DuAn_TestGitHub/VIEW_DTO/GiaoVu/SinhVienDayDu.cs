using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.GiaoVu
{
    public class SinhVienDayDu
    {
        public string mand;
        public string hoten;
        public DateTime ngaysinh;
        public string manganh;
        public string phai;
        public string diachi;
        public string mail;
        public SinhVienDayDu()
        {
            mand = "no";
            hoten = "no";
            ngaysinh = new DateTime(1900, 01, 01);
            manganh = "no";
            phai = "no";
            diachi = "no";
            mail = "no";
        }
        public static SinhVienDayDu ReadSinhVienDayDu(SqlDataReader reader)
        {
            var qq = new SinhVienDayDu
            {
                mand = reader.GetString(0),
                hoten = reader.GetString(1),
                ngaysinh = reader.GetDateTime(2),
                manganh = reader.GetString(3),
                phai = reader.GetString(4),
                diachi = reader.GetString(5),
                mail = reader.GetString(6)
            };
            return qq;
        }
    }
}