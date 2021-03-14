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
        private readonly ICommunityServices communityService;
        private readonly IPostServices postServices;



        public UserServices(PineContext db, IFileService fileService, ICommunityServices communityService, IPostServices postServices)
        {
            this.db = db;
            this.fileService = fileService;
            this.communityService = communityService;
            this.postServices = postServices;
        }

        public User getUserById(string id)
        {
            return db.users.Find(id);
        }

        public User getUserByUserName(string userName)
        {
            return db.users.FirstOrDefault(u => u.UserName == userName);
        }

        public void DeleteUser(User user)
        {
            foreach (var com in user.CommunitiesJoined)
            {
                com.communityMembers.Remove(user);
            }
            foreach (var post in user.posts)
            {
                postServices.deletePost(post.id);
            }
            foreach (var chat in user.chats)
            {
                foreach (var message in chat.messages)
                {
                   db.messages.Remove(message);
                }                 
                db.chats.Remove(chat);
            }
            db.users.Remove(user);
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
            if (oldUser.userCss != null && model.userCss == null)
            {

            }
            else
            {
                oldUser.profilePicture = fileService.ConvertToByte(model.profilePicture);
                oldUser.userCss = fileService.ConvertToByte(model.userCss);
            }

            db.users.Update(oldUser);
            db.SaveChanges();
        }
    }
}