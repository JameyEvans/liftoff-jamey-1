using System;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.Interfaces
{
	//interfaces are full of method signatures and we use them for dependency injection and polymorphism

	//You can do these more complex database calls

	public interface IBookClubRepository
	{
		Task<IEnumerable<BookClub>> GetAll();
		Task<BookClub> GetByIdAsync(int id);

		Task<BookClub> GetByIdGenreAsync(int id);

		//CRUDs
		bool Add(BookClub bookClub);
		bool Update(BookClub bookClub);
		bool Delete(BookClub bookClub);
		bool Save();
	}
}

