using BlazorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Contexts
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<UserDetail> UserDetails { get; set; }
        public EmployeeDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationInstance = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName ?? ".")
                .AddJsonFile("appsettings.json",optional:true)
                .Build();

            string dbConnString = configurationInstance["ConnectionStrings:DbEmployee"] ?? "";
            optionsBuilder.UseNpgsql(dbConnString); 
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
