using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BlogDbContext Db;

        public UserController(BlogDbContext _Db)
        {
            Db = _Db;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var user = new User();
        //    //user.Name = "Name1";
        //    //user.Email = "Name1@email";
        //    return Ok(user);
        //    //return Ok(blogs);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await Db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            //var createdBlog = await this.blogService.CreateAsync(blog);
            //return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
            await Db.Users.AddAsync(user); // Add
            await Db.SaveChangesAsync();    // Save changes so Db will be saved
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await Db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            Db.Users.Remove(user);          // Remove user from the database
            await Db.SaveChangesAsync();    // Save changes to the database

            return NoContent();             // Return 204 No Content response
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await Db.Users.ToListAsync(); // Mengambil semua data user
            return Ok(users);                         // Mengembalikan semua user
        }



    }
}
