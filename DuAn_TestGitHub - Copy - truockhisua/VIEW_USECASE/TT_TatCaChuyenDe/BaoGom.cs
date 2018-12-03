using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_USECASE.TT_TatCaChuyenDe
{
    public class BaoGom
    {
        public string MaCD;
        public string MaNganh;
        static int i0 = 0, i1 = 1;
        public BaoGom()
        {
            MaCD = "";
            MaNganh = "";
        }
        public static BaoGom ReadBaoGom(SqlDataReader reader)
        {
            var qq = new BaoGom()
            {
                MaNganh = reader.GetString(i0),
                MaCD = reader.GetString(i1)
            };
            return qq;
        }
    }
}
