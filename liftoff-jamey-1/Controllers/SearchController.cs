using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using liftoff_jamey_1.Models;
using System.Security.Cryptography.X509Certificates;

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
    }
}