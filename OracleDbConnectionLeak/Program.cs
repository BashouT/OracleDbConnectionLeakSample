using Microsoft.Extensions.DependencyInjection;
using OracleDbConnectionLeak.Db;
using OracleDbConnectionLeak.Repos;
using System;
using System.Threading;
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



            await RunTestMethodAsync(serviceProvider);
            await RunTestMethodAsync(serviceProvider);
            await RunTestMethodAsync(serviceProvider);
            await RunTestMethodAsync(serviceProvider);

            Thread.Sleep(500);
            Console.ReadLine();
        }

        private static async Task RunTestMethodAsync(ServiceProvider sp)
        {
            var sut = sp.GetService<IRepository>();
            _ = await sut.PerformQuery();
        }
    }
}
