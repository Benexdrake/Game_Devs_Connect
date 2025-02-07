using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controllr]")]
    [ApiController]
    public class UserController(GDCDbContext context) : ControllerBase
    {
        private readonly GDCDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.User.ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult> GetUser(string id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            if(user is null) return BadRequest("Where is the User?");
            var dbUser = await _context.User.FirstOrDefaultAsync(x=> x.Id == user.Id);

            if(dbUser is null)
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            if (user is null) return BadRequest("Where is the User?");
            
            var dbUser = await _context.User.FirstOrDefaultAsync(x => x.Id == user.Id);
            
            if (dbUser is null) return BadRequest();

            // Update User
            dbUser.Username = user.Username;
            dbUser.Banner = user.Banner;
            dbUser.Avatar = user.Avatar;
            dbUser.AccountType = user.AccountType;
            dbUser.Email = user.Email;
            dbUser.XUrl = user.XUrl;
            dbUser.DiscordUrl = user.DiscordUrl;
            dbUser.WebsiteUrl = user.WebsiteUrl;

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            var dbUser = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);

            if (dbUser is null) return BadRequest();

            


            _context.User.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(dbUser);
        }
    }
}
