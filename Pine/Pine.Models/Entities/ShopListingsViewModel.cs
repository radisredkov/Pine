using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class ShopListingsViewModel
    {
        public ICollection<OutputShopListingViewModel> listings { get; set; }
    }
}