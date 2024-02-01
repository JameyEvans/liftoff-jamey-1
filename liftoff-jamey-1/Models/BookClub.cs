using System;

namespace liftoff_jamey_1.Models
{
    public class BookClub
    {
        public int? Id { get; set; }
        public string? ClubName { get; set; }
        public string? Location { get; set; }
        //public string? PublicOrPrivate { get; set; } //not sure about this one.
        //public bool IsPublic { get; set;}

        /*public BookClub(string clubName)
        {
            ClubName = clubName;
        }

        public BookClub() { }*/
    }
}