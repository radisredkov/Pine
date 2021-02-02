using Microsoft.EntityFrameworkCore;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class ChatService : IChatService
    {
        private PineContext db;

        public ChatService(PineContext db)
        {
            this.db = db;
        }
        public void CreateChat(List<User> users, string name)
        {

            Chat chat = new Chat
            {
                usersInChat = users,
                name = name,
                messages = new List<Message>()
            };

            db.chats.Add(chat);
            db.SaveChanges();
        }

        public List<Chat> GetAllChats()
        {
            return db.chats.Include(ch => ch.usersInChat).Include(ch => ch.messages).ToList();
           
        }

        public Chat GetChatById(string id)
        {
            return GetAllChats().Find(ch => ch.id == id);
        }

        public void SendMessage(string message, string chatId, string senderName)
        {

            Message newMessage = new Message
            {
                text = message,
                senderName = senderName,
                time = DateTime.Now
            };

            db.chats.Find(chatId).messages.Add(newMessage);
            db.SaveChanges();
        }
    }
}
