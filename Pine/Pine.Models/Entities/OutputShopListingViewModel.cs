using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class OutputShopListingViewModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public string description { get; set; }

        public string userName { get; set; }

        public DateTime uploadDate { get; set; }
    }
}
