
using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using liftoff_jamey_1.Areas.Identity.Data;


namespace liftoff_jamey_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<SampleUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
            modelBuilder.Entity<BookClub>().Property(b => b.Location).IsRequired();

            modelBuilder.Entity<BookClub>()
                .HasMany(g => g.Genres)
                .WithMany(b => b.BookClubs)
                .UsingEntity(e => e.ToTable("ClubGenres"));


            modelBuilder.Entity<Member>()
            .HasKey(m => new { m.SampleUserId, m.BookClubId });

            modelBuilder.Entity<Member>()
                .HasOne(m => m.SampleUser)
                .WithMany(u => u.Members)
                .HasForeignKey(m => m.SampleUserId);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.BookClub)
                .WithMany(bc => bc.Members)
                .HasForeignKey(m => m.BookClubId);
        }
    }
}