using System;

namespace liftoff_jamey_1.Models
{
    public class BookClub
    {
        public int? Id { get; set; }
        public string? ClubName { get; set; }
        public string? Location { get; set; }

        public ICollection<UserBookClub> UserBookClubs { get; set; }

        public BookClub(string clubName, string location) 
        {
            ClubName = clubName;
            Location = location;
        }
        
        public BookClub()
        {

        }

		public override string ToString()
		{
			return ClubName;
		}

		public override bool Equals(object obj)
		{
			return obj is BookClub @bookClub && 
                Id == @bookClub.Id;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id);
		}
	}
}