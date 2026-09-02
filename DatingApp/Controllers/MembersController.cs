using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetAllUsers()
        {
            var members = await context.Users.ToListAsync();

            return members;
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(string id)
        {
            var member = await context.Users.FindAsync(id);
            if ( member != null)
                return member;
            else
                return NotFound();
        }
    }
}
