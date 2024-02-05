namespace liftoff_jamey_1.ViewModels
{
    public class AddBookClubViewModel
    {
        public int? Id { get; set; }
        public string? ClubName { get; set; }
        public string? Location { get; set; }

        public AddBookClubViewModel(List<Models.BookClub> bookClubs)
        {

        }
    }
}
