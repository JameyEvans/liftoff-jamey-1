using System;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using liftoff_jamey_1.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> AddBookClubToUser(int bookClubId)
        {
            var bookClub = await _context.BookClubs.FirstOrDefaultAsync(bc => bc.Id == bookClubId);
            if (bookClub == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Check if the user is already a member of the club
            if (!user.UserBookClubs.Any(ubc => ubc.BookClubId == bookClubId))
            {
                user.UserBookClubs.Add(new UserBookClub { UserId = user.Id, BookClubId = bookClubId });
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "BookClubs"); // Redirect to book clubs index page
        }
    }
}

