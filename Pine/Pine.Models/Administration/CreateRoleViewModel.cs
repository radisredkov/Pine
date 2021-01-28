using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pine.Models.Administration
{
   public class CreateRoleViewModel
    {
        [Required]
        public string roleName { get; set; }
    }
}
