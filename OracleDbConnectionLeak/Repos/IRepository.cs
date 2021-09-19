using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static OracleDbConnectionLeak.Repos.Repository;

namespace OracleDbConnectionLeak.Repos
{
    public interface IRepository
    {
        Task<List<TypeToReturn>> PerformQuery();
    }
}
