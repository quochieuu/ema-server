//using EMa.Data.DataContext;
//using EMa.Data.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EMa.API.Controllers
//{
//    [ApiController]
//    [Route("image")]
//    //[Authorize(Roles = "Admin")]
//    public class LessionController : Controller
//    {
//        private readonly DataDbContext _context;

//        public LessionController(DataDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        [Route("")]
//        public async Task<ActionResult<IEnumerable<Lession>>> GetImages()
//        {
//            return await _context.Lessions.ToListAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Lession>> GetImage(Guid id)
//        {
//            var image = await _context.Lessions.FindAsync(id);

//            if (image == null)
//            {
//                return NotFound();
//            }

//            return Ok(image);
//        }

//        [HttpPost("{userId}")]
//        public async Task<ActionResult<Lession>> PostImages(Guid userId, CreateLessionViewModel model)
//        {
//            Lession createImage = new Lession()
//            {
//                File = model.File
//            };
//            _context.Images.Add(createImage);
//            await _context.SaveChangesAsync();

//            return Ok(createImage);
//        }


//        [HttpPut("{id}/{userId}")]
//        public async Task<IActionResult> PutImages(Guid id, Guid userId, UpdateImageViewModel model)
//        {
//            Lession updateImage = new Lession()
//            {
//                Id = id,
//                File = model.File
//            };
//            _context.Entry(updateImage).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ImagesExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return Ok(updateImage);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Lession>> DeleteImages(Guid id)
//        {
//            var image = await _context.Images.FindAsync(id);
//            if (image == null)
//            {
//                return NotFound();
//            }

//            _context.Images.Remove(image);
//            await _context.SaveChangesAsync();

//            return Ok();
//        }

//        private bool ImagesExists(Guid id)
//        {
//            return _context.Images.Any(e => e.Id == id);
//        }

//    }
//}
