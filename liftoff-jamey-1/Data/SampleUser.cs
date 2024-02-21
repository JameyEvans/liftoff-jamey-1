using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Areas.Identity;

namespace liftoff_jamey_1.Areas.Identity.Data
{
    public class SampleUser : IdentityUser
	{
        //public string Creator { get; set; }
        public string ScreenName { get; set; }
    }
}

