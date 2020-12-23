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

        [Required]
        public string keywords { get; set; }
    }
}
