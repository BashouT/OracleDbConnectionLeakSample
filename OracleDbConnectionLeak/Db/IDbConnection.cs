using System;
using System.Collections.Generic;
using System.Text;

namespace OracleDbConnectionLeak.Db
{
    public interface ICustomDbConnection : IDisposable
    {
        IEnumerable<T> Query<T>(string query, bool buffered, int commandTimeout);

    }
}
