﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Pine.Data.Entities;

namespace Pine.Data.Entities
{
    class ShopListing : Post
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ownerId")]
        public int ownerId { get; set; }

        //public string picture { get; set; }

        public double price { get; set; }

        public string address { get; set; }
    }
}