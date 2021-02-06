using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Models.Entities
{
    public class ShopListingViewModel
    {
        [Required]
        [DisplayName("Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string description { get; set; }

        [Required]
        [DisplayName("Price")]
        public double price { get; set; }

        public IFormFile img { get; set; }
    }
}