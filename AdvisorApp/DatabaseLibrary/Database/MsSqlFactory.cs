using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseLibrary.Database
{
    public class MsSqlFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
