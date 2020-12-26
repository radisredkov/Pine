using Pine.Data.Entities;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services
{
    public interface IShopListingService
    {
        void createListing(ShopListingViewModel model, string userId);

        void editListing(OutputShopListingViewModel model);

        void deleteListing(string listingId);

        ICollection<ShopListing> getAllListings(); 
    }
}