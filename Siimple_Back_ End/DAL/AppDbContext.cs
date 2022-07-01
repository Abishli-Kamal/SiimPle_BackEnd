using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Siimple_Back__End.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siimple_Back__End.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Servis> Services { get; set; }


    }
}
