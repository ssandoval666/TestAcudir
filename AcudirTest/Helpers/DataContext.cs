using Microsoft.EntityFrameworkCore;
using AcudirTes2.Models;

namespace AcudirTes2.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<People> People { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
        
    }
}
