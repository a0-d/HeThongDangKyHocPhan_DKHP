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
        public static string ConnectionString = @"Server=.;Database=DangKyHocPhan; Trusted_Connection=True;";

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
}
