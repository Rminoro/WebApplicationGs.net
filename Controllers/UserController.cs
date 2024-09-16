using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Datas;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            _userContext.Entry(user).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
