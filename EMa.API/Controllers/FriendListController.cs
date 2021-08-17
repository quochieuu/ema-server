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
    [Route("friendlist")]
    //[Authorize(Roles = "Admin")]
    public class FriendListController : Controller
    {
        private readonly DataDbContext _context;

        public FriendListController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<FriendList>>> GetFriendLists()
        {
            return await _context.FriendLists.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FriendList>> GetFriendList(Guid id)
        {
            var friendlist = await _context.FriendLists.FindAsync(id);

            if (friendlist == null)
            {
                return NotFound();
            }

            return Ok(friendlist);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<FriendList>> PostFriendLists(Guid userId, CreateFriendListViewModel model)
        {
            FriendList createFriendList = new FriendList()
            {
                FriendId = model.FriendId,
                UserId = model.UserId
            };
            _context.FriendLists.Add(createFriendList);
            await _context.SaveChangesAsync();

            return Ok(createFriendList);
        }


        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> PutFriendLists(Guid id, Guid userId, UpdateFriendListViewModel model)
        {
            FriendList updateFriendList = new FriendList()
            {
                Id = id,
                FriendId = model.FriendId,
                UserId = model.UserId
            };
            _context.Entry(updateFriendList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendListsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateFriendList);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendList>> DeleteFriendLists(Guid id)
        {
            var friendlist = await _context.FriendLists.FindAsync(id);
            if (friendlist == null)
            {
                return NotFound();
            }

            _context.FriendLists.Remove(friendlist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool FriendListsExists(Guid id)
        {
            return _context.FriendLists.Any(e => e.Id == id);
        }

    }
}
