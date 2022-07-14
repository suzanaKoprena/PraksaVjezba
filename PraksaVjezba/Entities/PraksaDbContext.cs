using Microsoft.EntityFrameworkCore;


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



    }
}
