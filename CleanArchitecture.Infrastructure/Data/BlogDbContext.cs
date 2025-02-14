using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : base(dbContextOptions) { }// inject db context option <point to our context class        
        public DbSet<Blog> Blogs { get; set; } // based on DbSet our table will create,update,delete everything based on dbset
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<User> Users { get; set; }
    }
}
