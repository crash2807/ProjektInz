using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektInzynierski.Models;

namespace ProjektInzynierski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHobbiesController : ControllerBase
    {
        private readonly s17041Context _context;

        public UserHobbiesController(s17041Context context)
        {
            _context = context;
        }

        // GET: api/UserHobbies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserHobby>>> GetUserHobby()
        {
            return await _context.UserHobby.ToListAsync();
        }

        // GET: api/UserHobbies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHobby>> GetUserHobby(int id)
        {
            var userHobby = await _context.UserHobby.FindAsync(id);

            if (userHobby == null)
            {
                return NotFound();
            }

            return userHobby;
        }

        // PUT: api/UserHobbies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHobby(int id, UserHobby userHobby)
        {
            if (id != userHobby.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(userHobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHobbyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserHobbies
        [HttpPost]
        public async Task<ActionResult<UserHobby>> PostUserHobby(UserHobby userHobby)
        {
            _context.UserHobby.Add(userHobby);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserHobbyExists(userHobby.IdUser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserHobby", new { id = userHobby.IdUser }, userHobby);
        }

        // DELETE: api/UserHobbies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserHobby>> DeleteUserHobby(int id)
        {
            var userHobby = await _context.UserHobby.FindAsync(id);
            if (userHobby == null)
            {
                return NotFound();
            }

            _context.UserHobby.Remove(userHobby);
            await _context.SaveChangesAsync();

            return userHobby;
        }

        private bool UserHobbyExists(int id)
        {
            return _context.UserHobby.Any(e => e.IdUser == id);
        }
    }
}
