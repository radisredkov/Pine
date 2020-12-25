using Pine.Data;
using Pine.Data.Entities;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class PostServices : IPostServices
    {

        private PineContext db;

        public PostServices(PineContext db)
        {
            this.db = db;
        }

        public void createPost(PostViewModel model, string userId)
        {
            Post post = new Post
            {
                title = model.title,
                description = model.description,
                keywords = model.keywords,
                timeOfCreation = DateTime.Now,
                creatorId = userId,
                creator = db.Users.FirstOrDefault(u => u.Id == userId),
                comments = new List<Comment>()
            };

            
            db.posts.Add(post);
            db.SaveChanges();
        }

        public void editPost(OuputPostViewModel model)
        {
            var oldPost = db.posts.FirstOrDefault(p => p.id == model.id);

            oldPost.title = model.title;
            oldPost.keywords = model.keywords;
            oldPost.description = model.description;
            oldPost.timeOfCreation = DateTime.Now;

            db.posts.Update(oldPost);
            db.SaveChanges();
            
        }


        public void deletePost(string postId)
        {
            Post todeletePost = db.posts.FirstOrDefault(p => p.id == postId);

            db.posts.Remove(todeletePost);
            db.SaveChanges();
        }

        public ICollection<Post> getAllPosts()
        {
            return db.posts.ToList();
        }
    }
}
