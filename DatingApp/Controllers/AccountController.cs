using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Controllers
{
    public class AccountController(AppDbContext context, ITokenService tokenservice) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if (await EmailExists(registerDto.Email)) return BadRequest("Email taken.");

            var hmac = new HMACSHA512();
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if(user == null) return Unauthorized("Invalid email address.");

            var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (var i = 0; i < computedHash.Length; i++)
                if (computedHash[i] != user.PasswordHash[i]) 
                    return Unauthorized("Invalid Password.");

            return new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = tokenservice.CreateToken(user)
            };
        }

        private async Task<bool> EmailExists(string email)
        {
            return await context.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
