using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeamDeliriumProject.Data.Identity;

namespace TeamDeliriumProject.Data.Entities
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        public User creator { get; set; }

        public List<Comment> comments { get; set; }

        //public int likes { get; set; }
        //public string file { get; set; }
    }
}
