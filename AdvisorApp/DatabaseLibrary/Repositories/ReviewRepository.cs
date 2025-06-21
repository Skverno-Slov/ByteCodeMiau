using Dapper;
using DatabaseLibrary.Database;
using DatabaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Repositories
{
    public class ReviewRepository(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Review> GetAll()
            => _db.Query<Review>("SELECT * FROM Review");
        public Review? GetById(int id)
            => _db.QueryFirstOrDefault<Review>("SELECT * FROM Review WHERE Review=@id", new { id });
        public void Create(Review review)
            => _db.Execute(@"INSERT INTO Review (EntertamentId, UserId, ReviewText, PublicationDate, Rating) 
                            VALUES (@EntertamentId, @UserId, @ReviewText, @PublicationDate, @Rating);", review);
        public void Update(Review review)
            => _db.Execute("UPDATE Review SET EntertamentId=@EntertamentId, UserId=@UserId, ReviewText=@ReviewText, PublicationDate=@PublicationDate, Rating=@Rating WHERE Review=@ReviewId", review);
        public void Delete(int id)
            => _db.Execute("DELETE FROM Review WHERE Review=@id", new { id });
    }
}