using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmashAdvanced.Models;

namespace SmashAdvanced.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<GameFeature> Features { get; set; }
        public DbSet<GameScreenshot> GameScreenshots { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Game>().Navigation(g => g.GameTags).AutoInclude();
            builder.Entity<Game>().Navigation(g => g.GamePlatforms).AutoInclude();
            builder.Entity<Game>().Navigation(g => g.GameFeatures).AutoInclude();
            builder.Entity<Game>().Navigation(g => g.GameScreenshots).AutoInclude();
            builder.Entity<GamePlatform>().Navigation(gp => gp.Platform).AutoInclude();
            builder.Entity<GameTag>().Navigation(gt => gt.Tag).AutoInclude();
        }
    }
}
