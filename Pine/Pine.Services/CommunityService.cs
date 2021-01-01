using Pine.Data;
using Pine.Data.Entities;
using Pine.Models.Entities;
using Pine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Services
{
    public class CommunityServices:ICommunityServices
    {
        private PineContext db;

        public CommunityServices(PineContext db)
        {
            this.db = db;
        }
        
        public void JoinCommunity(string userId,string communityId)
        {
            //db.communities.Find(communityId).
        }
        public void CreateCommunity(CommunityViewModel model, string userId)
        {
            Community community = new Community
            {
               
                name = model.name,
                description = model.description,
                //tags = model.tags,
                ownerId = userId,
                posts = new List<Post>()

            };

            db.communities.Add(community);
            db.SaveChanges();
        }

        public ICollection<Community> getAllcommunities()
        {
             
               return db.communities.ToList();
            
        }
    }
}
