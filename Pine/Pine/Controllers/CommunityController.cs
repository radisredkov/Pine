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
                   
            ICollection<Post> posts =  community.communityPosts;
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
                        commentaor = c.commentator,
                        content = c.content,
                        timeOfCreation = c.timeOfCreation,
                        img = c.Img,
                        userName = c.commentator.UserName
                    }).OrderBy(c => c.timeOfCreation).ToList()
                }).OrderByDescending(p => p.uploadDate).ToList()
            };

            var tuple = new Tuple<Community, PostsViewModel>(community, model);
            return View(tuple);
        }
        public IActionResult JoinCommunity(string communityName)
        {
            string userName = this.User.Identity.Name;
            User user = userServices.getUserByUserName(userName);
            Community com = communityService.getCommunityByName(communityName);
            communityService.JoinCommunity(user, com);
            return RedirectToAction("Communities", "Community");
        }

        public IActionResult EditCommunity(CommunityInputModel community)
        {
            Community com = communityService.getCommunityByName(community.communityName);
            communityService.EditCommunity(com, community);
            return RedirectToAction("Community", "Community", new { communityName = community.communityName });
        }

        public IActionResult AddModerator(string communityName, CommunityInputModel model)
        {
            Community com = communityService.getCommunityByName(communityName);
            User moderator = userServices.getUserByUserName(model.moderatorName);
            communityService.AddModerator(com, moderator);
            return RedirectToAction("Community", "Community", new { communityName = communityName });
        }
        public IActionResult RemoveModerator(string communityName, CommunityInputModel model)
        {
            Community com = communityService.getCommunityByName(communityName);
            User moderator = userServices.getUserByUserName(model.moderatorName);
            communityService.RemoveModerator(com, moderator);
            return RedirectToAction("Community", "Community", new { communityName = communityName });
        }


     
    }
}