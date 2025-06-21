using Dapper;
using DatabaseLibrary.Database;
using DatabaseLibrary.Models;
using System.Data;

namespace DatabaseLibrary.Repositories
{
    public class EntertamentTypeRepository(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<EntertamentType> GetAll()
            => _db.Query<EntertamentType>("SELECT * FROM EntertamentType");
        public EntertamentType? GetById(int id)
            => _db.QueryFirstOrDefault<EntertamentType>("SELECT * FROM EntertamentType WHERE EntertamentTypeId=@id", new { id });
        public void Create(EntertamentType entertamentType)
            => _db.Execute(@"INSERT INTO EntertamentType
                            (EntertamentTypeName)
                            VALUES(@EntertamentTypeName)", entertamentType);
        public void Update(EntertamentType entertamentType)
            => _db.Execute("UPDATE EntertamentType SET EntertamentTypeName=@EntertamentTypeName WHERE EntertamentTypeId=@EntertamentTypeId", entertamentType);
        public void Delete(int id)
            => _db.Execute("DELETE FROM EntertamentType WHERE EntertamentTypeId=@id", new { id });
    }
}
