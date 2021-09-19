using OracleDbConnectionLeak.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDbConnectionLeak.Repos
{
    public class Repository : IRepository
    {
        private readonly IDirectDbConnectionFactory _connectionFactory;

        public Repository(
            IDirectDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<TypeToReturn>> PerformQuery()
        {
            using var connection = _connectionFactory.GetInstance();
            List<TypeToReturn> result = null;

            string query = "";

            var dbResult = connection.Query<Dto>(query, buffered: true, commandTimeout: 60)
                .ToList();

            result = MapDbResult(dbResult);

            return new List<TypeToReturn>(result);
        }

        private List<TypeToReturn> MapDbResult(List<Dto> dbResult)
        {
            return dbResult.Select(x => new TypeToReturn
            {

            })
            .ToList();
        }

        public class TypeToReturn
        {

        }

        private class Dto
        {

        }
    }
}
