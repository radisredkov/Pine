using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pine.Data;
using Pine.Data.Identity;
using Pine.Models.Account;

namespace Pine.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly PineContext db;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            PineContext Db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = Db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = registration.Username, //USERNAME =!= EMAIL
                    Email = registration.Email
                };

                IdentityResult result = await this.userManager.CreateAsync(user, registration.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }

            }
            return View(registration);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await this.signInManager
                    .PasswordSignInAsync(
                    login.userName,
                    login.Password,
                    false,
                    false);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllPosts", "Community");
                }

                ModelState.AddModelError("", "Login unsuccesful");
            }
            return View(login);
        }
        public async Task<IActionResult> UserPanel(string userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            var user = await db.users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("AllPosts", "Community");
        }
    }
}