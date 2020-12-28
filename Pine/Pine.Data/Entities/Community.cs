using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pine.Data.Identity;

namespace Pine.Data.Entities
{
    public class Community
    {
        public Community()
        {
            this.id = Guid.NewGuid().ToString();
        }

        [Key]
        public string id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        public string tags { get; set; }

        [ForeignKey("UserID")]
        public string ownerId { get; set; }

        [ForeignKey("UserID")]
        public List<User> communityMembers { get; set; }
        [ForeignKey("PostId")]
        public List<Post> posts { get; set; }
    }
}
