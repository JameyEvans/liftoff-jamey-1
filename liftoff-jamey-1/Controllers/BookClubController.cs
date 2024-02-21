using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using liftoff_jamey_1.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using liftoff_jamey_1.Areas.Identity.Data;

namespace liftoff_jamey_1.Controllers
{
    public class BookClubController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SampleUser> _userManager;
        public BookClubController(ApplicationDbContext db, UserManager<SampleUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        

        public IActionResult Index()
        {
            List<BookClub> bookClubs = _db.BookClubs.ToList();
            return View(bookClubs);
        }
        

        //GET
        [Authorize]     //If they are not logged in, they will be redirected to the login page.
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookClub obj)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // Get the logged-in user
                obj.CreatorId = user.Id; // Set the CreatorId property of the book club
                _db.BookClubs.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); // Return the view with validation errors if ModelState is not valid
        }


        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookClub obj)
        {


            _db.BookClubs.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");


        }*/

       
        public IActionResult Detail(int id)
        {
            // Retrieve the book club from the database based on the id
            var bookClub = _db.BookClubs
                .Include(bc => bc.Creator)
                .FirstOrDefault(bc => bc.Id == id);

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
                CreatorName = bookClub.Creator.UserName

                // Populate other properties of the view model as needed
            };

            return View(viewModel); // Pass the view model to the Razor view

        }
    }
}





