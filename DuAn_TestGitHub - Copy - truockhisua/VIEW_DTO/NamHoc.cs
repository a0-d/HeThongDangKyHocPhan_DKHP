using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_USECASE.TT_TatCaChuyenDe
{
    public class NamHoc
    {
        public string namhoc;
        static int i0 = 0;
        public NamHoc()
        {
            namhoc = "";
        }
        public static NamHoc ReadNamHoc(SqlDataReader reader)
        {
            var qq = new NamHoc
            {
                namhoc = reader.GetString(i0)
            };
            return qq;
        }
    }
}
