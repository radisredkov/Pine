using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pine.Data.Identity;

namespace Pine.Data.Entities
{
    public class Post
    {
        public Post()
        {
            this.id = Guid.NewGuid().ToString();
        }

        [Key]
        [ForeignKey("PostId")]
        public string id { get; set; }
        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        public string tags { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime timeOfCreation { get; set; }

        public string creatorId { get; set; }

        [ForeignKey("UserId")]
        public virtual User creator { get; set; }

        public List<Comment> comments { get; set; }

        //public int likes { get; set; }
        //public string file { get; set; }
    }
}
