using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Models;
using liftoff_jamey_1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using liftoff_jamey_1.ViewModels;
using Humanizer.Localisation;
using liftoff_jamey_1.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace liftoff_jamey_1.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IBookClubRepository _bookClubRepository;
        public GenreController(IBookClubRepository bookClubRepository, ApplicationDbContext db)
        {
            _db = db;
            _bookClubRepository = bookClubRepository;
        }

        // GET
        public IActionResult Index()
        {
            IEnumerable<Genre> objGenreList = _db.Genres;
            return View(objGenreList);
        }

        // GET
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre obj)
        {
            _db.Genres.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddClub(int id)
        {
            BookClub bookClub = _db.BookClubs.Find(id);


            List<Genre> genreList = _db.Genres.ToList();
            AddGenreViewModel addGenreVM = new AddGenreViewModel(bookClub, genreList);


            return View(addGenreVM);


        }

        [HttpPost]
        public async Task<IActionResult> AddClub(AddGenreViewModel addGenreVM)
        {
            if (ModelState.IsValid)
            {
                int genreId = addGenreVM.GenreId;
                int clubId = addGenreVM.ClubId;


                BookClub bookClub = _db.BookClubs.Include(g => g.Genres).Where(e => e.Id == clubId).First();
                Genre theGenre = _db.Genres.Where(g => g.Id == genreId).First();

                bookClub.Genres.Add(theGenre);

                _db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(addGenreVM);
        }
        public IActionResult Detail(int id)
        {
            Genre genre = _db.Genres.Include(b => b.BookClubs).Where(g => g.Id == id).First();

            return View(genre);
        }
    }
}
