using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JimmyTestCMS.Data
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            if (!args.Any()) {
                throw new ArgumentException("Pass a connection string");
            }

            var connectionString = args.First();
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseSqlServer(connectionString);
            return new ApplicationContext(builder.Options);
        }
    }
}
