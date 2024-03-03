using System;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Interfaces;
using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;

namespace liftoff_jamey_1.Repository
{
    public class BookClubRepository : IBookClubRepository
    {
        //repository is centered around your database
        //and your bringing in your database and dropping it in
        private readonly ApplicationDbContext _db;

        public BookClubRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //Always need to implement this interface (inherting from) have to bring in all methods
        public bool Add(BookClub bookClub)
        {
            _db.Add(bookClub);
            return Save();
        }

        public bool Delete(BookClub bookClub)
        {
            _db.Remove(bookClub);
            return Save();
        }

        public async Task<IEnumerable<BookClub>> GetAll()
        {
            return await _db.BookClubs.ToListAsync();

        }

        public async Task<BookClub> GetByIdAsync(int id)
        {                                                           //have to have this include to bring in nav property
            return await _db.BookClubs.Include(u => u.SampleUser).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<BookClub> GetByIdGenreAsync(int id)
        {
            return await _db.BookClubs.Include(g => g.Genres).FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(BookClub bookClub)
        {
            _db.Update(bookClub);
            return Save();
        }
    }
}

