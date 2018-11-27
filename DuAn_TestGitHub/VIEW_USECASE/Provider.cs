using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_USECASE
{
    public class Provider
    {
        public static string ConnectionString = @"Server=DESKTOP-CCFAEH9;Database=DangKyHocPhan; User Id =sa; Password=123;";
        public SqlConnection Connection { get; set; }
        
        public static SqlConnection ConnectDatabase()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public static void CloseConnection(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
    }
    public class TT
    {
        public DataTable LayDSChuyeDeDuocMo()
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
        public DataTable LopCombobox()
        {

            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_10_temp";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;
        }
    }
}
