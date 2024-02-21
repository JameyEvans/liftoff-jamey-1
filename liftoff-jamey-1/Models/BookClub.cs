using liftoff_jamey_1.Areas.Identity.Data;

using System.Diagnostics;

namespace liftoff_jamey_1.Models
{
    public class BookClub
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string Location { get; set; }
        public string ScreenName { get; set; }
        public string? CreatorId { get; set; }
        public SampleUser? Creator { get; set; }

        /*public BookClub(string clubName, string location, string creatorId)
        {
            ClubName = clubName;
            Location = location;
            CreatorId = creatorId;
        }*/

        public BookClub()
        {

        }
    }
}

    