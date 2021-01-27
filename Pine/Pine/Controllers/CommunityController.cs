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
        private readonly IFileService fileService;
        private readonly ICommentServices commentServices;

        private readonly PineContext db; 

        public CommunityController(IPostServices postServices, IUserServices userServices, 
            ICommunityServices communityService, IFileService fileService, ICommentServices commentServices, PineContext context)
        {
            this.postServices = postServices;
            this.userServices = userServices;
            this.communityService = communityService;
            this.fileService = fileService;
            this.commentServices = commentServices;
            this.db = context;
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
                    description = c.description,
                    isPrivate = c.isPrivate
                }).OrderBy(c => c.name).ToList()
            };

            return View("Communities", model);
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
                   break;
               default:
                   this.postServices.createPost(post, userId, img, TempData["CommunityId"].ToString());
                   break;
           }
            TempData.Clear();
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
        public async Task<IActionResult> Community(string communityName)
        {
            var community = communityService.getCommunityByName(communityName);

            community.communityPosts = db.posts.Where(p => p.communityId == community.id).ToList();
            community.communityMembers = db.communities.FirstOrDefault(c => c.id == community.id).communityMembers;

            ICollection<Post> posts = community.communityPosts;
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

            var tuple = new Tuple<Community, PostsViewModel>(community, model);
            return View(tuple);
        }
        public IActionResult JoinCommunity(string communityName)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = userServices.getUserById(userId);
            Community com = communityService.getCommunityByName(communityName);
            communityService.JoinCommunity(user, com);
            return RedirectToAction("Communities","Community");
        }

        //This should be in PostController class
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
                    comments = commentServices.getAllComments(p.id).Select(c => new OutputCommentViewModel
                   {
                       id = c.id,
                       commentaor = c.commentaor,
                       content = c.content,
                       timeOfCreation = c.timeOfCreation,
                       img = c.Img,
                       //userName = userServices.getUserNameById(c.commentaor.Id)
                    }).OrderBy(c => c.timeOfCreation).ToList()
                }).OrderBy(p => p.uploadDate).ToList()
            };

            return View("AllPosts", model);
        }

        [HttpPost]
        public IActionResult CreateComment(InputComment comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            byte[] img = fileService.ConvertToByte(comment.Img);

            this.commentServices.createComment(comment, userId, img);

            return this.Redirect("/");
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
    }
}