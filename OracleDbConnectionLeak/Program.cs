using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using OracleDbConnectionLeak.Db;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using OracleDbConnectionLeak.Repos;
using System.Threading.Tasks;

namespace OracleDbConnectionLeak
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<IRepository, Repository>()
            .AddScoped<IDirectDbConnectionFactory, DirectDbConnectionFactory>()
            .BuildServiceProvider();

            //do the actual work here
            var sut = serviceProvider.GetService<IRepository>();


            _ = await sut.PerformQuery();
            _ = await sut.PerformQuery();
            _ = await sut.PerformQuery();
            _ = await sut.PerformQuery();

            Thread.Sleep(500);
            Console.ReadLine();
        }
    }
}
