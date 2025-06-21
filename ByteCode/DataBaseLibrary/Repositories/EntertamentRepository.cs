using Dapper;
using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using System.Data;
using static Dapper.SqlMapper;

namespace DataBaseLibrary.Repositrories
{
    public class EntertamentRepository(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _connection = factory.CreateConnection();

        public IEnumerable<Entertament> GetAllHotels()
            => _connection.Query<Entertament>(@"SELECT * FROM Entertament WHERE EntertamentTypeId = (SELECT EntertamentTypeId FROM EntertamentType WHERE EntertamentTypeName = 'Отель')");
    }
}
