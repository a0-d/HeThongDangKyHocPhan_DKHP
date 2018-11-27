using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEW_USECASE
{
    public class TTGiaoVien
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
        public DataTable LopCombobox(string macd)
        {


            SqlConnection sqlConnection = Provider.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "proc_10 '" + macd + "'";
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
            sqlCommand.CommandText = "proc_11 '" + malop + "'";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            Provider.CloseConnection(sqlConnection);

            return dataTable;
        }
        public int GetMaxOrderIDDEAD()
        {
            SqlConnection sql = Provider.ConnectDatabase();
            int temp = -1;

            using (SqlCommand cmd = new SqlCommand("Select MAX(madead) from DEADLINEBAITAP", sql))
            {
                cmd.ExecuteNonQuery();
                temp = (int)cmd.ExecuteScalar();
            }

            return temp;

        }
        public void InsertDead(string malop, int madead, string tendead, DateTime hanThemdead)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_24 @malop, @madead, @tendead, @thoihan";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@malop", malop));
            cm.Parameters.Add(new SqlParameter("@madead", Convert.ToString(madead)));
            cm.Parameters.Add(new SqlParameter("@tendead", tendead));
            cm.Parameters.Add(new SqlParameter("@thoihan", hanThemdead));


            cm.ExecuteNonQuery();
        }
        public void UpdateDead(int madead, string tendead, DateTime hanThemdead)
        {
            SqlConnection sql = Provider.ConnectDatabase();
            string strSQL = "proc_25 @madead, @tendead, @thoihan";
            SqlCommand cm = new SqlCommand(strSQL, sql);
            cm.Parameters.Add(new SqlParameter("@madead", Convert.ToString(madead)));
            cm.Parameters.Add(new SqlParameter("@tendead", tendead));
            cm.Parameters.Add(new SqlParameter("@thoihan", hanThemdead));


            cm.ExecuteNonQuery();
        }
    }
}
