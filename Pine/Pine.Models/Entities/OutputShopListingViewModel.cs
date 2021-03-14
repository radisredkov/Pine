using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Models.Entities
{
    public class OutputShopListingViewModel
    {
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string description { get; set; }

        public string creatorId { get; set; }
        public string creatorName { get; set; }

        [Required]
        public byte[] img { get; set; }
        public DateTime uploadDate { get; set; }
    }
}
