using Pine.Data;
using Pine.Data.Identity;
using Pine.Models.Entities;
using Pine.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Data.Entities;

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
            return db.users.Include(u => u.posts)
                .Include(u => u.chats)
                .Include(u => u.listings)
                .Include(u => u.CommunitiesJoined)
                .FirstOrDefault(user => user.UserName == userName);
        }

        public void DeleteUser(User user)
        {
            List<Community> communitiesJoined = user.CommunitiesJoined.ToList();
            foreach (var com in communitiesJoined)
            {
                com.communityMembers.Remove(user);
                if (com.ownerId == user.Id)
                {
                    db.communities.Remove(com);
                }
                db.SaveChanges();
            }

            List<Post> posts = user.posts.ToList();
            foreach (var post in posts)
            {
                postServices.deletePost(post.id);
            }

            List<ShopListing> Listings = user.listings.ToList();
            foreach (var listing in Listings)
            {
                db.listings.Remove(listing);
            }

            List<Chat> chats = user.chats.ToList();
            foreach (var chat in chats)
            {
                var mesages = db.messages.Where(m => m.chatId == chat.id);
                foreach (var message in mesages)
                {
                   db.messages.Remove(message);
                }
                db.chats.Remove(chat);
            }

            db.users.Remove(user);
            db.SaveChanges();
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