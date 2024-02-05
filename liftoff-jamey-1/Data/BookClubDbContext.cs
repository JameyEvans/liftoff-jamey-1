using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace liftoff_jamey_1.Data
{
    public class BookClubDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
		public DbSet<BookClub> BookClubs { get; set; }

        public BookClubDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
        } 
    }
}