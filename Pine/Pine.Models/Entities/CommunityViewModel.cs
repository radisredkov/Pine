using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Models.Entities
{
    public class CommunityViewModel
    {
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public ICollection<PostsViewModel> posts {get;set;}
        public string ownerId { get; set; }
        public IFormFile backgroundImg { get; set; }
        public bool isPrivate { get; set; }
        public bool isAnonymous { get; set; }
    }
}