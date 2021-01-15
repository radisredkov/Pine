using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Models.Entities
{
    public class PostViewModel
    {
        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }
        public string communityId { get; set; }

        public string tags { get; set; }

        public IFormFile Img { get; set; }
    }
}
