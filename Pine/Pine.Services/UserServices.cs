using Pine.Data;
using Pine.Data.Identity;
using Pine.Models.Entities;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class UserServices : IUserServices
    {
        private PineContext db;
        private readonly IFileService fileService;

        public UserServices(PineContext db, IFileService fileService)
        {
            this.db = db;
            this.fileService = fileService;
        }

        public User getUserById(string id)
        {
            return db.users.Find(id);
        }

        public User getUserByUserName(string userName)
        {
            return db.users.FirstOrDefault(u => u.UserName == userName);
        }

        public string getUserNameById(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.users.FirstOrDefault(u => u.Id == id).UserName;
            }
        }

        public void editUser(User oldUser, UserPanelInputModel model)
        {
            oldUser.userDescription = model.userDescription;
            if (oldUser.profilePicture != null && model.profilePicture == null)
            {

            }
            else
            {
                oldUser.profilePicture = fileService.ConvertToByte(model.profilePicture);
            }   

            db.users.Update(oldUser);
            db.SaveChanges();
        }
    }
}