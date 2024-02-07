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
			IEnumerable<BookClub> objBookClubList = _db.BookClubs;
			return View(objBookClubList);
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
    }
}
