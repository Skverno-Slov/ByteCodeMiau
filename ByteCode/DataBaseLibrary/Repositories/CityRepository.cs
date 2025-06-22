using Dapper;
using DataBaseLibrary.DataBase;
using DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.Repositories
{
    public class CityRepository(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<City> GetAll()
            => _db.Query<City>("SELECT * FROM City");
        public City? GetById(int id)
            => _db.QueryFirstOrDefault<City>("SELECT * FROM City WHERE CityId=@id", new { id });
        public void Create(City city)
            => _db.Execute(@"INSERT INTO City
                            (CityName)
                            VALUES(@CityName)", city);
        public void Update(City  city)
            => _db.Execute("UPDATE City SET CityName=@CityName WHERE CityId=@CityId", city);
        public void Delete(int id)
            => _db.Execute("DELETE FROM City WHERE CityId=@id", new { id });
    }
}
