using System.Data.SqlClient;

namespace praktika27.Classes
{
    public class Connection
    {
        private static readonly string config = "server=localhost;DataBase=ShopContent;User Id=sa;Password=12345QWERTY;TrustServerCertificate=True";

        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            return connection;
        }

        public static SqlDataReader Query(string SQL, out SqlConnection connection)
        {
            connection = OpenConnection();
            return new SqlCommand(SQL, connection).ExecuteReader();
        }

        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
            SqlConnection.ClearPool(connection);
        }
    }
}
