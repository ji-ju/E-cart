using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newproj.Models;

namespace Newproj.Models
{
    public class ApplicationUser : DbContext
      
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {

        }
        public DbSet<Assistant> Assistants{ get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Newproj.Models.ReviewModel> ReviewModel { get; set; }
    }
}

