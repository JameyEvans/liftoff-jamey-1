using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using liftoff_jamey_1.Interfaces;

namespace liftoff_jamey_1.Controllers
{
    public class BookClubController : Controller
    {
        private readonly IBookClubRepository _bookClubRepository;

        //depend injection
        public BookClubController(IBookClubRepository bookClubRepository)
        {
            _bookClubRepository = bookClubRepository;
        }

        public async Task<IActionResult> Index()     //C
        {
            IEnumerable <BookClub> bookClubs = await _bookClubRepository.GetAll();  //M
            return View(bookClubs);  //V
        }

        public async Task <IActionResult> Detail(int id)
        {
            //use .include to create that join to user
            BookClub bookClub = await _bookClubRepository.GetByIdAsync(id);
            return View(bookClub);

        }



    }
}
    

