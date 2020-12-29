using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class CommunityViewModel
    {
      
        public string name { get; set; }
        public string description { get; set; }
        //public string tags { get; set; }
        public string ownerId { get; set; }

        public IFormFile backgroundImg { get; set; }

    }
}
