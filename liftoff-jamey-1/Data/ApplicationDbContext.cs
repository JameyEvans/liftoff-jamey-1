
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
        // TODO: task 2: create DBset<Book> books

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<BookClub>().Property(b => b.ClubName).IsRequired();
            modelBuilder.Entity<BookClub>().Property(b => b.Location).IsRequired();

            modelBuilder.Entity<BookClub>()
            .HasOne(bc => bc.Creator) // Each BookClub has one Creator
            .WithMany() // Creator can create many BookClubs
            .HasForeignKey(b => b.CreatorId) // Define the foreign key
            .IsRequired(false);
            
            //TODO: task 3: enter your join table relationship properties for selected book | ex: .hasmany(b => b.bookclub) 
        }
    }
}