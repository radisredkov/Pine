using Microsoft.AspNetCore.Http;
using Pine.Data.Entities;
using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class OutputCommentViewModel
    {
        public string id { get; set; }
        public string content { get; set; }
        public DateTime timeOfCreation { get; set; }
        public User commentaor { get; set; }
        public string userName { get; set; }
        public Post post { get; set; }
        public byte[] img { get; set; }
        public IFormFile imgReceived { get; set; }
    }
}