﻿using Microsoft.AspNetCore.Http;
using Pine.Data.Entities;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services
{
    public interface IPostServices
    {
        void createPost(PostViewModel model, string userId, byte[] img, string comId = null);

        void editPost(OutputPostViewModel model, byte[] img = null );

        void deletePost(string postId);

        ICollection<Post> getAllPosts();
    }
}