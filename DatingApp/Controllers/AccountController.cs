using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Controllers
{
    public class AccountController(AppDbContext dbContext) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string email, string displayName, string password)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                DisplayName = displayName,
                Email = email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }
    }
}
