using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vrika.Models;

namespace Vrika.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser model)
        {
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };


            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await _userManager.AddToRoleAsync(user, "User");

                if (role.Succeeded)
                {
                    return RedirectToAction("Login");

                }
            }
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                var login = await _signInManager.PasswordSignInAsync(model.UserName,
                model.Password, false, false);


                if (login != null && login.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password. Please try again.");
                    return View(model);
                }
            }
            else
            {
                return View();

            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()

        {

            await _signInManager.SignOutAsync();
           
            
                return RedirectToAction( "Login");


            
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                // Handle the case when the user is not found
                return NotFound();
            }
            var username = user.UserName;
            var email = user.Email;

            var model = new Userprofile
            {
                Username = username,
                Email = email
            };


            return View(model);

            return View();
        }
    }
}

