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
		public GenreController(IBookClubRepository bookClubRepository,ApplicationDbContext db)
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
            var bookClub = await _bookClubRepository.GetByIdAsync(id);
            List<Genre> genreList = _db.Genres.ToList();

            var addGenreVM = new AddGenreViewModel(bookClub, genreList);
          
            
            return View(addGenreVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddClub(int id, AddGenreViewModel addGenreVM)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error");
                ModelState.AddModelError("", "Failed to update");
				return View(addGenreVM);
				
            }
			int genreId = addGenreVM.GenreId;
            int clubId = addGenreVM.ClubId;
            BookClub bookClub = _db.BookClubs.Include(g => g.Genres).Where(c => c.Id == clubId).First();
			Genre genre = _db.Genres.Where(g => g.Id == genreId).First();
			/*var bookClub = new BookClub
			{
				Id = id,
				ClubName = addGenreVM.ClubName,
				Location = addGenreVM.Location,
				Description = addGenreVM.Description,
			};

			bookClub.Genres.Add(genre);
            */

            
            _db.SaveChanges();
		
			return RedirectToAction("Index");

		}
    }
}
