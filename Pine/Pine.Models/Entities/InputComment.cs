using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Models.Entities
{
    public class InputComment
    {
        public string postId { get; set; }

        [Display(Name="Comment")]
        [Required]
        public string content { get; set; }

        public IFormFile Img { get; set; }
    }
}