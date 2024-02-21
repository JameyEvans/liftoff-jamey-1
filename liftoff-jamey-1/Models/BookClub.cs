

using System.ComponentModel.DataAnnotations.Schema;
using liftoff_jamey_1.Areas.Identity.Data;

namespace liftoff_jamey_1.Models
{
    public class BookClub
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        [ForeignKey("SampleUser")]
        public string? SampleUserId { get; set; }
        public SampleUser? SampleUser { get; set; }

        public BookClub(string clubName, string location) 
        {
            ClubName = clubName;
            Location = location;
        }

        public BookClub()
        {

        }
    }
}