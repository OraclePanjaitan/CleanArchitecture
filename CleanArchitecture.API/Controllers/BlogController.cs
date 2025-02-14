using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            var user = new User();
            //user.Name = "Name1";
            //user.Email = "Name1@email";
            var blogs = await this.blogService.GetAllAsync();
            return Ok(user);
            //return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var blog = await this.blogService.GetByIdAsync(id);
            if (blog == null) {
                return NotFound();
            }

            return Ok(blog);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Blog blog) {
            var createdBlog = await this.blogService.CreateAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, Blog updatedBlog) { 
            int existignBlog = await this.blogService.UpdateAsync(id, updatedBlog);
            if (existignBlog == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) { 
            int? blog  = await this.blogService.DeleteAsync(id);
            if (blog == null) { 
                return NotFound(); 
            }
            return NoContent();
        }
    }
}
