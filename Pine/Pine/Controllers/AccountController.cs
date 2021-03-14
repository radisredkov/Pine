using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IFileService fileService;
        private readonly PineContext db;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, IPostServices postServices, IUserServices userServices, ICommunityServices communityService, IShopListingService shopListingService, ICommentServices commentServices, IFileService fileService,
            PineContext Db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.postServices = postServices;
            this.userServices = userServices;
            this.communityService = communityService;
            this.shopListingService = shopListingService;
            this.commentServices = commentServices;
            this.fileService = fileService;
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
                    UserName = registration.Username,
                    Email = registration.Email,
                    profilePicture = fileService.ConvertToByte(registration.profilePicture),
                    userDescription = registration.userDescription
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
                    return RedirectToAction("AllPosts", "Post");
                }

                ModelState.AddModelError("", "Login unsuccesful");
            }
            return View(login);
        }

        public async Task<IActionResult> UserPanel(string userName)
        {
            if (userServices.getUserByUserName(userName) == null)
            {
                return Redirect("404notfound");
            }
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
                        commentaor = c.commentator,
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
                    creatorName = l.creator.UserName,
                    uploadDate = l.timeOfCreation,
                    img = l.Img
                }).OrderByDescending(l => l.uploadDate).ToList()
            };
            var tuple = new Tuple<PostsViewModel, User, ShopListingsViewModel>(postsModel, user, listingsModel);
            return View(tuple);
        }

        [HttpPost]
        public IActionResult EditUser(string userName, UserPanelInputModel model)
        {
            var user = userServices.getUserByUserName(userName);
            userServices.editUser(user, model);
            return RedirectToAction("UserPanel", "Account", new { userName = userName});
        }

        public IActionResult DeleteUser()
        {
            User user = userServices.getUserByUserName(User.Identity.Name);
            userServices.DeleteUser(user);
            return Redirect("Home");
        }
        public IActionResult MessageUser(string userid)
        {
            return Redirect("/");
        }

        public ActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("AllPosts", "Post");
        }
    }
}