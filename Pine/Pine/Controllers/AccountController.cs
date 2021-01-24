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
        private readonly IShopListingService shopListingService;
        private readonly ICommentServices commentServices;
        private readonly PineContext db;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, IPostServices postServices, IUserServices userServices, ICommunityServices communityService, IShopListingService shopListingService, ICommentServices commentServices,
            PineContext Db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.postServices = postServices;
            this.userServices = userServices;
            this.communityService = communityService;
            this.shopListingService = shopListingService;
            this.commentServices = commentServices;
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
            var user = userServices.getUserByUserName(userName);
            ICollection<Post> posts =  postServices.getAllPosts().Where(p => p.creatorId == user.Id).ToList();
            PostsViewModel postsModel = new PostsViewModel()
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
                    uploadDate = p.timeOfCreation,
                    comments = commentServices.getAllComments(p.id).Select(c => new OutputCommentViewModel
                    {
                        id = c.id,
                        commentaor = c.commentaor,
                        content = c.content,
                        timeOfCreation = c.timeOfCreation,
                        img = c.Img,
                        //userName = userServices.getUserNameById(c.commentaor.Id)
                    }).OrderBy(c => c.timeOfCreation).ToList()
                }).OrderByDescending(p => p.uploadDate).ToList()
            };
            ICollection<ShopListing> listings = shopListingService.getAllListings().Where(l => l.creatorId == user.Id).ToList();
            ShopListingsViewModel listingsModel = new ShopListingsViewModel()
            {
                listings = listings.Select(l => new OutputShopListingViewModel
                {
                    id = l.id,
                    name = l.name,
                    description = l.description,
                    price = l.price,
                    userName = l.creator.UserName,
                    uploadDate = l.timeOfCreation
                }).OrderByDescending(l => l.uploadDate).ToList()
            };
            var tuple = new Tuple<PostsViewModel, User, ShopListingsViewModel>(postsModel, user, listingsModel);
            return View(tuple);
        }

        public ActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("AllPosts", "Community");
        }
    }
}