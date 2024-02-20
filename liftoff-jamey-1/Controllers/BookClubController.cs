using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
            var bookClubs = _db.BookClubs.ToList();
            return View(bookClubs);
        }

        //GET
        [Authorize]
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(BookClub bookClub)
        {
                // Set owner
                bookClub.OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _db.BookClubs.Add(bookClub);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }


        public IActionResult Detail(int id)
        {
            // Retrieve the book club from the database based on the id
            var bookClub = _db.BookClubs.Include(bc => bc.Members).FirstOrDefault(bc => bc.Id == id);

            if (bookClub == null)
            {
                return NotFound(); // Return a 404 Not Found error if the book club doesn't exist or been deleted
            }

            // Create a BookClubDetailViewModel and populate it with the details of the book club
            BookClub bookClubDetails = new BookClub
            {
                Id = bookClub.Id,
                ClubName = bookClub.ClubName,
                Location = bookClub.Location,
                Owner = bookClub.Owner,
                Members = bookClub.Members
                // Populate other properties of the view model as needed
            };

            return View(bookClubDetails); // Pass the view model to the Razor view
        }

        [HttpPost]
        public IActionResult Join(int bookClubId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userBookClub = new UserBookClub { UserId = userId, BookClubId = bookClubId };
            _db.UserBookClubs.Add(userBookClub);
            _db.SaveChanges();
            return RedirectToAction("user");
        }
    }

}
    

