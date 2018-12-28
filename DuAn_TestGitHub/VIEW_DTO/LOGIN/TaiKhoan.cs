using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.LOGIN
{
    public class TaiKhoan
    {
        public string tentk;
        public string mk;
        public string tinhtrang;
        static int i0 = 0, i1 = 1, i2 = 2;

        public TaiKhoan()
        {
            tentk = "no";
            mk = "no";
            tinhtrang = "no";
        }
        public static TaiKhoan ReadTaiKhoan(SqlDataReader reader)
        {
            var qq = new TaiKhoan
            {
                tentk = reader.GetString(i0),
                mk = reader.GetString(i1),
                tinhtrang = reader.GetString(i2)
            };
            return qq;
        }

    }
}
