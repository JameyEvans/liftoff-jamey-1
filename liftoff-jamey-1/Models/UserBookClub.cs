using System;
using liftoff_jamey_1.Areas.Identity.Data;

namespace liftoff_jamey_1.Models
{
	public class UserBookClub
	{
        public int UserBookClubId { get; set; }
        public string UserId { get; set; }
        public SampleUser User { get; set; }

        public int BookClubId { get; set; }
        public BookClub BookClub { get; set; }
    }
}

