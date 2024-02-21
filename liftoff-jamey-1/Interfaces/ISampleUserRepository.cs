using System;
using liftoff_jamey_1.Areas.Identity.Data;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.Interfaces
{
	public interface ISampleUserRepository
	{
        Task<IEnumerable<SampleUser>> GetAllUsers();
        Task<SampleUser> GetUserById(string id);
        Task<bool> IsUserMemberOfBookClubAsync(string userId, int bookClubId);
        Task AddUserToBookClubAsync(string userId, int bookClubId);
        Task<List<BookClub>> GetUserBookClubsAsync(string userId);
    }
}

