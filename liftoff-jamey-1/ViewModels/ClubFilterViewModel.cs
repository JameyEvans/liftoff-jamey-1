using Microsoft.AspNetCore.Mvc.Rendering;

namespace liftoff_jamey_1.ViewModels
{
    public class ClubFilterViewModel
    {
        public List<SelectListItem>? Genres { get; set; }
        public int GenreId { get; set; }
        public string ClubName { get; set; }
    }
}
