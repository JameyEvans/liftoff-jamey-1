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
        private readonly ApplicationDbContext _userManager;

        //depend injection
        public BookClubController(ApplicationDbContext db, ApplicationDbContext userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()     //C
        {
            var bookClubs = _db.BookClubs.ToList();  //M
            return View(bookClubs);  //V
        }

        public IActionResult Detail(int id)
        {
            BookClub bookClub = _db.BookClubs.FirstOrDefault(bc => bc.Id == id);
            return View(bookClub);

        }



    }
}
    

