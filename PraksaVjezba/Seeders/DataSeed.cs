using Microsoft.EntityFrameworkCore;
using PraksaVjezba.Entities;

namespace PraksaVjezba.Seeders
{
    public static class DataSeed
    {
        public static void SeedCountryData(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Country>()
                .HasData(new[]
                {
                    new Country
                    {
                        Id=1,
                        Name="Srbija"
                    },
                    new Country
                    {
                        Id = 2,
                        Name="Hrvatska"
                    },
                    new Country
                    {
                        Id = 3,
                        Name="Grcka"
                    },new Country
                    {
                        Id = 4,
                        Name="Bosna i Hercegovina"
                    },new Country
                    {
                        Id = 5,
                        Name="Italija"
                    },
                    new Country
                    {
                        Id = 6,
                        Name="Francuska"
                    }

                });
        }
    }
}
