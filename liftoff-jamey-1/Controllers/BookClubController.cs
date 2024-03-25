using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using liftoff_jamey_1.ViewModels;   

using System;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

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

        [HttpPost]
        public IActionResult Update(int id, string key)
        {
            var bookClub = _db.BookClubs.FirstOrDefault(bc => bc.Id == id);

            if (bookClub == null)
            {
                return NotFound();
            }
            bookClub.BookId = key;
            _db.BookClubs.Update(bookClub);
            _db.SaveChanges();
            return Json(new { success = true, message = "Update successful", redirectUrl = Url.Action("Detail", new { id = id }) });
        }
        //bookclub id and bookid

        public IActionResult Detail(int id)
        {
            // Retrieve the book club from the database based on the id
            var bookClub = _db.BookClubs.FirstOrDefault(bc => bc.Id == id);

            if (bookClub == null)
            {
                return NotFound(); // Return a 404 Not Found error if the book club doesn't exist
            }

            // Create a BookClubDetailViewModel and populate it with the details of the book club
            BookClubDetailViewModel viewModel = new BookClubDetailViewModel
            {
                BookClubId = bookClub.Id,
                ClubName = bookClub.ClubName,
                Location = bookClub.Location,
                BookId = bookClub.BookId,
                // Populate other properties of the view model as needed
            };

            return View(viewModel); // Pass the view model to the Razor view


        }
    }
}