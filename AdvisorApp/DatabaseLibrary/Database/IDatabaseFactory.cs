using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Database
{
    public interface IDatabaseFactory
    {
        IDbConnection CreateConnection();
    }
}
