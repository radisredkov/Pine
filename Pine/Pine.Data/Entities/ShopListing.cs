using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Pine.Data.Entities;
using Pine.Data.Identity;

namespace Pine.Data.Entities
{
    public class ShopListing
    {
        public ShopListing()
        {
            this.id = Guid.NewGuid().ToString();
        }

        [Key]
        [ForeignKey("ShopListingId")]
        public string id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public double price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime timeOfCreation { get; set; }

        public string creatorId { get; set; }

        [ForeignKey("creatorId")]
        public virtual User creator { get; set; }

        //public string picture { get; set; }
    }
}
