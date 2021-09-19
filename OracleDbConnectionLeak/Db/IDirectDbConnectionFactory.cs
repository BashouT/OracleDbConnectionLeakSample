using System;
using System.Collections.Generic;
using System.Text;

namespace OracleDbConnectionLeak.Db
{
    public interface IDirectDbConnectionFactory
    {
        ICustomDbConnection GetInstance();
    }
}
