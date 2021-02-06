using Microsoft.AspNetCore.Mvc;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
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
        private readonly IChatService chatService;

        private readonly PineContext db;

        public ChatController(IUserServices userServices, IChatService chatService, PineContext context)
        {
            this.chatService = chatService;
            this.userServices = userServices;
            this.db = context;
        }

        public IActionResult CreateChat(string userId)
        {
            User currentUser = userServices.getUserByUserName(User.Identity.Name);
            User messagedUser = userServices.getUserById(userId);
            List<User> users = new List<User>();
            users.Add(messagedUser);
            users.Add(currentUser);
            string name = $"{currentUser.UserName} - {messagedUser.UserName}";

            chatService.CreateChat(users, name); 
            return RedirectToAction("ChatsView", "Chat");
        }

        public IActionResult ChatsView()
        {
            ChatsViewModel chatsModel = new ChatsViewModel();

            if (db.chats.Count() != 0)
            {
                var user = userServices.getUserByUserName(User.Identity.Name);
                var chats = new List<Chat>();
                var AllChats = chatService.GetAllChats();

                foreach (var chat in AllChats)
                {
                    if (chat.usersInChat.Contains(user))
                    {
                        chats.Add(chat);
                    }
                }
                //Do we need this? -- Start
                 chatsModel = new ChatsViewModel()
                 {
                    chats = chats.Select(c => new Chat
                    {
                        id = c.id,
                        messages = c.messages,
                        name = c.name,
                        usersInChat = c.usersInChat
                     }).ToList()
                 };
                //Do we need this? -- End

                return View(chatsModel);
            }

            return View(chatsModel);
        }

        public async Task<IActionResult> Chat(string chatId)
         {
            var chat = chatService.GetChatById(chatId);

            return View(chat);
        }
        [HttpGet]
        public IActionResult SendMessage(string chatid)
        {
            TempData["chatId"] = chatid;
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            string chatId = TempData["chatId"].ToString();
            chatService.SendMessage(message.text, chatId, User.Identity.Name);
            TempData.Clear();
            return RedirectToAction("Chat", "Chat", new { chatId = chatId});
        }
    }
}