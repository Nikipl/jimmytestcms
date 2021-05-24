using Microsoft.EntityFrameworkCore;

namespace JimmyTestCMS.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
