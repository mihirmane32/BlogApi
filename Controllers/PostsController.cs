using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // Temporary: hardcoded data so we can see GET work. I'll replace this with a proper service.
        private static readonly List<Post> _post = new()
        {
            new Post { Id = 1, Title = "My First Post", Content = "Hello world", CreatedAt = DateTime.UtcNow },
            new Post { Id = 2, Title = "Second Post", Content = "More content", CreatedAt = DateTime.UtcNow}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            return Ok(_post);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetById(int id)
        {
            var post = _post.FirstOrDefault(p => p.Id == id);
            if (post is null) return NotFound();

            return Ok(post);
        }
    }
}
