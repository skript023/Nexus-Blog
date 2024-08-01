using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nexus.Config.Database;
using nexus.Config.Response;
using nexus.Modules.Comment.Entity;
using nexus.Modules.Role.Dto;
using nexus.Modules.Role.Entity;
using nexus.Modules.User.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexus.Modules.Role.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(Connection dbContext, Response<Roles> response) : ControllerBase
    {
        private readonly Connection _context = dbContext;
        private readonly Response<Roles> _response = response;

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<Response<List<Roles>>>> Get()
        {
            var roles = await _context.Role.ToListAsync();

            var response = new Response<List<Roles>>
            {
                Message = "Success get roles",
                Success = true,
                Data = roles
            };

            return response.ToJson();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Roles>>> Get(Guid id)
        {
            var role = await _context.Role.FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                return NotFound();
            }

            _response.Message = "Success get role";
            _response.Success = true;
            _response.Data = role;

            return _response.ToJson();
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<Response<Roles>>> Post([FromBody] RoleCreate value)
        {
            var role = new Roles(value);

            _context.Role.Add(role);
            await _context.SaveChangesAsync();

            _response.Message = "Success create role";
            _response.Success = true;

            return _response.ToJson();
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Roles>>> Put(Guid id, [FromBody] RoleUpdate value)
        {
            var role = await _context.Role.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _response.Message = "Success update role";
            _response.Success = true;

            return _response.ToJson();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Roles>>> Delete(Guid id)
        {
            var role = await _context.User.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            _context.User.Remove(role);
            await _context.SaveChangesAsync();

            _response.Message = "Success delete role";
            _response.Success = true;

            return _response.ToJson();
        }
    }
}
