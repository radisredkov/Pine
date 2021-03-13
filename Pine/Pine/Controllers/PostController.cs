using Microsoft.AspNetCore.Mvc;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Models.Entities;
using Pine.Services;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pine.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostServices postServices;
        private readonly IUserServices userServices;
        private readonly ICommunityServices communityService;
        private readonly IFileService fileService;
        private readonly ICommentServices commentServices;

        private readonly PineContext db;

        public PostController(IPostServices postServices, IUserServices userServices,
            ICommunityServices communityService, IFileService fileService, ICommentServices commentServices, PineContext context)
        {
            this.postServices = postServices;
            this.userServices = userServices;
            this.communityService = communityService;
            this.fileService = fileService;
            this.commentServices = commentServices;
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
                    uploadDate = p.timeOfCreation,
                    communityId = p.communityId,
                    inAnonymousCommunity = p.inAnonymousCommunity,
                    comments = commentServices.getAllComments(p.id).Select(c => new OutputCommentViewModel
                    {
                        id = c.id,
                        commentaor = userServices.getUserById(c.commentatorId),
                        content = c.content,
                        timeOfCreation = c.timeOfCreation,
                        img = c.Img,
                        //userName = userServices.getUserNameById(c.commentaor.Id)
                    }).OrderBy(c => c.timeOfCreation).ToList()
                }).OrderByDescending(p => p.uploadDate).ToList()
            };

            return View("AllPosts", model);
        }

        [HttpGet("/posts/communityId/create")]
        public IActionResult CreatePost(string communityId)
        {
            switch (communityId)
            {
                case null:
                    TempData["CommunityId"] = "empty";
                    break;
                default:
                    TempData["CommunityId"] = communityId;
                    break;
            }
            return View();
        }

        [HttpPost("/posts/communityId/create")]
        public IActionResult CreatePost(PostViewModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            byte[] img = fileService.ConvertToByte(post.Img);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string commId = TempData["CommunityId"].ToString();

            switch (commId)
            {
                case "empty":
                    this.postServices.createPost(post, userId, img);
                    return Redirect("/");
                default:
                    this.postServices.createPost(post, userId, img, TempData["CommunityId"].ToString());
                    return this.RedirectToAction("Community", "Community", new { communityName = communityService.getCommunityById(TempData["CommunityId"].ToString()).name });
            }
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

            this.postServices.deletePost(post.id);

            return this.Redirect("/");
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
        public IActionResult EditPost(OutputPostViewModel post)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.postServices.editPost(post, fileService.ConvertToByte(post.imgRecived));

            return this.Redirect("/");
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
                    uploadDate = p.timeOfCreation,
                    communityId = p.communityId,
                    inAnonymousCommunity = p.inAnonymousCommunity,
                    comments = commentServices.getAllComments(p.id).Select(c => new OutputCommentViewModel
                    {
                        id = c.id,
                        commentaor = c.commentator,
                        content = c.content,
                        timeOfCreation = c.timeOfCreation,
                        img = c.Img,
                        //userName = userServices.getUserNameById(c.commentaor.Id)
                    }).OrderBy(c => c.timeOfCreation).ToList()
                }).OrderBy(p => p.uploadDate).ToList()
            };
            return View("AllPosts", model);
        }
    }
}