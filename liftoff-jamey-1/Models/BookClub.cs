

namespace liftoff_jamey_1.Models
{
    public class BookClub
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string Location { get; set; }
        public string CreatorId { get; set; }
        public BookClub(string clubName, string location, string creatorId)
        {
            ClubName = clubName;
            Location = location;
            CreatorId = creatorId;
        }

        public BookClub()
        {

        }
    }
}

    