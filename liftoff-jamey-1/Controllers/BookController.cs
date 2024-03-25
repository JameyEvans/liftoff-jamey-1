using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using liftoff_jamey_1.Data;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Models;

namespace liftoff_jamey_1.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://openlibrary.org/api/books?bibkeys=ISBN:0451526538&jscmd=data&format=json");
            var book = JsonConvert.DeserializeObject<Book>(json);

            return View(book);
        }
    }
}


