using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.TT_TatCaChuyenDe
{
    public class HocKy
    {
        public int hocky;
        static int i0 = 0;
        public HocKy()
        {
            hocky = 0;
        }
        public static HocKy ReadHocKy(SqlDataReader reader)
        {
            var qq = new HocKy
            {
                hocky = reader.GetInt32(i0)
            };
            return qq;
        }
    }
}
