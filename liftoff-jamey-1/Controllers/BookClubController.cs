using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using Microsoft.AspNetCore.Identity;
namespace liftoff_jamey_1.Controllers
{
	public class BookClubController : Controller
	{
		private readonly ApplicationDbContext _context;

        public BookClubController(ApplicationDbContext context)
		{
			_context = context;
		}


        public IActionResult Index()
        {
            IEnumerable<BookClub> objBookClubList = _context.BookClubs;
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
            _context.BookClubs.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}


