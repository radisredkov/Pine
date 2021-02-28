using Microsoft.AspNetCore.Http;
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
        private readonly PineContext _context;
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


        public string GetConnectionId() =>
           Context.ConnectionId;
        

        //private IDatabaseManager DatabaseManager
        //{
        //    get
        //    {
        //        return this.serviceProvider.GetRequiredService<IDatabaseManager>();
        //    }
        //}
        //public async Task JoinChatRoom(string chatRoomName)
        //{
        //    await this.Groups.AddToGroupAsync(chatRoomName).ConfigureAwait(false);

        //    Dictionary<string, string> messages = await this.DatabaseManager.GetChatHistory(chatRoomName).ConfigureAwait(false);

        //    await this.Clients.Group(chatRoomName).BroadcastMessageAsync(messages);
        //}
        //public async Task SendMessageToRoom(string message, string chatRoomName)
        //{
        //    await this.DatabaseManager.SaveChatHistory(chatRoomName, message).ConfigureAwait(false);

        //    await this.Clients.Group(chatRoomName).BroadcastMessageAsync(message);
        //}

        //public override System.Threading.Tasks.Task OnConnected()
        //{
        //    // Get UserID. Assumed the user is logged before connecting to chat and userid is saved in session.
        //    string UserID = (string)HttpContext.Current.Session["userid"];
            
        //    // Get ChatHistory and call the client function. See below
        //    this.GetHistory(UserID);

        //    // Get ConnID
        //    string ConnID = Context.ConnectionId;

        //    // Save them in DB. You got to create a DB class to handle this. (Optional)
        //    _context.UpdateConnID(UserID, ConnID);
        //}

        //private void GetHistory(UserID)
        //{
        //    // Get Chat History from DB. You got to create a DB class to handle this.
        //    string History = DB.GetChatHistory(UserID);

        //    // Send Chat History to Client. You got to create chatHistory handler in Client side.
        //    Clients.Caller.chatHistory(History);
        //}

        //// This method is to be called by Client 
        //public void Chat(string Message)
        //{
        //    // Get UserID. Assumed the user is logged before connecting to chat and userid is saved in session.
        //    string UserID = (string)HttpContext.Current.Session["userid"];

        //    // Save Chat in DB. You got to create a DB class to handle this
        //    DB.SaveChat(UserID, Message);

        //    // Send Chat Message to All connected Clients. You got to create chatMessage handler in Client side.
        //    Clients.All.chatMessage(Message);
        //}
    }
}
