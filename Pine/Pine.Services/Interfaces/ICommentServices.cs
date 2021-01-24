using Pine.Data.Entities;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services
{
    public interface ICommentServices
    {
        public void createComment(InputComment commentModel, string userId, byte[] img);

        //public void editComment(string commentId, string userId);

        public void deleteComment(string commentId);

        public ICollection<Comment> getAllComments(string postId);
    }
}