using System;
using liftoff_jamey_1.Areas.Identity.Data;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.Models
{
	public class UserBookClub
	{
        public string UserId { get; set; }
        public SampleUser User { get; set; }
        public int BookClubId { get; set; }
        public BookClub BookClub { get; set; }

        //bookclub obj list
        public List<BookClub> bookClubs { get; set; }

        public UserBookClub(string userId, int bookClubid)
		{
            UserId = userId;
            BookClubId = bookClubid;
		}

        public UserBookClub()
        {

        }
	}
}

