using System;
using System.Threading.Tasks;
using JimmyTestCMS.Common.Configuration;
using JimmyTestCMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JimmyTestCMS.DbUpdater
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: Configuration.ConfigurationPrefix)
                .Build();

            var connectionString = configuration.GetConnectionString();
            if (string.IsNullOrEmpty(connectionString)) {
                Console.WriteLine(
                    $"Provide a connection string in {Configuration.ConfigurationPrefix}{Configuration.ConnectionString} environment variable");
                return;
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString());

            await using var context = new ApplicationContext(optionsBuilder.Options);
            await context.Database.MigrateAsync();
        }
    }
}
