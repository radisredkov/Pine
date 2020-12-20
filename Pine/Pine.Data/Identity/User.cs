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
        [Key]
        [ForeignKey("UserId")]
        public override string Id { get => base.Id; set => base.Id = value; }

        [ForeignKey("PostId")]
        public List<Post> posts { get; set; }

        //   public List<Community> communitiesOwned { get; set; }
    }
}
