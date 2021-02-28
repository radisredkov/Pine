using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pine.Data.Entities
{
    public class Chat
    {
        public Chat()
        {
            this.id = Guid.NewGuid().ToString();
            usersInChat = new HashSet<User>();
            messages = new HashSet<Message>();

        }
        [Key]
        [ForeignKey("ChatId")]
        public string id { get; set; }
        public string name { get; set; }

        public ICollection<User> usersInChat { get; set; }

        public ICollection<Message> messages { get; set; }
    }
    
}