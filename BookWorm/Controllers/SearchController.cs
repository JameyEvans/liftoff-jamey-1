using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BookWorm.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            return View();
        }
    }
}
