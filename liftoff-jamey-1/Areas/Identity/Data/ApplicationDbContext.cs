
using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using liftoff_jamey_1.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace liftoff_jamey_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<SampleUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BookClub> BookClubs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
            //modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
    }
    //public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<SampleUser>
    //{
    //    public void Configure(EntityTypeBuilder<SampleUser> modelBuilder)
    //    {
    //        modelBuilder.Property(x => x.ScreenName).HasMaxLength(30);
    //    }
    //}
}