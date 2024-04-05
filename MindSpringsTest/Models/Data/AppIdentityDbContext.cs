using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MindSpringsTest.Models.Data
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }

        public DbSet<StringText> StringTexts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StringText>()
                .HasOne(x => x.AppUser)
                .WithMany(y => y.StringTexts)
                .HasForeignKey(a => a.AppUserId);
        }
    }
}
