using Pine.Data.Identity;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services
{
    public interface IUserServices
    {
        public string getUserNameById(string id);
        public User getUserById(string id);
        public User getUserByUserName(string name);
        void editUser(User oldUser, UserPanelInputModel model);
        public void DeleteUser(User user);
    }
}
