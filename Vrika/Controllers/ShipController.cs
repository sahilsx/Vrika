using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using Vrika.Models;
using System.Security.Principal;
using System.Diagnostics;


namespace Vrika.Controllers
{
    public class ShipController : Controller
    {
        public string erormessage = "";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ShippingDbContext _dbContext;
        public ShipController(UserManager<IdentityUser> userManager, ShippingDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;

        }
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Ship()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ship(Shipping Application)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _dbContext.Shippings.Add(Application);       // data migration
                    _dbContext.SaveChanges();      // update database 
                    return RedirectToAction("Success");


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




                return RedirectToAction("Ship");




            }

            catch (Exception ex)
            {


                erormessage = $"an error occured:{ex.Message}";
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Index");
            }



        }
        [HttpGet]
        public IActionResult Slist()
        {
            List<Shipping> Shippings = _dbContext.Shippings.ToList(); // Fetch all interns from the database
            return View(Shippings); // Pass the list of interns to the view
        }

        [HttpGet]
        public IActionResult Sdelete(int Id)
        {
            var book = _dbContext.Shippings.Find(Id);

            if (book == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }

            return View(book);
        }
        [HttpGet]
        public IActionResult Notify(int Id)
        {
            var book = _dbContext.Shippings.Find(Id);

            if (book == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }




            return View(book);
        }
        [HttpPost]
        public IActionResult SendMail(int Id)
        {

            var book = _dbContext.Shippings.Find(Id);

            if (book == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }




            var reciever = book.email;
            try { 
            string recipientEmail = reciever; // Replace with the recipient's email address
            MailMessage mail = new MailMessage();
            SmtpClient server = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("itxsaaho@gmail.com");
            mail.To.Add(reciever);
            mail.Subject = "your order is ready " ;

            mail.Body = "hurray!your order is ready";

            server.Port = 587;
            server.Credentials = new System.Net.NetworkCredential("itxsaaho@gmail.com", "sptv nday phyp nfsp");
            server.EnableSsl = true;

            server.Send(mail);
            }
            catch (Exception ex)
            {

                erormessage = $"an error occured:{ex.Message}";
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Slist");
            }





            return View();
        



    

    }
        [HttpGet]
        public IActionResult Sdeleteconfirmed()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Sdeleteconfirmed(int Id)
        {
            var intern = _dbContext.Shippings.Find(Id);

            if (intern == null)
            {
                return NotFound();
            }

            _dbContext.Shippings.Remove(intern);
            _dbContext.SaveChanges();

            return View();
        }
        public async Task<IActionResult> Order()
        {
            // Get the current authenticated user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Handle case where user is not authenticated
                return NotFound();
            }

            // Fetch shippings for the current user based on their email
            List<Shipping> userShippings = _dbContext.Shippings.Where(s => s.email == user.Email).ToList();

            // Pass the filtered shippings to the view
             return View(userShippings);
            return View();
        }




    }

}
