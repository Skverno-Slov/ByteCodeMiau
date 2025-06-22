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
    public class UserRepository(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<User> GetAll()
            => _db.Query<User>("SELECT * FROM \"User\"");
        public User? GetById(int id)
            => _db.QueryFirstOrDefault<User>("SELECT * FROM User WHERE UserId=@id", new { id });
        public void Create(User user)
            => _db.Execute(@"INSERT INTO ""User""
                            (TuristTypeId, FirstName, LastName, Email, Password)
                            VALUES(@TuristTypeId, @FirstName, @LastName, @Email, @Password)", user);
        public void Update(User user)
            => _db.Execute("UPDATE \"User\" SET TuristTypeId=@TuristTypeId, FirstName=@FirstName, LastName=@LastName, Password=@Password WHERE UserId=@UserId", user);
        public void Delete(int id)
            => _db.Execute("DELETE FROM \"User\"  WHERE UserId =@id", new { id });
    }
}
