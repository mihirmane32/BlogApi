using BlogApi.Dtos;
using BlogApi.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        //private static readonly List<Post> _post = new()
        //{
        //    new Post { Id = 1, Title = "My First Post", Content = "Hello world", CreatedAt = DateTime.UtcNow },
        //    new Post { Id = 2, Title = "Second Post", Content = "More content", CreatedAt = DateTime.UtcNow}
        //};

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            return Ok(_postService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetById(int id)
        {
            var post = _postService.GetById(id);
            if (post is null) return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public ActionResult<Post> Create(CreatePostRequest request)
        {
            var post = _postService.Add(request.Title, request.Content);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public ActionResult<Post> Update(int id, UpdatePostRequest request)
        {
            var post = _postService.Update(id, request.Title, request.Content);
            if (post is null) return NotFound();

            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_postService.Delete(id)) return NotFound();

            return NoContent();
        }
    }
}
