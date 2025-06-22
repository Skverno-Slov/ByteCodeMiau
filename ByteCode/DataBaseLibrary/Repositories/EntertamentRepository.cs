using Dapper;
using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using System.Data;
using System.Data.Common;

namespace DataBaseLibrary.Repositories
{
    public class EntertamentRepository(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Entertament> GetAll() 
            => _db.Query<Entertament>("SELECT * FROM Entertament");

        public Entertament? GetById(int id) 
            => _db.QueryFirstOrDefault<Entertament>("SELECT * FROM Entertament WHERE EntertamentId=@id", new { id });

        public void Create(Entertament entertament)
            => _db.Execute(@"INSERT INTO Entertament
    (CityId, EntertamentTypeId, TuristTypeId, ImageName, Address, EntertamentName, Description, SiteLink, Latitude, Longitude, Price)
    VALUES(@CityId, @EntertamentTypeId, @TuristTypeId, @ImageName, @Address, @EntertamentName, @Description, @SiteLink, @Latitude, @Longitude, @Price);", entertament);

        public void Update(Entertament entertament) 
            => _db.Execute("UPDATE Entertament SET CityId=@CityId, EntertamentTypeId=@EntertamentTypeId, TuristTypeId=@TuristTypeId, Address=@Address, EntertamentName=@EntertamentName, Description=@Description, SiteLink=@SiteLink, Price=@Price WHERE EntertamentId=@EntertamentId", entertament);

        public void Delete(int id)
            => _db.Execute("DELETE FROM Entertament WHERE EntertamentId=@id", new { id });

        public IEnumerable<Entertament> GetAllHotels()
        => _db.Query<Entertament>(@"SELECT * FROM Entertament WHERE EntertamentTypeId = (SELECT EntertamentTypeId FROM EntertamentType WHERE EntertamentTypeName = 'Отель')");

        public IEnumerable<Entertament> GetAllRestaurants()
        => _db.Query<Entertament>(@"SELECT * FROM Entertament WHERE EntertamentTypeId = (SELECT EntertamentTypeId FROM EntertamentType WHERE EntertamentTypeName = 'Ресторан')");

        public IEnumerable<Entertament> GetAllMonuments()
        => _db.Query<Entertament>(@"SELECT * FROM Entertament WHERE EntertamentTypeId = (SELECT EntertamentTypeId FROM EntertamentType WHERE EntertamentTypeName = 'Памятник')");

        public IEnumerable<Entertament> GetAllEntertaments()
        => _db.Query<Entertament>(@"SELECT * FROM Entertament WHERE EntertamentTypeId = (SELECT EntertamentTypeId FROM EntertamentType WHERE EntertamentTypeName = 'Развлечение')");
        public IEnumerable<Entertament> GetAllRoutes()
        => _db.Query<Entertament>(@"SELECT * FROM Entertament WHERE EntertamentTypeId = (SELECT EntertamentTypeId FROM EntertamentType WHERE EntertamentTypeName = 'Маршрут')");
    }
}