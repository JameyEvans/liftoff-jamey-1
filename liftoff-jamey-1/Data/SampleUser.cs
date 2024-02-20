using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Areas.Identity;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.Areas.Identity.Data
{
    public class SampleUser : IdentityUser
	{
        public string ScreenName { get; set; }
        public ICollection<UserBookClub> UserBookClubs { get; set; }
        public ICollection<BookClub> OwnedBookClubs { get; set; }
    }
}

