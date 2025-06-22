using System.Data;
namespace DataBaseLibrary.DataBase

{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
