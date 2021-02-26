using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pine.Data;
using Pine.Data.Identity;
using Pine.Services;
using Pine.Services.Hubs;
using Pine.Services.Interfaces;

namespace Pine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<PineContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("PineContextConnection"), b => b.MigrationsAssembly("Pine"));
            });
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<PineContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddSignalR();

            services.AddTransient<IPostServices, PostServices>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ICommunityServices, CommunityServices>();
            services.AddTransient<IShopListingService, ShopListingService>();
            services.AddTransient<ICommentServices, CommentServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


           

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Post}/{action=AllPosts}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Community}/{action=Communities}/{id?}");
                endpoints.MapHub<MessageHub>("/messagehub");
            });
        }
    }
}
