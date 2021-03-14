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
        [ForeignKey("CommunityId")]
        public string id { get; set; }
        [Required]
        public string name { get; set; }

        public string? description { get; set; }

        public string tags { get; set; }

        public string ownerId { get; set; }

        [ForeignKey("ownerId")]
        public virtual User Owner { get; set; }

        public virtual ICollection<Post> communityPosts { get; set; } = new List<Post>();

        public virtual ICollection<User> communityMembers { get; set; } = new List<User>();

        public string moderatorName { get; set; }
        [ForeignKey("moderatorName")]
        public virtual ICollection<User> communityModerators { get; set; } = new List<User>();

        public bool isPrivate { get; set; }

        public bool isAnonymous { get; set; }

        public byte[] communityCss { get; set; }
    }
}