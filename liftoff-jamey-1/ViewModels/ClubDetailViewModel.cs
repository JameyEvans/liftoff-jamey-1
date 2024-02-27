using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.ViewModels
{
    public class ClubDetailViewModel
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string GenreText { get; set; }

        public ClubDetailViewModel(BookClub bookClub) 
        {
            ClubId = bookClub.Id;
            Name = bookClub.ClubName;
            GenreText = "";
            List<Genre> genres = bookClub.Genres.ToList();

            for (int i = 0; i < genres.Count; i++)
            {
                GenreText += (genres[i].GenreName);
                if (i < genres.Count - 1)
                {
                    GenreText +=", ";
                }
            }
        }
    }

}
