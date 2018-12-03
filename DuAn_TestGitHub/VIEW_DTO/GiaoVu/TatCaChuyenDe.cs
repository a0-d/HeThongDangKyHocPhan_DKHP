using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.TT_TatCaChuyenDe
{
    public class TatCaChuyenDe
    {
        public string MaCD;
        public string TenCD;
        public int TinhTrang;
        static int i0 = 0, i1 = 1, i2 = 2;
        public TatCaChuyenDe()
        {
            MaCD = "";
            TenCD = "";
            TinhTrang = 0;
        }
        public static TatCaChuyenDe ReadTatCaChuyenDe(SqlDataReader reader)
        {
            var qq = new TatCaChuyenDe()
            {
               MaCD = reader.GetString(i0),
               TenCD = reader.GetString(i1),
               TinhTrang = reader.GetInt32(i2)
            };
            return qq;
        }
    }
}
