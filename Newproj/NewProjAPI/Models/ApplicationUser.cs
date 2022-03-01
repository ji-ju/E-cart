using Microsoft.EntityFrameworkCore;
using NewProjAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewprojAPI.Models
{
    public class ApplicationUser : DbContext
      
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {

        }
       
        public DbSet<Review> Reviews { get; set; }
        
    }
}

