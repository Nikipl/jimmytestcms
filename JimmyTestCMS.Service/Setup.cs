using JimmyTestCMS.Common.Configuration;
using JimmyTestCMS.Common.Utils;
using JimmyTestCMS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JimmyTestCMS.Service
{
    public static class Setup
    {
        public static void AddBlogsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opts =>
                            opts.UseSqlServer(configuration.GetConnectionString()));
            services.AddMediatR(typeof(Setup));
            services.AddSingleton<IClock, SystemClock>();
        }
    }
}
