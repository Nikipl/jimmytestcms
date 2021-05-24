using Microsoft.Extensions.Configuration;

namespace JimmyTestCMS.Common.Configuration
{
    public static class Configuration
    {
        public const string ConfigurationPrefix = "Blogs_";
        public const string ConnectionString = nameof(ConnectionString);

        public static string GetConnectionString(this IConfiguration configuration)
        {
            return configuration[ConnectionString];
        }
    }
}
