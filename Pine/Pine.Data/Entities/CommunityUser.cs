using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pine.Data.Entities
{
    public class CommunityUser
    {
        public CommunityUser()
        {
            this.id = Guid.NewGuid().ToString();
        }
        [Key]
        public string id { get; set; }
      
        public string userId { get; set; }
       
        public string communityId { get; set; }

        [ForeignKey("userId")]
        public ICollection<User> users { get; set; }
            = new List<User>();
        [ForeignKey("communityId")]
        public ICollection<Community> communityPosts { get; set; }
      = new List<Community>();

    }
}
