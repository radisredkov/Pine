using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services
{
    public interface IUserServices
    {
        public string getUserNameById(string id);
        public User getUserById(string id);
    }
}
