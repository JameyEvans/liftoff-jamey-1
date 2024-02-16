using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;


namespace liftoff_jamey_1.Controllers
{
	public class BookClubController : Controller
	{
		private readonly ApplicationDbContext _db;
		public BookClubController(ApplicationDbContext db)
		{
			_db = db;
		}


		public IActionResult Index()
		{
			List<BookClub> bookClubs = _db.BookClubs.ToList();
			return View(bookClubs);
		}

        //GET
        public IActionResult Create()
        {
           
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookClub obj)
        {
            _db.BookClubs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            BookClub bookClub = _db.BookClubs.Find(id);
            return View(bookClub);
        }
    }
}
