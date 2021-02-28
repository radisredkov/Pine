using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Data.Entities
{
    public class Message
    {
        public Message()
        {
            this.id = Guid.NewGuid().ToString();
        }
        [Key]
        public string id { get; set; }         
        public string chatId { get; set; }
        public string senderName { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime time { get; set; }
    }
}
