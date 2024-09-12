using Microsoft.EntityFrameworkCore;
using NZWalks_API.Models.Domain;

namespace NZWalks_API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "Ack",
                    Name = "Auckland",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fnztraveltips.com%2Fauckland-walks%2F&psig=AOvVaw0_uAXPNhMCy7Vq0Uo31BAx&ust=1726212687422000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCODw88LxvIgDFQAAAAAdAAAAABAE"
                });

        }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

    }
}
