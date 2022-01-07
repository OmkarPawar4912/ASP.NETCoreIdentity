using System;
using _2ndASP.NETCoreIdentity.Areas.Identity.Data;
using _2ndASP.NETCoreIdentity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(_2ndASP.NETCoreIdentity.Areas.Identity.IdentityHostingStartup))]
namespace _2ndASP.NETCoreIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<_2ndASPNETCoreIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("_2ndASPNETCoreIdentityContextConnection")));

                services.AddDefaultIdentity<_2ndASPNETCoreIdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<_2ndASPNETCoreIdentityContext>();
            });
        }
    }
}