using System;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.ViewModels
{
	public class BookClubDetailViewModel
	{
		public int BookClubId { get; set; }
		public string ClubName { get; set; }
		public string Location { get; set; }

  //      public BookClubDetailViewModel(BookClub theBookClub)
		//{
  //          BookClubId = theBookClub.Id;
		//	ClubName = theBookClub.ClubName;
		//	Location = theBookClub.Location;
		//}

	}
}
