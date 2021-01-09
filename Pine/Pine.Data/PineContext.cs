using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pine.Data.Entities;
using Pine.Data.Identity;

namespace Pine.Data
{
    public class PineContext : IdentityDbContext<User>
    {
        public PineContext(DbContextOptions<PineContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Community> communities { get; set; }
       
        public DbSet<Comment> comments { get; set; }
        public DbSet<ShopListing> listings { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasMany(u => u.posts).WithOne(p => p.creator);
            builder.Entity<User>().HasMany(u => u.listings).WithOne(l => l.creator);
            builder.Entity<User>().HasMany(u => u.CommunitiesJoined).WithMany(c => c.communityMembers);
            builder.Entity<Community>().HasOne(c => c.Owner);
           // builder.Entity<Community>().HasMany(c => c.communityPosts).WithOne(p => p.communityId);
            builder.Entity<Post>().HasMany(p => p.comments).WithOne(c => c.post);
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
