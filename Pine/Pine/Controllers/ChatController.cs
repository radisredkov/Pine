﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
using Pine.Models.Entities;
using Pine.Services;
using Pine.Hubs;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Pine.Controllers
{

    public class ChatController : Controller
    {
        //private readonly IUserServices userServices;
        //private readonly IChatService chatService;
        //private IHubContext<ChatHub> _chat;


        //private readonly PineContext db;

        //public ChatController(IUserServices userServices, IChatService chatService, PineContext context,
        //    IHubContext<ChatHub> chat)
        //{
        //    this.chatService = chatService;
        //    this.userServices = userServices;
        //    this._chat = chat;
        //    this.db = context; 
        //}
        //[HttpPost("[action]/{connectionId}/{chatName}")]
        // string connectionId,
        //public async Task<IActionResult> JoinChat(string userId)
        //{
        //    User currentUser = userServices.getUserByUserName(User.Identity.Name);
        //    User messagedUser = userServices.getUserById(userId);
        //    List<User> users = new List<User>();
        //    users.Add(messagedUser);
        //    users.Add(currentUser);
        //    string chatName = $"{currentUser.UserName} - {messagedUser.UserName}";
        //    chatService.CreateChat(users, chatName);


        //  //  await _chat.Groups.AddToGroupAsync(connectionId,chatName);
        //     return RedirectToAction("ChatsView", "Chat");
        //}
        //[HttpPost("[action]/{connectionId}/{chatName}")]
        //public async Task<IActionResult> LeaveChat(string connectionId, string chatName)
        //{
        //    await _chat.Groups.RemoveFromGroupAsync(connectionId, chatName);
        //    return Ok();
        //}

        //[HttpPost("[action]/{connectionId}/{chatName}")]
        //public async Task<IActionResult> SendMessage(string message, string chatName, string chatId,
        //    [FromServices] PineContext ctx)
        //{
        //    var newMessage = new Message
        //    {
        //        chatId = chatId,
        //        text = message,
        //        senderName = User.Identity.Name,
        //        time = DateTime.Now
        //    };
        //    ctx.messages.Add(newMessage);
        //    await ctx.SaveChangesAsync();

        //    await _chat.Clients.Group(chatName)
        //        .SendAsync("RecieveMessage", new { 
        //        Text = newMessage.text,
        //        Name = newMessage.senderName,
        //        Time = newMessage.time.ToString("dd/MM/yyyy hh:mm")
        //        });
        //    return Ok();
        //}

        //public IActionResult CreateChat(string userId)
        //{
        //    User currentUser = userServices.getUserByUserName(User.Identity.Name);
        //    User messagedUser = userServices.getUserById(userId);
        //    List<User> users = new List<User>();
        //    users.Add(messagedUser);
        //    users.Add(currentUser);
        //    string name = $"{currentUser.UserName} - {messagedUser.UserName}";

        //    chatService.CreateChat(users, name);
        //    return RedirectToAction("ChatsView", "Chat");
        //}

        //public IActionResult ChatsView()
        //{
        //    ChatsViewModel chatsModel = new ChatsViewModel();

        //    if (db.chats.Count() != 0)
        //    {
        //        var user = userServices.getUserByUserName(User.Identity.Name);
        //        var chats = new List<Chat>();
        //        var AllChats = chatService.GetAllChats();

        //        foreach (var chat in AllChats)
        //        {
        //            if (chat.usersInChat.Contains(user))
        //            {
        //                chats.Add(chat);
        //            }
        //        }
        //        //Do we need this? -- Start
        //         chatsModel = new ChatsViewModel()
        //         {
        //            chats = chats.Select(c => new Chat
        //            {
        //                id = c.id,
        //                messages = c.messages,
        //                name = c.name,
        //                usersInChat = c.usersInChat
        //             }).ToList()
        //         };
        //        //Do we need this? -- End

        //        return View(chatsModel);
        //    }

        //    return View(chatsModel);
        //}

        //public async Task<IActionResult> Chat(string chatId)
        // {
        //    var chat = chatService.GetChatById(chatId);

        //    return View(chat);
        //}
        //[HttpGet]
        //public IActionResult SendMessage(string chatid)
        //{
        //    TempData["chatId"] = chatid;
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult SendMessage(Message message, string chatId)
        //{

        //    chatService.SendMessage(message.text, chatId, User.Identity.Name);
        //    return RedirectToAction("Chat", "Chat", new { chatId = chatId });
        //}
        //[HttpGet]
        //public IActionResult ChatsView()
        //{
        //    return View();
        //}


        private IChatRepository _repo;
        public ChatController(IChatRepository repo) => _repo = repo;
        public IActionResult ChatsView()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            var chats = _repo.GetChats(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return View(chats);
        }

        //WE MAY USE THIS IN THE FUTURE

        //public IActionResult Find([FromServices] PineContext _context)
        //{
        //    var users = _context.Users
        //        .Where(x => x.Id != User.FindFirst(ClaimTypes.NameIdentifier).Value)
        //        .ToList();

        //    return View(users);
        //}



        [HttpGet("{id}")]
        public IActionResult Chat(string id)
        {
            return View(_repo.GetChat(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            await _repo.CreateChat(name, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> JoinRoom(string id)
        {
            await _repo.JoinChat(id, User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return RedirectToAction("Chat", "Home", new { id = id });
        }

        public async Task<IActionResult> SendMessage(
            string roomId,
            string message,
            [FromServices] IHubContext<ChatHub> chat)
        {
            var Message = await _repo.CreateMessage(roomId, message, User.Identity.Name);

            await chat.Clients.Group(roomId.ToString())
                .SendAsync("RecieveMessage", new
                {
                    Text = Message.text,
                    Name = Message.name,
                    Timestamp = Message.timestamp.ToString("dd/MM/yyyy hh:mm:ss")
                });

            return Ok();
        }


    }
}