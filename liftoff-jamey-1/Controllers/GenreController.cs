using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Models;
using liftoff_jamey_1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using liftoff_jamey_1.ViewModels;

namespace liftoff_jamey_1.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext context;

        public GenreController(ApplicationDbContext dBcontext)
        {
            context = dBcontext;
        }

        // GET
        public IActionResult Index()
        {
            List<Genre> genres = context.Genres.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            Genre genre = new Genre();
            return View(genre);
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            if (ModelState.IsValid)
            {
                context.Genres.Add(genre);
                context.SaveChanges();

                return Redirect("/Genre/");
            }

            return View("Add", genre);
        }

        [HttpGet]
        public IActionResult AddClub(int id)
        {
            BookClub bookClub = context.BookClubs.Find(id);
            List<Genre> possibleGenres = context.Genres.ToList();

            AddGenreViewModel addGenreViewModel = new AddGenreViewModel(bookClub, possibleGenres);

            return View(addGenreViewModel);
        }

        [HttpPost]
        public IActionResult AddClub(AddGenreViewModel addGenreViewModel)
        {
            if (ModelState.IsValid)
            {
                int clubId = addGenreViewModel.ClubId;
                int genreId = addGenreViewModel.GenreId;

                BookClub bookClub = context.BookClubs.Include(g => g.Genres).Where(b => b.Id == clubId).First();
                Genre theGenre = context.Genres.Where(g => g.Id == genreId).First();

                bookClub.Genres.Add(theGenre);

                context.SaveChanges();

                return View();
            }
            return View();
        }

        public IActionResult Detail(int id) 
        {
            Genre theGenre = context.Genres.Include(b => b.BookClubs).Where(g => g.Id == id).First();

            return View(theGenre);
        }
    }
}
