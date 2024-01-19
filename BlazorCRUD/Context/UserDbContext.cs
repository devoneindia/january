using BlazorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public UserDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<User> userDetail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationInstance = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName ?? ".")
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.local.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            string dbConnString = configurationInstance["ConnectionStrings:DbUser"] ?? "";
            optionsBuilder.UseNpgsql(dbConnString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
