using Pine.Data;
using Pine.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class UserServices : IUserServices
    {
        private PineContext db;

        public UserServices(PineContext db)
        {
            this.db = db;
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
    }
}
