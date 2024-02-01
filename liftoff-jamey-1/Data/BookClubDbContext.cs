
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Models;



namespace liftoff_jamey_1.Data
{
    public class BookClubDbContext : DbContext
    {
        public BookClubDbContext(DbContextOptions<BookClubDbContext> options) : base(options)
        {
        }
        public DbSet<BookClub> BookClubs { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
            base.OnModelCreating(modelBuilder);
        } */
    }
}