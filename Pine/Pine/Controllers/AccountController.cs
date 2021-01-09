using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
using Pine.Models.Account;
using Pine.Models.Entities;
using Pine.Services;
using Pine.Services.Interfaces;

namespace Pine.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IPostServices postServices;
        private readonly IUserServices userServices;
        private readonly ICommunityServices communityService;
        private readonly PineContext db;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, IPostServices postServices, IUserServices userServices, ICommunityServices communityService,
            PineContext Db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.postServices = postServices;
            this.userServices = userServices;
            this.communityService = communityService;
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

        public async Task<IActionResult> UserPanel(string name)
        {
            //if (userName == null)
            //{
            //    return NotFound();
            //}

            //var user = await db.users.FirstOrDefaultAsync(u => u.UserName == userName);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            //return View(user);

             var userName =  userServices.getUserById(name).UserName;
             ICollection <Post> posts =  postServices.getAllPosts().Where(p => p.creator.UserName == name).ToList();
            PostsViewModel model = new PostsViewModel()
            {
                posts = posts.Select(p => new OutputPostViewModel
                {
                    id = p.id,
                    title = p.title,
                    description = p.description,
                    img = p.Img,
                    tags = p.tags,
                    userName = userName,
                    creatorId = p.creatorId,
                    uploadDate = p.timeOfCreation
                }).OrderByDescending(p => p.uploadDate).ToList()
            };

            return View(model);








        }

        public ActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("AllPosts", "Community");
        }
    }
}