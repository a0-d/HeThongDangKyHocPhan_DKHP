using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_USECASE
{
    public class TTGiaoVu
    {
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
        public DataTable LayDSLopChuyeDeDuocMo()
        {
            //Tạo kết nối
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "Select * from CHUYENDEDUOCMO";
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
            sqlCommand.CommandText = "Select distinct MaCD as N'Mã chuyên đề',NamHoc as N'Năm học',HocKy,SOSVTOIDA1CD,SONTOIDA1LOP,SOSVDADK1CD,MODKHP,DONGDKHP,GVPHUTRACH from CHUYENDEDUOCMO";
            sqlCommand.CommandType = CommandType.Text;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;

        }
        public DataTable LayDSTatCaChuyenDe()
        {
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = @"select * from CHUYENDE";

            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);

            Provider.CloseConnection(sqlConnection);

            return dt;
        }
        public DataTable DSChuyenDeThuocNganh()
        {
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = @"proc_28";

            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);

            Provider.CloseConnection(sqlConnection);

            return dt;
        }
        public DataTable DSNamHoc()
        {
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = @"proc_04";

            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);

            Provider.CloseConnection(sqlConnection);

            return dt;
        }
        public DataTable DSHocKy()
        {
            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = @"proc_29";

            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);

            Provider.CloseConnection(sqlConnection);

            return dt;
        }
    }
}
