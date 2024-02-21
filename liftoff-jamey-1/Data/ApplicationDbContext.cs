
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
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
            modelBuilder.Entity<BookClub>().Property(b => b.Location).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Id).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired();

        }
    }
}