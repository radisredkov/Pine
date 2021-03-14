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
            this.posts = new HashSet<Post>();
            this.chats = new HashSet<Chat>();

        }

        [Key]
        [ForeignKey("UserId")]
        public override string Id { get => base.Id; set => base.Id = value; }
        public virtual ICollection<Chat> chats { get; set; }
        public string postId { get; set; }
        [ForeignKey("postId")]
        public ICollection<Post> posts { get; set; }

        public virtual ICollection<Community> CommunitiesJoined { get; set; }

        [ForeignKey("ListingId")]
        public List<ShopListing> listings { get; set; }

        public byte[] profilePicture { get; set; }
        public string userDescription { get; set; }
        public byte[] userCss { get; set; }

        //   public List<Community> communitiesOwned { get; set; }
    }
}