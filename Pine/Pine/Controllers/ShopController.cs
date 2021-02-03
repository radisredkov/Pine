using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pine.Data.Entities;
using Pine.Models.Entities;
using Pine.Services;

namespace Pine.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopListingService shopListingService;
        private readonly IUserServices userServices;

        public ShopController(IShopListingService shopListingService, IUserServices userServices)
        {
            this.shopListingService = shopListingService;
            this.userServices = userServices;
        }

        [HttpGet("/Shop")]
        public IActionResult Shop()
        {
            ICollection<ShopListing> listings = shopListingService.getAllListings();
            ShopListingsViewModel model = new ShopListingsViewModel()
            {
                listings = listings.Select(l => new OutputShopListingViewModel
                {
                    id = l.id,
                    name = l.name,
                    description = l.description,
                    price = l.price,
                    creatorName = userServices.getUserNameById(l.creatorId),
                    creatorId = l.creatorId,
                    uploadDate = l.timeOfCreation
                }).OrderByDescending(l => l.uploadDate).ToList()
            };

            return View("Shop", model);
        }

        [HttpGet("/Shop/orderbypricedescending")]
        public IActionResult ShopHighToLow()
        {
            ICollection<ShopListing> listings = shopListingService.getAllListings();
            ShopListingsViewModel model = new ShopListingsViewModel()
            {
                listings = listings.Select(l => new OutputShopListingViewModel
                {
                    id = l.id,
                    name = l.name,
                    description = l.description,
                    price = l.price,
                    creatorName = userServices.getUserNameById(l.creatorId),
                    creatorId = l.creatorId,
                    uploadDate = l.timeOfCreation
                }).OrderByDescending(l => l.price).ToList()
            };

            return View("Shop", model);
        }
        [HttpGet("/Shop/orderbypriceascending")]
        public IActionResult ShopLowToHigh()
        {
            ICollection<ShopListing> listings = shopListingService.getAllListings();
            ShopListingsViewModel model = new ShopListingsViewModel()
            {
                listings = listings.Select(l => new OutputShopListingViewModel
                {
                    id = l.id,
                    name = l.name,
                    description = l.description,
                    price = l.price,
                    creatorName = userServices.getUserNameById(l.creatorId),
                    creatorId = l.creatorId,
                    uploadDate = l.timeOfCreation
                }).OrderBy(l => l.price).ToList()
            };

            return View("Shop", model);
        }

        [HttpGet("/listings/edit")]
        public IActionResult EditListingView(OutputShopListingViewModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return View("EditListing", model);
        }

        [HttpPost("/listings/edit")]
        public IActionResult EditListing(OutputShopListingViewModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.shopListingService.editListing(model);

            return this.RedirectToAction("Shop", "Shop");
        }

        [HttpGet("/listings/create")]
        public IActionResult CreateListing()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Content("You must be logged in in order to do this.");
            }

            return this.View();
        }

        [HttpPost("/listings/create")]
        public IActionResult CreateListing(ShopListingViewModel listing)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Content("You must be logged in in order to do this.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.shopListingService.createListing(listing, userId);

            return this.RedirectToAction("Shop", "Shop");
        }

        [HttpPost]
        public IActionResult DeleteListing(OutputShopListingViewModel listing)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = this.userServices.getUserNameById(userId);

            Console.WriteLine(userName, listing.creatorName, User.Identity.Name);

            if (userName != listing.creatorName)
            {
                return this.Redirect("/");
            }

            this.shopListingService.deleteListing(listing.id);

            return this.RedirectToAction("Shop", "Shop");
        }
        
        public IActionResult BuyListing()
        {
            return View();
        }
    }
}