using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.TT_TatCaChuyenDe
{
    public class Nhom
    {
        public string malop;
        public string manhom;
        public int sosvddk;
        public int sosvtoida1nhom;
        static int i0 = 0, i1 = 1, i2 = 2, i3 = 3;
        public Nhom()
        {
            malop = "";
            manhom = "";
            sosvddk = 0;
            sosvtoida1nhom = 0;
        }
        public static Nhom ReadNhom(SqlDataReader reader)
        {
            var qq = new Nhom
            {
                malop = reader.GetString(i0),
                manhom = reader.GetString(i1),
                sosvddk = reader.GetInt32(i2),
                sosvtoida1nhom = reader.GetInt32(i3)
            };
            return qq;
        }
    }
}
