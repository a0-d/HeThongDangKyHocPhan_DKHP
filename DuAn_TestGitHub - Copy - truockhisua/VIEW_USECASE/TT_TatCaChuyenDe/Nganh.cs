using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_USECASE.TT_TatCaChuyenDe
{
    public class Nganh
    {
        public string manganh;
        public string tennganh;
        public int tongsv;
        public int slcdht;
        static int i0 = 0, i1 = 1, i2 = 2, i3 = 3;
        public Nganh()
        {
            manganh = "";
            tennganh = "";
            tongsv = 0;
            slcdht = 0;
        }
        public static Nganh ReadNganh(SqlDataReader reader)
        {
            var qq = new Nganh
            {
                manganh = reader.GetString(i0),
                tennganh = reader.GetString(i1),
                tongsv = reader.GetInt32(i2),
                slcdht = reader.GetInt32(i3)
            };
            return qq;
        }
    }
}
