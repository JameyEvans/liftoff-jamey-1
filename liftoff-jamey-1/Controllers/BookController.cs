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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApplicationDbContext _db;

        public BookController(IHttpClientFactory httpClientFactory, ApplicationDbContext db)
		{
            _httpClientFactory = httpClientFactory;
            _db = db;
        }

        public async Task<IActionResult> FetchAndSaveBook()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://openlibrary.org/search.json?q=$");

            if (!response.IsSuccessStatusCode)
            {
                // Handle error
                return StatusCode((int)response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();
            var bookData = JsonConvert.DeserializeObject<Book>(content);

            // Extract book information
            var id = bookData.Id;
            var title = bookData.Title;
            var author = bookData.Author;
            var datepublished = bookData.DatePublished;

            // Save book to the database
            var book = new Book
            {
                Id = id,
                Title = title,
                Author = author,
                DatePublished = datepublished,
            };

            _db.Books.Add(book);
            await _db.SaveChangesAsync();

            return RedirectToAction("BookClub", "Detail"); // Redirect to home page or any other page
        }
    }
}


