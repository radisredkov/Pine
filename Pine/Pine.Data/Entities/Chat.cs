using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Data.Entities
{
    public class Chat
    {
        public Chat()
        {
            this.id = Guid.NewGuid().ToString();
            usersInChat = new List<User>();
            messages = new List<Message>();

        }
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public ICollection<User> usersInChat { get; set; }
        public ICollection<Message> messages { get; set; }

    }
}
