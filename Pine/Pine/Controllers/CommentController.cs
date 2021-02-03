using Microsoft.AspNetCore.Mvc;
using Pine.Data;
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
    public class CommentController : Controller
    {
        
        private readonly IUserServices userServices;
        private readonly ICommentServices commentService;
        private readonly IFileService fileService;



        private readonly PineContext db;

        public CommentController(IFileService fileService ,IUserServices userServices, ICommentServices commentService, PineContext context)
        {
            this.commentService = commentService;
            this.userServices = userServices;
            this.fileService = fileService;
            this.db = context;
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

            this.commentService.createComment(comment, userId, img);

            return this.Redirect("/");
        }
    }
}
