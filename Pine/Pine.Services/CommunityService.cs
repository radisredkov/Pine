using Pine.Data;
using Pine.Data.Entities;
using Pine.Data.Identity;
using Pine.Models.Entities;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class CommunityServices : ICommunityServices
    {
        private PineContext db;
        private readonly IFileService fileService;
        private readonly IUserServices userServices;

        public CommunityServices(PineContext db, IFileService fileService, IUserServices userServices)
        {
            this.db = db;
            this.fileService = fileService;
            this.userServices = userServices;
        }

        public void JoinCommunity(User user, Community com)
        {
            if (db.communities.FirstOrDefault(x => x.id == com.id).communityMembers.Contains(user))
            {
                return;
            }
            else
            {
                db.communities.FirstOrDefault(x => x.id == com.id).communityMembers.Add(user);
            }

            db.SaveChanges();
        }
        public void CreateCommunity(CommunityViewModel model, string userId)
        {
            Community community = new Community
            {
                name = model.name,
                description = model.description,
                ownerId = userId,
                isPrivate = model.isPrivate
            };
            User user = new User { Id = userId }; //TODO: join the creator to community
            db.communities.Add(community);
            db.SaveChanges();
        }

        public void EditCommunity(Community oldCommunity, CommunityInputModel model)
        {
            oldCommunity.description = model.communityDescription;
            if (oldCommunity.communityCss != null && model.communityCss == null)
            {

            }
            else
            {
                oldCommunity.communityCss = fileService.ConvertToByte(model.communityCss);
            }

            db.communities.Update(oldCommunity);
            db.SaveChanges();
        }

        public void AddModerator(Community com, User moderator)
        {
            com.communityModerators.Add(moderator);
            com.moderatorName = moderator.UserName;
            db.Update(com);
            db.SaveChanges();
        }

        public void RemoveModerator(Community com, User moderator)
        {
            com.communityModerators.Remove(moderator);
            com.moderatorName = null;
            db.Update(com);
            db.SaveChanges();
        }

        public Community getCommunityByName(string communityName)
        {
            return db.communities.FirstOrDefault(c => c.name == communityName);
        }

        public ICollection<Post> GetPostsFromCommunity(string id)
        {
            return db.posts.Where(p => p.id == id).ToList();
        }

        public ICollection<Community> getAllcommunities()
        {
            return db.communities.ToList();
        }

        public ICollection<Post> getAllPostsFromCommunity(string comName)
        {
            return db.communities.FirstOrDefault(c => c.name == comName).communityPosts;
        }
    }
}