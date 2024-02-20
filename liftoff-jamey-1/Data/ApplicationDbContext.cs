
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
        public DbSet<UserBookClub> UserBookClubs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
            modelBuilder.Entity<BookClub>().Property(b => b.Location).IsRequired();

            modelBuilder.Entity<BookClub>()
           .HasOne(bc => bc.Owner)
           .WithMany(u => u.OwnedBookClubs)
           .HasForeignKey(bc => bc.OwnerId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserBookClub>()
            .HasKey(ubc => ubc.UserBookClubId);

            modelBuilder.Entity<UserBookClub>()
                .HasOne(ubc => ubc.User)
                .WithMany(u => u.UserBookClubs)
                .HasForeignKey(ubc => ubc.UserId);

            modelBuilder.Entity<UserBookClub>()
                .HasOne(ubc => ubc.BookClub)
                .WithMany(bc => bc.Members)
                .HasForeignKey(ubc => ubc.BookClubId);

        }
    }
}