using Microsoft.EntityFrameworkCore;
namespace carpark_info_assignment
{

    public class CarparkDbContext : DbContext
    {

        public DbSet<CarparkInfo> CarparkInfo => Set<CarparkInfo>();
        private readonly IConfiguration config;

        public CarparkDbContext(IConfiguration _config)
        {            
            config = _config;
            Database.EnsureCreated();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string? DbPath = config.GetValue<string>("DbPath");
            if(DbPath == null)
            {
                throw new SystemException("DbPath not configured in appsettings.json");
            }
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}