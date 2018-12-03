using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIEW_BUS;

namespace VIEW_USECASE
{
    public class TTGiaoVien
    {
        public string mand;
        public int ExcuteNonQuery(CommandType cmdType, string strSql, params SqlParameter[] parameters)
        {
            try
            {
                SqlConnection sqlConnection = Provider.ConnectDatabase();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = strSql;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        //lấy Danh sách

        public DataTable LayDSChuyeDe()
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien01";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }
        public DataTable LayDSChuyeDeDuocMo()
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien02";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }
        
        public DataTable LayDSChuyeDeDangDayCOLOP(string mand)
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien03 '" + mand +"'";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }
        public DataTable LayDSChuyeDeDangDay()
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien04 '" + mand + "' ";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }
        public DataTable LayKetQuaDiem(string mand, string macd)
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien05 '" + mand + "', '" + macd + "'";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }
        public DataTable LayThongTinDangKy(string macd, string nam, int hocki, string mand)
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien06 '" + nam + "', '" + hocki + "', '" + macd + "', '"+ mand + "'";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }
        public DataTable LayThongTinTimKiem(string items)
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien07 '" + items + "%', N'%" + items + "%'";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }

        //Combobox
        public DataTable LopCombobox(string macd)
        {


            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien08 '" + macd + "'";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;
        }
        public DataTable DeadCombobox(string malop)
        {


            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien09 '" + malop + "'";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;
        }
        public DataTable NamCombobox()
        {


            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien10";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;
        }
        public DataTable MaCDDayCombobox()
        {


            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien11";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;
        }
        public DataTable TenCDCombobox()
        {


            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_gvien12";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;
        }

        //Load txt
        public string TenCDtxt(string macd)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            string temp = "";

            using (SqlCommand cmd = new SqlCommand("proc_gvien13 '" + macd + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }
            return temp;

        }
        public string TenNguoiDungtxt(string mand)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            string temp = "";

            using (SqlCommand cmd = new SqlCommand("proc_gvien14 '" + mand + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }
            return temp;

        }
        public string MailNguoiDungtxt(string mand)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            string temp = "";

            using (SqlCommand cmd = new SqlCommand("proc_gvien15 '" + mand + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }
            return temp;

        }
        public string NganhNguoiDungtxt(string mand)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            string temp = "";

            using (SqlCommand cmd = new SqlCommand("proc_gvien16 '" + mand + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }
            return temp;

        }
        public DateTime NgayCTNguoiDungtxt(string mand)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            DateTime temp;

            using (SqlCommand cmd = new SqlCommand("proc_gvien17 '" + mand + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (DateTime)cmd.ExecuteScalar();
            }
            return temp;

        }
        public string TenSinhVien(string masv)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            string temp;

            using (SqlCommand cmd = new SqlCommand("proc_gvien18 '" + masv + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }

            return temp;
        }
        public int SoLuongSinhVien(string macd)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            int temp;

            using (SqlCommand cmd = new SqlCommand("proc_gvien19 '" + macd + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (int)cmd.ExecuteScalar();
            }

            return temp;
        }
        public int SoLuongNhom(string macd)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            int temp;

            using (SqlCommand cmd = new SqlCommand("proc_gvien20 '" + macd + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (int)cmd.ExecuteScalar();
            }

            return temp;
        }
        public int SoLuongLop(string macd)
        {

            SqlConnection sql = Provider.ConnectDatabase();
            int temp;

            using (SqlCommand cmd = new SqlCommand("proc_gvien21 '" + macd + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (int)cmd.ExecuteScalar();
            }

            return temp;
        }
        
        public int GetMaxIDDEAD()
        {
            SqlConnection sql = Provider.ConnectDatabase();
            int temp = -1;

            using (SqlCommand cmd = new SqlCommand("proc_gvien22", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (int)cmd.ExecuteScalar();
            }

            return temp;

        }
        public string LayTenLop(string macd, int solop)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string temp = "";

            using (SqlCommand cmd = new SqlCommand("select MALOP from CHUYENDEDUOCMO where MACD = '"+ macd + "' and MALOP like '%" + solop + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }

            return temp;

        }
        public string LayMatKhau(string mand)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string temp = "";

            using (SqlCommand cmd = new SqlCommand("proc_gvien23 '" + mand+"'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }

            return temp;

        }
        public int CheckKhaNang(string mand, string tencd)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            int temp = 0;

            using (SqlCommand cmd = new SqlCommand("proc_gvien24 '" + mand + "', N'"+ tencd +"'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (int)cmd.ExecuteScalar();
            }

            return temp;

        }
        public string LayTenDead(string madead)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string temp = "";

            using (SqlCommand cmd = new SqlCommand("proc_gvien34 '" + madead + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (string)cmd.ExecuteScalar();
            }

            return temp;

        }
        public DateTime LayThoiHanDead(string madead)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            DateTime temp;

            using (SqlCommand cmd = new SqlCommand("proc_gvien35 '" + madead + "'", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (DateTime)cmd.ExecuteScalar();
            }

            return temp;

        }


        //Insert, Update, Delete

        public void InsertDead(string malop, int madead, string tendead, DateTime hanThemdead)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien25 @malop, @madead, @tendead, @thoihan";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@malop", malop));
            cm.Parameters.Add(new SqlParameter("@madead", Convert.ToString(madead)));
            cm.Parameters.Add(new SqlParameter("@tendead", tendead));
            cm.Parameters.Add(new SqlParameter("@thoihan", hanThemdead));


            cm.ExecuteNonQuery();
        }
        public void InsertLop(string macd, string malop)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien26 @macd, @malop";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@macd", macd));
            cm.Parameters.Add(new SqlParameter("@malop", malop));


