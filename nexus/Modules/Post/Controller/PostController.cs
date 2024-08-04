using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using nexus.Config.Database;
using nexus.Config.Response;
using nexus.Modules.Post.Entity;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexus.Modules.Post.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(Connection dbContext, Response<Posts> response) : ControllerBase
    {
        private readonly Connection _context = dbContext;
        private readonly Response<Posts> _response = response;

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<Response<List<Posts>>>> Get(int page = 0, int limit = 10)
        {
            var posts = await _context.Post.Include(post => post.Comments).Skip(page).Take(limit).OrderBy(post => post.Id).ToListAsync();

            var response = new Response<List<Posts>>
            {
                Message = "Success get posts",
                Success = true,
                Data = posts
            };

            return response.ToJson();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Posts>>> Get(Guid id)
        {
            var post = await _context.Post.Include(post => post.Comments).Include(post => post.User).FirstOrDefaultAsync(post => post.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            _response.Message = "Success get post";
            _response.Success = true;
            _response.Data = post;

            return _response.ToJson();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Response<Posts>>> Post([FromBody] Posts post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            var result = CreatedAtAction(nameof(Get), new { id = post.Id }, post);

            _response.Message = "Success create post";
            _response.Success = true;

            return _response.ToJson();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Posts>>> Put(Guid id, [FromBody] Posts value)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _response.Message = "Success update post";
            _response.Success = true;

            return _response.ToJson();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Posts>>> Delete(Guid id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            _response.Message = "Success delete post";
            _response.Success = true;

            return _response.ToJson();
        }
    }
}
