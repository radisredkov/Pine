using Microsoft.AspNetCore.Identity;
using Pine.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pine.Data.Identity
{
    public class User : IdentityUser
    {
        public User()
        {
            this.CommunitiesJoined = new HashSet<Community>();
            this.posts = new List<Post>();
        }

        [Key]
        [ForeignKey("UserId")]
        public override string Id { get => base.Id; set => base.Id = value; }
      
       
        public string postId { get; set; }
        [ForeignKey("postId")]
        public virtual List<Post> posts { get; set; }

        public virtual ICollection<Community> CommunitiesJoined { get; set; }

        [ForeignKey("ListingId")]
        public List<ShopListing> listings { get; set; }

        //   public List<Community> communitiesOwned { get; set; }
    }
}
