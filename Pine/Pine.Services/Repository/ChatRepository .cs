using Microsoft.EntityFrameworkCore;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pine.Services.Repostory
{
    public class ChatRepository : IChatRepository
    {
        private PineContext _context;

        public ChatRepository(PineContext context) => _context = context;

        public async Task<Message> CreateMessage(string chatId, string message, string userId)
        {
            var Message = new Message
            {
               chatId = chatId,
                text = message,
                name = userId,
                timestamp = DateTime.Now
            };

            _context.messages.Add(Message);
            await _context.SaveChangesAsync();

            return Message;
        }

        public async Task CreateChat(string name, string userId)
        {
            var chat = new Chat
            {
                name = name,
            };

            chat.users.Add(new ChatUser
            {
                userId = userId,
                
            });

            _context.chats.Add(chat);

            await _context.SaveChangesAsync();
        }

        public Chat GetChat(string id)
        {
            return _context.chats
                .Include(x => x.messages)
                .FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Chat> GetChats(string userId)
        {
            return _context.chats
                .Include(x => x.users)
                .Where(x => !x.users
                    .Any(y => y.userId == userId))
                .ToList();
        }

        public async Task JoinChat(string chatId, string userId)
        {
            var chatUser = new ChatUser
            {
                chatId = chatId,
                userId = userId,
            };

            _context.chatUsers.Add(chatUser);

            await _context.SaveChangesAsync();
        }

       
    }
}


