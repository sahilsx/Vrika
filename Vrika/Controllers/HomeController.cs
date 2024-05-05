using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vrika.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace Vrika.Controllers
{
	public class HomeController : Controller
	{
		public string erormessage = "";
		private readonly RegistrationsDbContext _dbContext;
		public HomeController(RegistrationsDbContext dbContext)
		{
			_dbContext = dbContext;
		}

       

       [HttpGet]
		public IActionResult Index()
		{
			List<Books> booklist = _dbContext.Booklist.ToList(); // Fetch all interns from the database
			return View(booklist); // Pass the list of interns to the view
			//return View();

        }
        [HttpGet]
        public IActionResult Newarrivals()
        {
            List<Books> booklist = _dbContext.Booklist.ToList(); // Fetch all interns from the database
            return View(booklist); // Pass the list of interns to the view

        }
        [HttpGet]
        public IActionResult Bestseller()
        {
            List<Books> booklist = _dbContext.Booklist.ToList(); // Fetch all interns from the database
            return View(booklist); // Pass the list of interns to the view

        }
        public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult About()
		{
			return View();
		}


        
        public IActionResult Authors()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
        // to show us the create page 

        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}




		[HttpPost]
		public IActionResult Create(Books Application)
		{
			try
			{
				if (ModelState.IsValid)
				{


					_dbContext.Booklist.Add(Application);       // data migration
					_dbContext.SaveChanges();      // update database 
					return RedirectToAction("List");


				}
				foreach (var entry in ModelState.Values)
				{
					foreach (var error in entry.Errors)
					{
						// Log or handle the error message
						// For debugging purposes, you can print it to the console
						Console.WriteLine($"Validation Error: {error.ErrorMessage}");
					}
				}




				return RedirectToAction("Privacy");




			}

			catch (Exception ex)
			{


				erormessage = $"an error occured:{ex.Message}";
				Console.WriteLine(ex.ToString());
				return RedirectToAction("Index");
			}



		}





       



























            [HttpGet]
		public IActionResult List()
		{
			List<Books> booklist = _dbContext.Booklist.ToList(); // Fetch all interns from the database
			return View(booklist); // Pass the list of interns to the view
		}


		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var books = _dbContext.Booklist.Find(Id);

			if (books == null)
			{
				return NotFound();
			}

			return View(books);
		}


		[HttpPost]
		public IActionResult Edit(Books updatedBook)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var existingBook = _dbContext.Booklist.Find(updatedBook.Id);

					if (existingBook == null)
					{
						return NotFound();
					}

					existingBook.BookName = updatedBook.BookName;
					existingBook.BookPrice = updatedBook.BookPrice;
					existingBook.Author = updatedBook.Author;
					existingBook.Genre = updatedBook.Genre;
					existingBook.Url = updatedBook.Url;


					_dbContext.SaveChanges();

					return RedirectToAction("List");
				}
				foreach (var entry in ModelState.Values)
				{
					foreach (var error in entry.Errors)
					{
						// Log or handle the error message
						// For debugging purposes, you can print it to the console
						Console.WriteLine($"Validation Error: {error.ErrorMessage}");
					}
				}

				// else
				{
					return RedirectToAction("Index");


				}
			}
			catch (Exception ex)
			{


				erormessage = $"an error occured:{ex.Message}";
				Console.WriteLine(ex.ToString());
				return RedirectToAction("Index");

			}


		}



        [HttpGet]
        public IActionResult Buy(int Id)
        {
            var books = _dbContext.Booklist.Find(Id);

            if (books == null)
            {
                return NotFound();
            }
			
            return View(books);
        }





        [HttpGet]
		public IActionResult Delete(int Id)
		{
			var book = _dbContext.Booklist.Find(Id);

			if (book == null)
			{
				return NotFound(); // Return a 404 error if the intern is not found
			}

			return View(book);
		}



		[HttpGet]
		public IActionResult DeleteConfirmed()
		{
			return View();
		}



		[HttpPost]
		public IActionResult DeleteConfirmed(int Id)
		{
			var intern = _dbContext.Booklist.Find(Id);

			if (intern == null)
			{
				return NotFound();
			}

			_dbContext.Booklist.Remove(intern);
			_dbContext.SaveChanges();

			return View();
		}



        





    }



}
