
using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;





namespace liftoff_jamey_1.Data
{
    public class BookClubDbContext : DbContext                   //IdentityDbContext<IdentityUser, IdentityRole, string>
    {
		public DbSet<BookClub> BookClubs { get; set; }

        public BookClubDbContext(DbContextOptions<BookClubDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
        } 
    }
}