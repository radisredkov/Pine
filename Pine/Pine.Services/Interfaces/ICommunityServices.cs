﻿using Pine.Data.Entities;
using Pine.Data.Identity;
using Pine.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pine.Services.Interfaces
{
    public interface ICommunityServices
    {
        public void CreateCommunity(CommunityViewModel model, string userId);
        public Community getCommunityByName(string communityName);
        public ICollection<Community> getAllcommunities();


        void JoinCommunity(User user, string id);
    }
}