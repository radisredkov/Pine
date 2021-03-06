using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pine.Data.Entities
{
    public class ChatUser
    {
        [ForeignKey("userId")]
        public string userId { get; set; }
        public User user { get; set; }
        [ForeignKey("chatId")]
        public string chatId { get; set; }
        public Chat chat { get; set; }
    }
}
