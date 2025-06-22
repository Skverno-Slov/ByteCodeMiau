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
    public class RouteRepository(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Route> GetAll()
            => _db.Query<Route>("SELECT * FROM Route");
        public Route? GetById(int id)
            => _db.QueryFirstOrDefault<Route>("SELECT * FROM Route WHERE Id=@id", new { id });
        public void Create(Route route)
            => _db.Execute(@"INSERT INTO Route
                            (RouteId, EntertamentId)
                            VALUES(@RouteId, @EntertamentId)", route);
        public void Update(Route route)
            => _db.Execute("UPDATE Route SET RouteId=@RouteId, EntertamentId=@EntertamentId WHERE Id=@Id", route);
        public void Delete(int id)
            => _db.Execute("DELETE FROM Route WHERE RouteId=@id", new { id });

        public IEnumerable<Route> GetAllEntertamentsInRoute(int id)
        => _db.Query<Route>("SELECT * FROM Route WHERE RouteId=@id", new { id });
    }
}
