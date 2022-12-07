using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repository;
        public UsersController(UserRepository repository)
        {
             _repository = repository;
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> Post(User entity)
        {
            await _repository.Add(entity);
            return Created("api/users", entity);
        }
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            string username = HttpContext.User.Identity.Name;
            
            var entity = await _repository.Get(username);
            if (entity == null)
            {
                return NotFound();
            }
            
            return Ok(entity);
        }
        [HttpGet("{authorized}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(bool authorized)
        {
            if (authorized)
            {
                return Unauthorized();
            }
            var entities = await _repository.GetAll();
            return Ok(entities);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User entity)
        {
            await _repository.Update(id, entity);
            return NoContent();
        }
    }
}