using Microsoft.EntityFrameworkCore;
using PublisherJobInfra.Infra.Entities;

namespace PublisherJobInfra.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=user-weather-report-service.database.windows.net;Initial Catalog=user-database;Integrated Security=False; User ID=Marina;Password=julia24MAISA");
        }
        public DbSet<UserEntity> User { get; set; }
    }
}
