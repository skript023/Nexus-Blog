using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nexus.Config.Database;
using nexus.Config.Response;
using nexus.Modules.Comment.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexus.Modules.Comment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController(Connection dbContext, Response<Comments> response) : ControllerBase
    {
        private readonly Connection _context = dbContext;
        private readonly Response<Comments> _response = response;

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult<Response<List<Comments>>>> Get()
        {
            var comments = await _context.Comment.ToListAsync();

            var response = new Response<List<Comments>>
            {
                Message = "Success get comments",
                Success = true,
                Data = comments
            };

            return response.ToJson();
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Comments>>> Get(Guid id)
        {
            var comment = await _context.Comment.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            _response.Message = "Success get comment";
            _response.Success = true;
            _response.Data = comment;

            return _response.ToJson();
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult<Response<Comments>>> Post([FromBody] Comments value)
        {
            _context.Comment.Add(value);
            await _context.SaveChangesAsync();

            var result = CreatedAtAction(nameof(Get), new { id = value.Id }, value);

            _response.Message = "Success create comment";
            _response.Success = true;

            return _response.ToJson();
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Comments>>> Put(int id, [FromBody] Comments value)
        {
            var post = await _context.Comment.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _response.Message = "Success update comment";
            _response.Success = true;

            return _response.ToJson();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Comments>>> Delete(int id)
        {
            var post = await _context.Comment.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(post);
            await _context.SaveChangesAsync();

            _response.Message = "Success delete comment";
            _response.Success = true;

            return _response.ToJson();
        }
    }
}
