using Dapper;
using DatabaseLibrary.Database;
using DatabaseLibrary.Models;
using System.Data;

namespace DatabaseLibrary.Repositories
{
    public class EntertamentRepository(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Entertament> GetAll() 
            => _db.Query<Entertament>("SELECT * FROM Entertament");
        public Entertament? GetById(int id) 
            => _db.QueryFirstOrDefault<Entertament>("SELECT * FROM Entertament WHERE EntertamentId=@id", new { id });
        public void Create(Entertament entertament)
            => _db.Execute(@"INSERT INTO Entertament
(CityId, EntertamentTypeId, TuristTypeId, Address, EntertamentName, Description, SiteLink, Price)
VALUES(@CityId, @EntertamentTypeId, @TuristTypeId, @Address, @EntertamentName, @Description, @SiteLink, @Price);", entertament);
        public void Update(Entertament entertament) 
            => _db.Execute("UPDATE Entertament SET CityId=@CityId, EntertamentTypeId=@EntertamentTypeId, TuristTypeId=@TuristTypeId, Address=@Address, EntertamentName=@EntertamentName, Description=@Description, SiteLink=@SiteLink, Price=@Price WHERE EntertamentId=@EntertamentId", entertament);
        public void Delete(int id)
            => _db.Execute("DELETE FROM Entertament WHERE EntertamentId=@id", new { id });
    }
}
