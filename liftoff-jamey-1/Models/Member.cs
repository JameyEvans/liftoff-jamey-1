using System;
using System.ComponentModel.DataAnnotations.Schema;
using liftoff_jamey_1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace liftoff_jamey_1.Models
{
	public class Member
	{
        [ForeignKey("SampleUser")]
        public string SampleUserId { get; set; }

        [ForeignKey("BookClubId")]
        public int BookClubId { get; set; }

        public SampleUser SampleUser { get; set; }
        public BookClub BookClub { get; set; }
    }
}

