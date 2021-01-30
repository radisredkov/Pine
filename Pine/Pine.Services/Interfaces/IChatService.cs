using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services.Interfaces
{
    public interface  IChatService
    {
        public void CreateChat(List<User> users, string name );

        public void SendMessage(string message, string chatId);

    }
}
