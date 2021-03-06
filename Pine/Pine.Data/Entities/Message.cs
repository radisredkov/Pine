using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pine.Data.Entities
{
    public class Message
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public DateTime timestamp { get; set; }
        [ForeignKey("chatId")]
        public string chatId { get; set; }
        public Chat chat { get; set; }
    }
}
