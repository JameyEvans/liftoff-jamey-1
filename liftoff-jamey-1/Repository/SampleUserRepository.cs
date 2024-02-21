using System;
using liftoff_jamey_1.Areas.Identity.Data;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Interfaces;
using liftoff_jamey_1.Models;
using Microsoft.EntityFrameworkCore;

namespace liftoff_jamey_1.Repository
{
	public class SampleUserRepository :ISampleUserRepository
	{

        private readonly ApplicationDbContext _db;

		public SampleUserRepository(ApplicationDbContext db)
		{
            _db = db;
		}

        public async Task<IEnumerable<SampleUser>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<SampleUser> GetUserById(string id)
        {
            return await _db.Users.FindAsync(id);
        }
        public async Task<bool> IsUserMemberOfBookClubAsync(string userId, int bookClubId)
        {
            return await _db.Members
                .AnyAsync(m => m.SampleUserId == userId && m.BookClubId == bookClubId);
        }

        public async Task AddUserToBookClubAsync(string userId, int bookClubId)
        {
            var member = new Member { SampleUserId = userId, BookClubId = bookClubId };
            _db.Members.Add(member);
            await _db.SaveChangesAsync();
        }

        public async Task<List<BookClub>> GetUserBookClubsAsync(string userId)
        {
            // Retrieve the book clubs associated with the provided user ID
            return await _db.Members
                .Where(m => m.SampleUserId == userId)
                .Select(m => m.BookClub)
                .ToListAsync();
        }

        public async Task RemoveUserFromBookClubAsync(string userId, int bookClubId)
        {
            var member = await _db.Members.FirstOrDefaultAsync(m => m.SampleUserId == userId && m.BookClubId == bookClubId);
            if (member != null)
            {
                _db.Members.Remove(member);
                await _db.SaveChangesAsync();
            }
        }
    }
}

