using Microsoft.AspNetCore.Mvc;
using Pine.Data;
using Pine.Services;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pine.Controllers
{
    public class ChatController : Controller
    {

        private readonly IUserServices userServices;


        private readonly PineContext db;

        public ChatController(IUserServices userServices,PineContext context)
        {
            this.userServices = userServices;
            this.db = context;
        }

        public IActionResult CreateChat(string userId)
        {
            string currnetUserId = userServices.getUserByUserName(User.Identity.Name.ToString());
            return View();
        }
    }
}
