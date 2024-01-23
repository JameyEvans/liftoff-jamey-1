using System;
using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;


namespace liftoff_jamey_1.Data
{
	public class BookwormDbContext : DbContext
	{
		DbSet<User> Users { get; set; }
		DbSet<Search> Searches { get; set; }
		DbSet<Book> Books { get; set; }

		public BookwormDbContext(DbContextOptions<BookwormDbContext> options) : base(options)
		{
		}
	}
}

