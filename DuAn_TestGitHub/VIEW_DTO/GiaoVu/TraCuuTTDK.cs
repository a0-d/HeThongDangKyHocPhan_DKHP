using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_DTO.GiaoVu
{
    public class TraCuuTTDK
    {
        public string macd;
        public string malop;
        public string masv;
        public string manhom;
        public float Diem;
        public TraCuuTTDK()
        {
            macd = "";
            malop = "";
            masv = "";
            manhom = "";
            Diem = 0;
        }
    }
}
