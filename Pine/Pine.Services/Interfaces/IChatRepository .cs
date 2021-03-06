using Pine.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pine.Services.Interfaces
{
    public interface IChatRepository
    {
        Chat GetChat(string id);
        Task CreateChat(string name, string userId);
        Task JoinChat(string chatId, string userId);
        IEnumerable<Chat> GetChats(string userId);     
        Task<Message> CreateMessage(string chatId, string message, string userId);
    }
}
