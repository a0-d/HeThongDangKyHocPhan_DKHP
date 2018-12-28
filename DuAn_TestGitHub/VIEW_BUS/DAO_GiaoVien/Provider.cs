using System.Data.SqlClient;

namespace VIEW_BUS.DAO_GiaoVien
{
    public class Provider
    {
        public static string ConnectionString = @"Server=.;Database=HeThongDangKyHocPhan; Trusted_Connection=True;";

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
