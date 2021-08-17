using EMa.Data.DataContext;
using EMa.Data.Entities;
using EMa.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMa.API.Controllers
{
    [ApiController]
    [Route("blog")]
    //[Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly DataDbContext _context;

        public BlogController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<Blog>> PostHealths(Guid userId, CreateBlogViewModel model)
        {
            Blog createBlog = new Blog()
            {
                Title = model.Title,
                Content = model.Content,
                ViewCount = model.ViewCount,
                Thumbnail = model.Thumbnail
            };
            _context.Blogs.Add(createBlog);
            await _context.SaveChangesAsync();

            return Ok(createBlog);
        }


        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> PutBlogs(Guid id, Guid userId, UpdateBlogViewModel model)
        {
            Blog updateBlog = new Blog()
            {
                Id = id,
                Title = model.Title,
                Content = model.Content,
                ViewCount = model.ViewCount,
                Thumbnail = model.Thumbnail,
                CreatedAt = DateTime.Now
            };
            _context.Entry(updateBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateBlog);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Blog>> DeleteBlogs(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool BlogsExists(Guid id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }

    }
}
