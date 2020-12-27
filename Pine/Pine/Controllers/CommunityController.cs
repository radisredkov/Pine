﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

            public IActionResult Communities()
            {
                return View();
            }
        }
    }