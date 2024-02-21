using System;
using Microsoft.AspNetCore.Identity;
using liftoff_jamey_1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace liftoff_jamey_1.Areas.Identity.Data
{
    public class SampleUser : IdentityUser
    {
        public string? ScreenName { get; set; }

        public ICollection<BookClub> BookClubs { get; set; }

    }
}

