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
    public class TuristTypeRepostitory(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<TuristType> GetAll()
            => _db.Query<TuristType>("SELECT * FROM TuristType");
        public TuristType? GetById(int id)
            => _db.QueryFirstOrDefault<TuristType>("SELECT * FROM TuristType WHERE TuristTypeId=@id", new { id });
        public void Create(TuristType turistType)
            => _db.Execute(@"INSERT INTO TuristType
                            (TuristTypeName)
                            VALUES(@TuristTypeName)", turistType);
        public void Update(TuristType turistType)
            => _db.Execute("UPDATE TuristType SET TuristTypeName=@TuristTypeName WHERE TuristTypeId=@TuristTypeId", turistType);
        public void Delete(int id)
            => _db.Execute("DELETE FROM TuristType WHERE TuristTypeId=@id", new { id });
    }
}
