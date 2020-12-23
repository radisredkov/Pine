using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pine.Data.Entities;
using Pine.Models.Entities;
using Pine.Services;

namespace Pine.Controllers
{
    public class CommunityController : Controller
    {

        private readonly IPostServices postServices;
        private readonly IUserServices userServices;

        public CommunityController(IPostServices postServices, IUserServices userServices)
        {
            this.postServices = postServices;
            this.userServices = userServices;
        }

        
        public IActionResult AllPosts()
        {
            ICollection<Post> posts = postServices.getAllPosts();
            PostsViewModel model = new PostsViewModel() {

                posts = posts.Select(p => new OuputPostViewModel
                {
                    id = p.id,
                    title = p.title,
                    description = p.description,
                    keywords = p.keywords,
                    userName = userServices.getUserNameById(p.creatorId),
                    uploadDate = p.timeOfCreation
                }).ToList()

            };

            model.posts.Reverse();

            return View("AllPosts", model);
        }

        [HttpGet("/posts/create")]
        public IActionResult CreatePost()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost("/posts/create")]
        public IActionResult CreatePost(PostViewModel post)
        {

            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.postServices.createPost(post, userId);

            return this.Redirect("/");

        }

        [HttpPost]
        public IActionResult DeletePost(OuputPostViewModel post)
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

            if(userName != post.userName)
            {
                return this.Redirect("/");
            }

            this.postServices.deletePost(post.id);

            return this.Redirect("/");

        }

        public IActionResult Communities()
        {
            return View();
        }
    }
}
