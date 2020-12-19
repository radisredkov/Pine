using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pine.Data;
using Pine.Data;

[assembly: HostingStartup(typeof(Pine.Data.IdentityHostingStartup))]
namespace Pine.Data
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<PineContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PineContextConnection")));
            });
        }
    }
}