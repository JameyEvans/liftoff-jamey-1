using System;
using liftoff_jamey_1.Data;
using Microsoft.AspNetCore.Mvc;

namespace liftoff_jamey_1.Controllers
{
	public class SampleUserController : Controller
	{
        private readonly ApplicationDbContext _db;
        private readonly ApplicationDbContext _userManager;

        //depend injection
        public SampleUserController(ApplicationDbContext db, ApplicationDbContext userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
		{
			return View();
		}
	}
}

