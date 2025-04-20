using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext 
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }

        /// <summary>
        ///  OnModelCreating Model Builder for Database Connection
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("a054baf8-4de8-4a8c-b6eb-e9b4fe0d661e"),
                    Name = "EASY"
                },
                new Difficulty
                {
                    Id = Guid.Parse("ada6443c-2f08-4489-adb6-76557c061c3e"),
                    Name = "MEDIUM"
                },
                new Difficulty
                {
                    Id = Guid.Parse("b187c163-b4a2-42ed-b9ae-9fa226cfb0b6"),
                    Name = "HARD"
                }
            };

            //seed difficulties to the database.
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed data for Regions

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("c3a31227-3567-4cc7-a0a5-4e21d9dc3e1b"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://example.com/auckland.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("21637126-6aaa-48c6-8219-c2dfbc2c8bc5"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://example.com/wellington.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("19253ec9-fa58-4852-8e93-0bc0d15755ff"),
                    Name = "Taranaki",
                    Code = "TNK",
                    RegionImageUrl = "https://example.com/Taranaki.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
