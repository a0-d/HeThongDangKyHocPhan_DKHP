using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEW_DTO.GiaoVu
{
    public class DangKy
    {
        public string mand;
        public string malop;
        public string manhom;
        public double diem;
        static int i0 = 0, i1 = 1, i2 = 2, i3 = 3;
        public DangKy()
        {
            mand = "no";
            malop = "no";
            manhom = "no";
            diem = 0;
        }
        public static DangKy ReadDangKy(SqlDataReader reader)
        {
            DangKy qq = new DangKy();
            qq.mand = reader.GetString(i0);
            qq.malop = reader.GetString(i1);
            qq.manhom = reader.GetString(i2);
            qq.diem = reader.GetDouble(i3);

            return qq;
        }
    }
}
