

using liftoff_jamey_1.Areas.Identity.Data;

namespace liftoff_jamey_1.Models
{
    public class BookClub
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string Location { get; set; }

        public string OwnerId { get; set; }
        public SampleUser Owner { get; set; }

        public ICollection<UserBookClub> Members { get; set; }
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