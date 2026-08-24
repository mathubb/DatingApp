using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(AppDbContext context) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetAllUsers()
        {
            var members = await context.Users.ToListAsync();

            return members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            var member = await context.Users.FindAsync(id);
            if ( member != null)
                return member;
            else
                return NotFound();
        }
    }
}
