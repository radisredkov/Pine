using Pine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class ChatsViewModel
    {
        public ICollection<Chat> chats { get; set; }
    }
}