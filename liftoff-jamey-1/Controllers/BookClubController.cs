using Microsoft.AspNetCore.Mvc;
using liftoff_jamey_1.Models;
using liftoff_jamey_1.Interfaces;
using liftoff_jamey_1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace liftoff_jamey_1.Controllers
{


    public class BookClubController : Controller
    {
        
        //dependency injection (ref: Interface + Repo Folders)
        private readonly IBookClubRepository _bookClubRepository;
        private readonly ISampleUserRepository _sampleUserRepository;
        private readonly UserManager<SampleUser> _userManager;

        private readonly ApplicationDbContext _applicationDbContext;
        public BookClubController(IBookClubRepository bookClubRepository, ISampleUserRepository sampleUserRepository, UserManager<SampleUser> userManager, ApplicationDbContext applicationDbContext)
        {
            _bookClubRepository = bookClubRepository;
            _sampleUserRepository = sampleUserRepository;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }




        public async Task<IActionResult> Index()     //C
        {
            IEnumerable<BookClub> bookClubs = await _bookClubRepository.GetAll();  //M
            return View(bookClubs);  //V
        }


        //READ
        public async Task<IActionResult> Detail(int id)
        {

            BookClub bookClub = await _bookClubRepository.GetByIdAsync(id);
            return View(bookClub);

        }


        //CREATE : create a bookclub 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookClub bookClub)
        {
            if (!ModelState.IsValid) //going to check that data structure making sure it meets attribute requirements
            {
                return View(bookClub);
            }
            _bookClubRepository.Add(bookClub);
            return RedirectToAction("Index");
        }

        //UPDATE : changes to book club 
        public async Task<IActionResult> Edit(int id)
        {
            var bookClub = await _bookClubRepository.GetByIdAsync(id);
            List<Genre> possibleGenres = _applicationDbContext.Genres.ToList();
            if (bookClub == null) return View("Error");
            var bookClubVM = new EditBookClubViewModel
            {
                ClubName = bookClub.ClubName,
                Location = bookClub.Location,
                Description = bookClub.Description
            };
            


            return View(bookClubVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBookClubViewModel bookClubVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", bookClubVM);
            }

            var bookClub = new BookClub
            {
                Id = id,
                ClubName = bookClubVM.ClubName,
                Location = bookClubVM.Location,
                Description = bookClubVM.Description,
            };
            bookClub.Genres.Add(_applicationDbContext.Genres.Where(g => g.Id == bookClubVM.GenreId).First());

            _bookClubRepository.Update(bookClub);

            return RedirectToAction("Index");
        }

        [Authorize] // Ensure user is authenticated
    public async Task<IActionResult> MyClubs()
    {
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null)
        {
            return NotFound("User not found.");
        }

        var userBookClubs = await _sampleUserRepository.GetUserBookClubsAsync(currentUser.Id);
        return View(userBookClubs);
    }

        // POST: BookClub/Join/{id}
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            var bookClub = await _bookClubRepository.GetByIdAsync(id);
            if (bookClub == null)
            {
                return NotFound("Book club not found.");
            }

            // Check if the user is a member
            var isMember = await _sampleUserRepository.IsUserMemberOfBookClubAsync(currentUser.Id, id);
            if (isMember)
            {
                return BadRequest("User is already a member of this book club.");
            }

            // Add user to the book club by calling a method in your repository
            await _sampleUserRepository.AddUserToBookClubAsync(currentUser.Id, id);

            return RedirectToAction("MyClubs");
        }

        //DELETE : remove book club from Users list and remove them as a member
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            // Remove user from the book club
            await _sampleUserRepository.RemoveUserFromBookClubAsync(currentUser.Id, id);

            return RedirectToAction("MyClubs"); 
        }

    }
}

    

