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
    public class CrudController : Controller
    {
        public string erormessage = "";
        private readonly RequestDbContext _dbContext;
        public CrudController(RequestDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult Request()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Request(Request Application)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _dbContext.Requests.Add(Application);       // data migration
                    _dbContext.SaveChanges();      // update database 
                    return RedirectToAction("Submission");


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








        public IActionResult Submission()
        {
            return View();
        }







        [HttpGet]
        public IActionResult Rlist()
        {
            List<Request> Requests = _dbContext.Requests.ToList(); // Fetch all interns from the database
            return View(Requests); // Pass the list of interns to the view
        }

        [HttpGet]
        public IActionResult Rdelete(int Id)
        {
            var book = _dbContext.Requests.Find(Id);

            if (book == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }

            return View(book);
        }


        [HttpGet]
        public IActionResult RDeleteConfirmed()
        {
            return View();
        }



        [HttpPost]
        public IActionResult RDeleteConfirmed(int Id)
        {
            var intern = _dbContext.Requests.Find(Id);

            if (intern == null)
            {
                return NotFound();
            }

            _dbContext.Requests.Remove(intern);
            _dbContext.SaveChanges();

            return View();
        }

       [HttpGet]
        public IActionResult RNotify(int Id)
        {
            var book = _dbContext.Requests.Find(Id);

            if (book == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }




            return View(book);
        }
        [HttpPost]
        public IActionResult RSendMail(int Id)
        {

            var book = _dbContext.Requests.Find(Id);

            if (book == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }






            var Reciever = book.YourEmail;
            try
            {
                string recipientEmail = Reciever; // Replace with the recipient's email address
                MailMessage mail = new MailMessage();
                SmtpClient server = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("itxsaaho@gmail.com");
                mail.To.Add(Reciever);
                mail.Subject = "your BOOK is coming ";

                mail.Body = "hurray!your Book is Coming";

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


































  }


    }
