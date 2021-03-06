﻿using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pine.Data.Entities
{
    public class Comment
    {
        public Comment()
        {
            this.id = Guid.NewGuid().ToString();
        }

        [Key]
        public string id { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime timeOfCreation { get; set; }

        public string commentatorId { get; set; }
        public virtual User commentator { get; set; }

        [ForeignKey("postId")]
        public Post post { get; set; }

        public byte[] Img { get; set; }

        public string moderatorName { get; set; }
    }
}