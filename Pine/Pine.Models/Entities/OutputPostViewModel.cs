using Microsoft.AspNetCore.Http;
using Pine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class OutputPostViewModel
    {
        public string communityId;

        public string id { get; set; }

        public string title { get; set; }

        public string tags { get; set; }

        public string description { get; set; }
        public string creatorId { get; set; }

        public string userName { get; set; }

        public byte[] img { get; set; }
        public IFormFile imgRecived { get; set; }

        public DateTime uploadDate { get; set; }

        public ICollection<OutputCommentViewModel> comments { get; set; }

        public string moderatorName { get; set; }
    }
}