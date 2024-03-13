using liftoff_jamey_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace liftoff_jamey_1.ViewModels
{
    public class AddGenreViewModel
    {
        public int ClubId { get; set; }
        public BookClub? BookClub { get; set; }
        public List<SelectListItem>? Genres { get; set; }
		public int GenreId { get; set; }

        public AddGenreViewModel(BookClub bookClub, List<Genre> possibleGenres)
        {
            Genres = new List<SelectListItem>();

            foreach (var genre in possibleGenres)
            {
                Genres.Add(new SelectListItem
                {
                    Value = genre.Id.ToString(),
                    Text = genre.GenreName
                });
            }

            BookClub = bookClub;
        }

        public AddGenreViewModel() { }
    }
}
