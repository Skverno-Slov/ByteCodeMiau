using Dapper;
using DatabaseLibrary.Database;
using DatabaseLibrary.Models;
using System.Data;

namespace DatabaseLibrary.Repositories
{
    public class HotelRepository(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Hotel> GetAll() 
            => _db.Query<Hotel>("SELECT * FROM Hotel");
        public Hotel? GetById(int id) 
            => _db.QueryFirstOrDefault<Hotel>("SELECT * FROM Hotel WHERE HotelId=@id", new { id });
        public void Create(Hotel hotel)
            => _db.Execute(@"INSERT INTO Hotel (HotelName,Description,SiteLink) 
                            VALUES (@HotelName, @Description, @SiteLink);", hotel);
        public void Update(Hotel hotel) 
            => _db.Execute("UPDATE Hotel SET HotelName=@HotelName, Description=@Description, SiteLink=@SiteLink WHERE HotelId=@Id", hotel);
        public void Delete(int id)
            => _db.Execute("DELETE FROM Hotel WHERE HotelId=@id", new { id });
    }
}
