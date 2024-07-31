using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using nexus.Config.Database;
using nexus.Config.Response;
using nexus.Modules.Post.Entity;
using nexus.Modules.User.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexus.Modules.User.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(Connection dbContext, Response<Users> response) : ControllerBase
    {
        private readonly Connection _context = dbContext;
        private readonly Response<Users> _response = response;

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<Response<List<Users>>>> Get()
        {
            var users = await _context.User.ToListAsync();

            var response = new Response<List<Users>> {
                Message = "Success get users",
                Success = true,
                Data = users
            };

            return response.ToJson();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Users>>> Get(Guid id)
        {
            var users = await _context.User.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            _response.Message = "Success get user";
            _response.Success = true;
            _response.Data = users;

            return _response.ToJson();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Response<Users>>> Post([FromBody] Users user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            var result = CreatedAtAction(nameof(Get), new { id = user.Id }, user);

            _response.Message = "Success create user";
            _response.Success = true;

            return _response.ToJson();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Users>>> Put(Guid id, [FromBody] Users value)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _response.Message = "Success update user";
            _response.Success = true;

            return _response.ToJson();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Users>>> Delete(Guid id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            _response.Message = "Success delete user";
            _response.Success = true;

            return _response.ToJson();
        }
    }
}
