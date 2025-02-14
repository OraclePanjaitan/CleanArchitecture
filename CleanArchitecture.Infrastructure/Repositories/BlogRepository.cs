using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// this is domain implementation 
namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext blogDbContext;

        // Create DbContext class
        public BlogRepository(BlogDbContext blogDbContext) {
            this.blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await this.blogDbContext.Blogs.AddAsync(blog); // Add
            await this.blogDbContext.SaveChangesAsync();    // Save changes so Db will be saved
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await this.blogDbContext.Blogs.
                Where(model => model.Id == id).
                ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await this.blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await this.blogDbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await this.blogDbContext.Blogs.
                Where(model => model.Id == id).
                ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, blog.Id)
                    .SetProperty(m => m.Name, blog.Name)
                    .SetProperty(m => m.Description, blog.Description)
                    .SetProperty(m => m.Author, blog.Author)
                    .SetProperty(m => m.ImageUrl, blog.ImageUrl)
                    );
        }
    }
}
