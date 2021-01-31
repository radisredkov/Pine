using Microsoft.AspNetCore.Mvc;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Models.Entities;
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
            //string currentUserId = userServices.getUserByUserName(User.Identity.Name.ToString());
            return View();
        }

        public IActionResult ChatView()
        {
            var chats = db.chats.ToList();
            var messages = db.messages.ToList(); //getAllMessages().Where(m => m.creatorId == user.Id).ToList()

            ChatsViewModel chatsModel = new ChatsViewModel()
            {
                chats = chats.Select(c => new Chat
                {
                    id = c.id,
                    messages = c.messages,
                    name = c.name,
                    usersInChat = c.usersInChat
                }).ToList()
            };

            MessagesViewModel messagesModel = new MessagesViewModel()
            {
                messages = messages.Select(m => new Message
                {
                    id = m.id,
                    text = m.text,
                    time = m.time
                }).OrderBy(m => m.time).ToList()
            };

            var tuple = new Tuple<ChatsViewModel, MessagesViewModel>(chatsModel, messagesModel);
            return View(tuple);
        }
    }
}