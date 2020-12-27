using Pine.Data.Entities;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services
{
    public interface IPostServices
    {
        void createPost(PostViewModel model, string userId, byte[] img);

        void editPost(OutputPostViewModel model);

        void deletePost(string postId);

        ICollection<Post> getAllPosts(); 
    }
}
