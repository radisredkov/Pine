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
            messages = new List<Message>();
            users = new List<ChatUser>();
        }
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public ICollection<Message> messages { get; set; }
        public ICollection<ChatUser> users { get; set; }
    }

}