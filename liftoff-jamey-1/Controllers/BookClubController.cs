using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using liftoff_jamey_1.Interfaces;
using liftoff_jamey_1.ViewModels;

namespace liftoff_jamey_1.Controllers
{
    public class BookClubController : Controller
    {
        //dependency injection (ref: Interface + Repo Folders)
        private readonly IBookClubRepository _bookClubRepository;

        public BookClubController(IBookClubRepository bookClubRepository)
        {
            _bookClubRepository = bookClubRepository;
        }

        public async Task<IActionResult> Index()     //C
        {
            IEnumerable<BookClub> bookClubs = await _bookClubRepository.GetAll();  //M
            return View(bookClubs);  //V
        }

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
            public async Task<IActionResult> Edit (int id, EditBookClubViewModel bookClubVM)
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
                Location =bookClubVM.Location,
                Description = bookClubVM.Description,
            };

            _bookClubRepository.Update(bookClub);

            return RedirectToAction("Index");
        }

       }

    }

    

