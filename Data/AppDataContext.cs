using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<MarketItem> MarketItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=minimalApi.db;Cache=Shared");
    }
}