using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace carpark_info_assignment
{

    public class CarparkInfoDbContext : DbContext
    {
        [Required(ErrorMessage = "Carpark Info is required")]
        public DbSet<CarparkInfoModel> CarparkInfo { get; set; } = null!;
        private readonly IConfiguration config;

        public CarparkInfoDbContext(IConfiguration _config)
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
            Console.WriteLine(DbPath);
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}