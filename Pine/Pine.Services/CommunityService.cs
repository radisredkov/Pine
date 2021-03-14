using Microsoft.EntityFrameworkCore;
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


        public CommunityServices(PineContext db, IFileService fileService)
        {
            this.db = db;
            this.fileService = fileService;
        }

        public void JoinCommunity(User user, Community com)
        {
            if (com.communityMembers.Contains(user))
            {
                return;
            }
            else
            {
                db.communities.Find(com.id).communityMembers.Add(user);
                db.SaveChanges();
            }
        }
        public void CreateCommunity(CommunityViewModel model, string userId)
        {
            Community community = new Community
            {
                name = model.name,
                description = model.description,
                ownerId = userId,
                isPrivate = model.isPrivate,
                isAnonymous = model.isAnonymous
            };
           // User user = new User { Id = userId };
            db.communities.Add(community);
            db.SaveChanges();
           // JoinCommunity(user, community);
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
            return getAllcommunities().FirstOrDefault(c => c.name == communityName);
        }
        public Community getCommunityById(string communityId)
        {
            return getAllcommunities().FirstOrDefault(c => c.id == communityId);
        }

        public ICollection<Community> getAllcommunities()
        {
            return db.communities.Include(c => c.communityMembers)
                .Include(c => c.communityPosts)
                .Include(c => c.communityModerators)
                .Include(C => C.Owner)
                .ToList();
        }

        //public ICollection<Post> GetPostsFromCommunity(string id)
        //{
        //    return db.posts.Where(p => p.id == id).ToList();
        //}


        //public ICollection<Post> getAllPostsFromCommunity(string comName)
        //{
        //    return db.communities.FirstOrDefault(c => c.name == comName).communityPosts;
        //}
    }
}