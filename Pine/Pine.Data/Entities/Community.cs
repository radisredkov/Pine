using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamDeliriumProject.Data.Entities
{
    public class Community
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        // [FK]
        public string ownerId { get; set; }

        public string communityMembers { get; set; }

        // public string posts { get; set; }
    }
}
