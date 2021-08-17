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
    [Route("friendship")]
    //[Authorize(Roles = "Admin")]
    public class FriendShipController : Controller
    {
        private readonly DataDbContext _context;

        public FriendShipController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<FriendShip>>> GetFriendShips()
        {
            return await _context.FriendShips.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FriendShip>> GetFriendShip(Guid id)
        {
            var friendship = await _context.FriendShips.FindAsync(id);

            if (friendship == null)
            {
                return NotFound();
            }

            return Ok(friendship);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<FriendShip>> PostFriendShips(Guid userId, CreateFriendShipViewModel model)
        {
            FriendShip createFriendShip = new FriendShip()
            {
                SenderId = model.SenderId,
                ReceipId = model.ReceipId,
                Confirmed = model.Confirmed
            };
            _context.FriendShips.Add(createFriendShip);
            await _context.SaveChangesAsync();

            return Ok(createFriendShip);
        }


        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> PutFriendShips(Guid id, Guid userId, UpdateFriendShipViewModel model)
        {
            FriendShip updateFriendShip = new FriendShip()
            {
                Id = id,
                SenderId = model.SenderId,
                ReceipId = model.ReceipId,
                Confirmed = model.Confirmed
            };
            _context.Entry(updateFriendShip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendShipsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateFriendShip);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendShip>> DeleteFriendShips(Guid id)
        {
            var friendship = await _context.FriendShips.FindAsync(id);
            if (friendship == null)
            {
                return NotFound();
            }

            _context.FriendShips.Remove(friendship);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool FriendShipsExists(Guid id)
        {
            return _context.FriendShips.Any(e => e.Id == id);
        }

    }
}
