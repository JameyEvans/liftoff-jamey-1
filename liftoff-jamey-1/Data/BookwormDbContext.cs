using System;
using Microsoft.EntityFrameworkCore;


namespace liftoff_jamey_1.Data
{
	public class BookwormDbContext : DbContext
	{
		//DbSet<UserLogIn> UserLogIns { get; set; }
		public BookwormDbContext(DbContextOptions<BookwormDbContext> options) : base(options)
		{
		}
	}
}

