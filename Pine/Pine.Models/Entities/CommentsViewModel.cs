using Pine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class CommentsViewModel
    {
        public ICollection<Comment> comments { get; set; }
    }
}