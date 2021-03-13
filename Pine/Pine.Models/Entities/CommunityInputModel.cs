using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Models.Entities
{
    public class CommunityInputModel
    {
        [Required]
        public string communityDescription { get; set; }

        public IFormFile communityCss { get; set; }

        public string communityName { get; set; }

        public string moderatorName { get; set; }
    }
}