using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //       public IActionResult Add()
        //	{
        //		List<BookClub> bookClubs = _db.BookClubs.ToList();
        //		AddBookClubViewModel viewModel = new AddBookClubViewModel();
        //		//AddBookClubViewModel addBookClubViewModel = new BookClub(bookClubs);

        //		return View(viewModel);
        //	}

        //	[HttpPost]
        //	public IActionResult Add(AddBookClubViewModel addBookClubViewModel)
        //	{
        //		if (ModelState.IsValid)
        //		{
        //			//BookClub theBookClub = context.BookClubs.Find(addBookClubViewModel.Id);
        //			BookClub newBookClub = new BookClub
        //			{
        //				ClubName = addBookClubViewModel.ClubName,
        //				Location = addBookClubViewModel.Location,
        //			};
        //			_db.BookClubs.Add(newBookClub);
        //			_db.SaveChanges();
        //			return Redirect("/BookClub");
        //		}
        //		return View(addBookClubViewModel);

        //	}

        //}
    }
}
