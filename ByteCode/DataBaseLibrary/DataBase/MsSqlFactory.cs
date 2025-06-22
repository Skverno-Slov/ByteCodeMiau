using Microsoft.Data.SqlClient;
using System.Data;

namespace DataBaseLibrary.DataBase
{
    public class MsSqlFactory(string connectionString) : IDbConnectionFactory
    {
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
