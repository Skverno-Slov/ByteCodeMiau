using Dapper;
using DatabaseLibrary.Database;
using DatabaseLibrary.Models;
using System.Data;

namespace DatabaseLibrary.Repositories
{
    public class GamesRepository(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Game> GetAll() 
            => _db.Query<Game>("SELECT * FROM Game");
        public Game? GetById(int id) 
            => _db.QueryFirstOrDefault<Game>("SELECT * FROM Game WHERE Id=@id", new { id });
        public void Create(Game game)
            => _db.Execute(@"INSERT INTO Game (Title, Price, PublicationYear, Description) 
                            VALUES (@Title, @Price, @PublicationYear, @Description);", game);
        public void Update(Game game) 
            => _db.Execute("UPDATE Game SET Title=@Title, Price=@Price, PublicationYear=@PublicationYear, Description=@Description WHERE Id=@Id", game);
        public void Delete(int id)
            => _db.Execute("DELETE FROM Game WHERE Id=@id", new { id });
    }
}