            cm.ExecuteNonQuery();
        }

        public void DeleteLop(string macd, string malop)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien27 @malop";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@malop", malop));


            cm.ExecuteNonQuery();
        }
        public void UpdateDead(int madead, string tendead, DateTime hanThemdead)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien28 @madead, @tendead, @thoihan";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@madead", Convert.ToString(madead)));
            cm.Parameters.Add(new SqlParameter("@tendead", tendead));
            cm.Parameters.Add(new SqlParameter("@thoihan", hanThemdead));


            cm.ExecuteNonQuery();
        }
        public void UpdateNhomVsSV(string macd, int sosv, int sonhom)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien29 @macd, @sonhom, @sosv";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@macd", macd));
            cm.Parameters.Add(new SqlParameter("@sosv", sosv));
            cm.Parameters.Add(new SqlParameter("@sonhom", sonhom));


            cm.ExecuteNonQuery();
        }
        public void UpdateThongTinNguoiDung(string mand, string ten, string mail, DateTime ngay)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien30 @mand, @ten, @mail, @ngay";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@mand", mand));
            cm.Parameters.Add(new SqlParameter("@ten", ten));
            cm.Parameters.Add(new SqlParameter("@mail", mail));
            cm.Parameters.Add(new SqlParameter("@ngay", ngay));



            cm.ExecuteNonQuery();
        }
        public void UpdateMatKhau(string mand, string pass, string passcu)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien32 @mand, @pass, @passcu";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@mand", mand));
            cm.Parameters.Add(new SqlParameter("@pass", pass));
            cm.Parameters.Add(new SqlParameter("@passcu", passcu));



            cm.ExecuteNonQuery();
        }
        public void InsertKhaNang(string tencd, string magv)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien33 @tencd, @magv";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@tencd", tencd));
            cm.Parameters.Add(new SqlParameter("@magv", magv));


            cm.ExecuteNonQuery();
        }
        public void DeleteKhaNang(string tencd, string magv)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_gvien36 @tencd, @magv";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@tencd", tencd));
            cm.Parameters.Add(new SqlParameter("@magv", magv));


            cm.ExecuteNonQuery();
        }
    }
}
