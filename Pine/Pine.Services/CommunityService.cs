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

        public CommunityServices(PineContext db)
        {
            this.db = db;
        }

        public void JoinCommunity(User user, string communityId)
        {

            db.communities.Find(communityId).communityMembers.Add(user);
           
            db.SaveChanges();
        }
        public void CreateCommunity(CommunityViewModel model, string userId)
        {
            Community community = new Community
            {
                name = model.name,
                description = model.description,
                //tags = model.tags,\
                ownerId = userId,
                communityPosts = db.posts.ToList()
            };

            db.communities.Add(community);
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

      
    }
}