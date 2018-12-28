using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.GiaoVu
{
    public class SOLUONGSVTHEOCHUYENDEDUOCMO
    {
        public string macd;
        public string namhoc;
        public int hocki;
        public int sosvtoida1cd;
        public SOLUONGSVTHEOCHUYENDEDUOCMO()
        {
            macd = "no";
            namhoc = "no";
            hocki = 0;
            sosvtoida1cd = 0;
        }
        public static  SOLUONGSVTHEOCHUYENDEDUOCMO ReadSLSVTheoCD(SqlDataReader reader)
        {
            var qq = new SOLUONGSVTHEOCHUYENDEDUOCMO
            {
                macd = reader.GetString(0),
                namhoc = reader.GetString(1),
                hocki = reader.GetInt32(2),
                sosvtoida1cd = reader.GetInt32(3)
            };
            return qq;
        }
    }
}
