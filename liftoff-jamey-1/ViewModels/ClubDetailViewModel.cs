using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.ViewModels
{
	//this code is currently not used for anything, attempting to use it to display data on the club details
	public class ClubDetailViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public string GenreText { get; set; }

		public ClubDetailViewModel(BookClub bookClub) 
		{
			Id = bookClub.Id;
			Name = bookClub.ClubName;
			Description = bookClub.Description;
			Location = bookClub.Location;
			GenreText = "";
			List<Genre> genres = bookClub.Genres.ToList();

			for (int i = 0; i < genres.Count; i++)
			{
				GenreText += ("#" + genres[i].GenreName);
				if (i < genres.Count - 1)
				{
					GenreText += ",";
				}
			}

		}

	}
}
