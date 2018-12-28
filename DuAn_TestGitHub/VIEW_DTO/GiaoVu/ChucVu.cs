using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.GiaoVu
{
    public class ChucVu
    {
        public string chucvu;
        public ChucVu()
        {
            chucvu = "no";
        }
        public static ChucVu ReadChucVu(SqlDataReader reader)
        {
            var qq = new ChucVu
            {
                chucvu = reader.GetString(0)
            };
            return qq;
        }
    }
}
