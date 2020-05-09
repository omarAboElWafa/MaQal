using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaQal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaQal.Data
{
    public class AppDbContext : IdentityDbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
        
    }
}
