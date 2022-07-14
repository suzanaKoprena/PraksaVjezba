using Microsoft.EntityFrameworkCore;
using PraksaVjezba.Seeders;

namespace PraksaVjezba.Entities
{
    public class PraksaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }


        public PraksaDbContext(DbContextOptions<PraksaDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql().UseSnakeCaseNamingConvention();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeed.SeedCountryData(modelBuilder);
        }
    }
}
