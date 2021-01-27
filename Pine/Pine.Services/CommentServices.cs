using Pine.Data;
using Pine.Data.Entities;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class CommentServices : ICommentServices
    {

        private PineContext db;

        public CommentServices(PineContext db)
        {
            this.db = db;
        }
        public void createComment(InputComment commentModel, string userId, byte[] img)
        {
            var postToComment = db.posts.FirstOrDefault(p => p.id == commentModel.postId);
            Comment comment = new Comment
            {
                content = commentModel.content,
                post = postToComment,
                timeOfCreation = DateTime.Now,
                commentaor = db.Users.FirstOrDefault(u => u.Id == userId),
                commentatorId = userId,
                Img = img
            };

            postToComment.comments.Add(comment);
            db.comments.Add(comment);
            db.SaveChanges();
        }

        public void deleteComment(string commentId)
        {
            Comment toDelete = db.comments.FirstOrDefault(c => c.id == commentId);

            db.comments.Remove(toDelete);
            db.SaveChanges();
        }

        public ICollection<Comment> getAllComments(string postId)
        {
            return db.comments.Where(c => c.post.id == postId).ToList();
        }
    }
}