using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public void SendMessage(string message, string chatId)
        {

            Message newMessage = new Message
            {
                text = message,
                time = DateTime.Now
            };

            db.chats.Find(chatId).messages.Add(newMessage);
        }
    }
}
