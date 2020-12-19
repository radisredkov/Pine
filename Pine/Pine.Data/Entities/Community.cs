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
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [ForeignKey("ownerId")]
        public string ownerId { get; set; }

        [ForeignKey("communityMembers")]
        public List<User> communityMembers { get; set; }

        public List<Post> posts { get; set; }
    }
}
