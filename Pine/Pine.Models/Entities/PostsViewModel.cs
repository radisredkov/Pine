using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Models.Entities
{
    public class PostsViewModel
    {
        public ICollection<OuputPostViewModel> posts { get; set; }
    }
}
