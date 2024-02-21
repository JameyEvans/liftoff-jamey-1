using liftoff_jamey_1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace liftoff_jamey_1.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext context;
        
        public GenreController(ApplicationDbContext dBcontext)
        {
            context = dBcontext;
        }

        //GET
        public IActionResult Index()
        {
            List<Genre> genres = context.Genres.ToList();
            return View();
        }
    }
}
