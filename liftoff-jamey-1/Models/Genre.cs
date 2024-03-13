using System.ComponentModel.DataAnnotations;

namespace liftoff_jamey_1.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public ICollection<BookClub> BookClubs { get; set; }

        public Genre(string name)
        {
            GenreName = name;
            BookClubs = new List<BookClub>();
        }

        public Genre() { }
    }
}
