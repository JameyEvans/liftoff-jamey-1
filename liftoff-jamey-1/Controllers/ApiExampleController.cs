using Microsoft.AspNetCore.Mvc;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.Controllers
{
    public class ApiExampleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
