using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.GiaoVu
{
    public class KhanNang
    {
        public string mand;
        public string macd;
        static int i0 = 0, i1 = 1;
        public KhanNang()
        {
            mand = "no";
            macd = "no";
        }
        public static KhanNang ReadKhaNang(SqlDataReader reader)
        {
            var qq = new KhanNang
            {
                mand = reader.GetString(i0),
                macd = reader.GetString(i1)
            };
            return qq;
        }
    }
}
