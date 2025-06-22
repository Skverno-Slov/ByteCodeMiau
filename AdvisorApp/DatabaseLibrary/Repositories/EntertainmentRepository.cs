using Dapper;
using DatabaseLibrary.Database;
using DatabaseLibrary.Models;
using System.Data;

namespace DatabaseLibrary.Repositories
{
    public class EntertainmentRepository(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Entertainment> GetAll() 
            => _db.Query<Entertainment>("SELECT * FROM Entertainment");
        public Entertainment? GetById(int id) 
            => _db.QueryFirstOrDefault<Entertainment>("SELECT * FROM Entertainment WHERE EntertainmentId=@id", new { id });
        public void Create(Entertainment hotel)
            => _db.Execute(@"INSERT INTO Entertainment (EntertainmentName, Description, SiteLink, FullAddress, EntertainmentType, Price) 
                            VALUES (@EntertainmentName, @Description, @SiteLink, @FullAddress, @EntertainmentType, @Price);", hotel);
        public void Update(Entertainment hotel) 
            => _db.Execute("UPDATE Hotel SET EntertainmentName=@EntertainmentName, Description=@Description, SiteLink=@SiteLink, FullAddress=@FullAddress, EntertainmentType=@EntertainmentType, Price WHERE HotelId=@Id", hotel);
        public void Delete(int id)
            => _db.Execute("DELETE FROM Entertainment WHERE EntertainmentId=@id", new { id });
    }
}
