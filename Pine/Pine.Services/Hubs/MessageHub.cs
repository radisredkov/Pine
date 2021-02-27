using Microsoft.AspNetCore.SignalR;
using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pine.Services.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
