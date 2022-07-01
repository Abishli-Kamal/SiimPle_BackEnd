using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Siimple_Back__End.DAL;
using Siimple_Back__End.Models;
using Siimple_Back__End.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siimple_Back__End
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<LayoutSerrvis>();
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(_configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<AppUser,IdentityRole>(option =>
            {
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireDigit = true;
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(5);
                option.Lockout.AllowedForNewUsers=true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
