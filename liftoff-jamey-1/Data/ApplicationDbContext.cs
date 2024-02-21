
using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;





namespace liftoff_jamey_1.Data
{
    public class ApplicationDbContext : DbContext                   //IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<BookClub> BookClubs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
            modelBuilder.Entity<BookClub>()
                .HasMany(g => g.Genres)
                .WithMany(b => b.ClubName)
                .UsingEntity(e => e.ToTable("ClubGenres"));           
        } 
    }
}