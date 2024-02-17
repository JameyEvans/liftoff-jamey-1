using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using liftoff_jamey_1.Models;
using System.Security.Cryptography.X509Certificates;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.ViewModels;
using Newtonsoft.Json;
using System.Reflection;
using liftoff_jamey_1.Controllers;
using System.Net.Http;

namespace liftoff_jamey_1.Controllers

{
    public class SearchController : Controller
    {
      	[HttpGet]
        [Route("/search")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/search")]
        public IActionResult Index(string searchTerm)
        {
            return View();
        }

		//TODO: Task 4: Create the Add/Delete books here as needed and update views
	}
}