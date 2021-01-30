using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Data.Entities
{
    public class UserChat
    {
        public string userId { get; set; }
        public User users { get; set; }
        public string chatId { get; set; }
        public Chat chats { get; set; }

    }
}
