using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class UserPanelInputModel
    {
        public string userDescription { get; set; }
        public IFormFile profilePicture { get; set; }
    }
}