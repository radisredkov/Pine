using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
using Pine.Models.Entities;
using Pine.Services;
using Pine.Services.Interfaces;

namespace Pine.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IPostServices postServices;
        private readonly IUserServices userServices;
        private readonly ICommunityServices communityService;
        private readonly PineContext db; 

        

        public CommunityController(IPostServices postServices, IUserServices userServices, ICommunityServices communityService, PineContext context)
        {
            this.postServices = postServices;
            this.userServices = userServices;
            this.communityService = communityService;
            this.db = context;
        }

        public IActionResult AllPosts()
        {
            ICollection<Post> posts = postServices.getAllPosts();
            PostsViewModel model = new PostsViewModel()
            {
                posts = posts.Select(p => new OutputPostViewModel
                {
                    id = p.id,
                    title = p.title,
                    description = p.description,
                    img = p.Img,
                    tags = p.tags,
                    userName = userServices.getUserNameById(p.creatorId),
                    uploadDate = p.timeOfCreation
                }).OrderByDescending(p => p.uploadDate).ToList()
            };

            return View("AllPosts", model);
        }

        public IActionResult Communities()
        {
            ICollection<Community> communities = communityService.getAllcommunities();
            CommunitiesViewModel model = new CommunitiesViewModel()
            {
                communities = communities.Select(c => new OutputCommunityViewModel
                {
                    id = c.id,
                    name = c.name,
                    description = c.description
                }).OrderByDescending(c => c.name).ToList()
            };

            return View("Communities", model);
        }


        [HttpGet("/Posts/AllPosts/orderbydateascending")]
        public IActionResult AllPostsSortByDateAscending()
        {
            ICollection<Post> posts = postServices.getAllPosts();
            PostsViewModel model = new PostsViewModel()
            {
                posts = posts.Select(p => new OutputPostViewModel
                {
                    id = p.id,
                    title = p.title,
                    description = p.description,
                    tags = p.tags,
                    img = p.Img,
                    userName = userServices.getUserNameById(p.creatorId),
                    creatorId = p.creatorId,
                    uploadDate = p.timeOfCreation
                }).OrderBy(p => p.uploadDate).ToList()
            };

            return View("AllPosts", model);
        }

        [HttpGet("/posts/edit")]
        public IActionResult EditPostView(OutputPostViewModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return View("EditPost", model);
        }

        [HttpPost("posts/edit")]
        public IActionResult EditPost(OutputPostViewModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.postServices.editPost(model);

            return this.Redirect("/");
        }

        [HttpGet("/posts/create")]
        public IActionResult CreatePost()
        {
            return this.View();
        }

        [HttpPost("/posts/create")]
        public IActionResult CreatePost(PostViewModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();

            }

            byte[] img = new byte[0];

            if (post.Img != null)
            {
                if (post.Img.Length > 0)
                {

                    byte[] p1 = null;
                    using (var fs1 = post.Img.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    img = p1;
                }
            }


            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.postServices.createPost(post, userId, img);

            return this.Redirect("/");

        }

        [HttpGet("/communities/create")]
        public IActionResult CreateCommunity()
        {
            return this.View();
        }

        [HttpPost("/communities/create")]
        public IActionResult CreateCommunity(CommunityViewModel com)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.communityService.CreateCommunity(com, userId);
            return this.RedirectToAction("Communities", "Community");
        }

        public async Task<IActionResult> ViewCommunity(string communityName)
        {
            if (communityName == null)
            {
                return NotFound();
            }

            var community = await db.communities.FirstOrDefaultAsync(c => c.name == communityName);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        [HttpGet]
        public IActionResult JoinCommunity()
        {
            return this.Redirect("/");
        }
        [HttpPost]
        public IActionResult JoinCommunity(CommunityViewModel model)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = userServices.getUserById(userId);
            //communityService.JoinCommunity(user, model.id);
            return this.Redirect("/");
        }
        [HttpPost]
        public IActionResult DeletePost(OutputPostViewModel post)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = this.userServices.getUserNameById(userId);

            Console.WriteLine(userName, post.userName, User.Identity.Name);

            if (userName != post.userName)
            {
                return this.Redirect("/");
            }

            this.postServices.deletePost(post.id);

            return this.Redirect("/");
        }
    }
}