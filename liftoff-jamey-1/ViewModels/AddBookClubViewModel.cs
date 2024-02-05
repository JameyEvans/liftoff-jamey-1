using System;
using System.ComponentModel.DataAnnotations;

namespace liftoff_jamey_1.ViewModels
{
    public class AddBookClubViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? ClubName { get; set; }


        public string? Location { get; set; }

        public AddBookClubViewModel()
        {

        }
    }
}
