using liftoff_jamey_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
namespace liftoff_jamey_1.ViewModels
{
	public class EditBookClubViewModel
	{
		public int Id { get; set; }

		public BookClub? BookClub { get; set; }

		public string ClubName { get; set; }

		public string Location { get; set; }

		public string Description { get; set; }

		public List<SelectListItem>? Genres { get; set; }

		public int GenreId { get; set; }

		public EditBookClubViewModel(BookClub bookClub, List<Genre> genres)
		{
			Genres = new List<SelectListItem>();

			foreach (var genre in genres)
			{
				Genres.Add(new SelectListItem
				{
					Value = genre.Id.ToString(),
					Text = genre.GenreName
				});
			}
			BookClub = bookClub;	
		}

		public EditBookClubViewModel() { }
	}
}

