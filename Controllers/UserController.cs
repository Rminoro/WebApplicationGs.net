using Microsoft.AspNetCore.Mvc;
using WebApplication1.Singleton;
using WebApplication1.Models;
using WebApplication1.Datas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;
        private readonly SingletonUser _singletonUser;

        public UserController(UserContext userContext, SingletonUser singletonUser)
        {
            _userContext = userContext;
            _singletonUser = singletonUser;
        }

        // GET: api/User
        [HttpGet]
        [SwaggerOperation(Summary = "Puxa todos os usuarios", Description = "Puxa todos os usuarios.")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userContext.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Puxa informações do usuario por id", Description = "Puxa informações de um usuário específico do banco de dados utilizando seu ID.")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/User
        [SwaggerOperation(Summary = "Adiciona um novo usuario", Description = "Adiciona um usuario novo definindo id, nome, email e senha.")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (user == null)
                return BadRequest("User cannot be null");

            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/User/{id}
        [SwaggerOperation(Summary = "Altera alguma informação pelo id", Description = "altera algum atributo de  um usuário específico do banco de dados utilizando seu ID.")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
                return BadRequest("User ID mismatch");

            var existingUser = await _userContext.Users.FindAsync(id);
            if (existingUser == null)
                return NotFound();

            _userContext.Entry(existingUser).CurrentValues.SetValues(user);
            await _userContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletar usuário por ID", Description = "Exclui um usuário específico do banco de dados utilizando seu ID.")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/User/setting/{key}
        [HttpGet("setting/{key}")]
        public IActionResult GetSetting(string key)
        {
            var settingValue = _singletonUser.GetSetting(key);
            return Ok(settingValue);
        }
    }
}
