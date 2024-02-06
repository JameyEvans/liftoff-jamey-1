using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using liftoff_jamey_1.Data;
using liftoff_jamey_1.Models;
using liftoff_jamey_1.ViewModels;


namespace liftoff_jamey_1.Controllers
{
	public class BookClubController : Controller
	{
		private readonly BookClubDbContext context;
		public BookClubController(BookClubDbContext dbContext)
		{
			context = dbContext;
		}

		public IActionResult Index()
		{
			List<BookClub> bookclubs = context.BookClubs.Include(e => e.ClubName).ToList();

			return View(bookclubs);
		}

	
		public IActionResult Add()
		{
			List<BookClub> bookClubs = context.BookClubs.ToList();
			AddBookClubViewModel viewModel = new AddBookClubViewModel();
			//AddBookClubViewModel addBookClubViewModel = new BookClub(bookClubs);

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Add(AddBookClubViewModel addBookClubViewModel)
		{
			if (ModelState.IsValid)
			{
				//BookClub theBookClub = context.BookClubs.Find(addBookClubViewModel.Id);
				BookClub newBookClub = new BookClub
				{
					ClubName = addBookClubViewModel.ClubName,
					Location = addBookClubViewModel.Location,
				};
				context.BookClubs.Add(newBookClub);
				context.SaveChanges();
				return Redirect("/BookClub");
			}
			return View(addBookClubViewModel);

		}

	}
    
}
/*public class BookClubController : Controller
{
	private readonly BookClubDbContext bookclubDbContext;
	public BookClubController(BookClubDbContext bookclubDbContext)
	{
		this.bookclubDbContext = bookclubDbContext;
	}
	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var bookclubs = await bookclubDbContext.BookClubs.ToListAsync();
		return View(bookclubs);
	}
	[HttpGet]
	public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(AddBookClubViewModel addBookClubRequest)
	{
		var bookclub = new BookClub()
		{
			ClubName = addBookClubRequest.ClubName,
			Location = addBookClubRequest.Location
		};

		await bookclubDbContext.BookClubs.AddAsync(bookclub);
		await bookclubDbContext.SaveChangesAsync();
		return RedirectToAction("Index");
	}
	[HttpGet]
	public async Task<IActionResult> View(int id)
	{
		var bookclub = await bookclubDbContext.BookClubs.FirstOrDefaultAsync(x => x.Id == id);

		if (bookclub != null)
		{
			var viewModel = new UpdateBookClubViewModel()
			{
				Id = bookclub.Id,
				ClubName = bookclub.ClubName,
				Location = bookclub.Location
			};
			return await Task.Run(() => View("View", viewModel));
		}

		return RedirectToAction("Index");
	}
	[HttpPost]
	public async Task<IActionResult> View(UpdateBookClubViewModel model)
	{
		var bookclub = await bookclubDbContext.BookClubs.FindAsync(model.Id);
		if (bookclub != null)
		{
			bookclub.ClubName = model.ClubName;
			bookclub.Location = model.Location;

			await bookclubDbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		return RedirectToAction("Index");
	}
	[HttpPost]
	public async Task<IActionResult> Delete(UpdateBookClubViewModel model)
	{
		var bookclub = await bookclubDbContext.BookClubs.FindAsync(model.Id);

		if (bookclub != null)
		{
			bookclubDbContext.BookClubs.Remove(bookclub);
			await bookclubDbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		return RedirectToAction("Index");
	}

}*/