using Pine.Data;
using Pine.Data.Entities;
using Pine.Models.Entities;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class ShopListingService : IShopListingService
    {
        private PineContext db;
        private readonly IFileService fileService;

        public ShopListingService(PineContext db, IFileService fileService)
        {
            this.db = db;
            this.fileService = fileService;
        }

        public void createListing(ShopListingViewModel model, string userId)
        {
            ShopListing listing = new ShopListing
            {
                name = model.name,
                description = model.description,
                price = model.price,
                timeOfCreation = DateTime.Now,
                creatorId = userId,
                Img = fileService.ConvertToByte(model.img),
                creator = db.Users.FirstOrDefault(u => u.Id == userId)
            };

            db.listings.Add(listing);
            db.SaveChanges();
        }

        public void editListing(OutputShopListingViewModel model)
        {
            var oldListing = db.listings.FirstOrDefault(l => l.id == model.id);

            oldListing.name = model.name;
            oldListing.price = model.price;
            oldListing.description = model.description;
            oldListing.timeOfCreation = DateTime.Now;
            //oldListing.Img = fileService.ConvertToByte(model.img);

            db.listings.Update(oldListing);
            db.SaveChanges(); 
        }

        public void deleteListing(string listingId)
        {
            ShopListing listingToDelete = db.listings.FirstOrDefault(l => l.id == listingId);

            db.listings.Remove(listingToDelete);
            db.SaveChanges();
        }

        public ICollection<ShopListing> getAllListings()
        {
            return db.listings.ToList();
        }
    }
}
