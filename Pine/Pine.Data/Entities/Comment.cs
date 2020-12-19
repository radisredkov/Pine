using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pine.Data.Entities
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string content { get; set; }

        // public int likes { get; set; }
        // public string file { get; set; }
    }
}
