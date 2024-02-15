using System;
using liftoff_jamey_1.Areas.Identity.Data;
using liftoff_jamey_1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.Controllers
{
	public class UserController : Controller
	{
        private readonly UserManager<SampleUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<SampleUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<UserBookClub> userBookClubs = _context.UserBookClubs.Include(a => a.BookClub).ToList();

            return View(userBookClubs);
        }
    }
}

