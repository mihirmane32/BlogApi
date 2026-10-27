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
        private readonly CommentService _commentService;

        //private static readonly List<Post> _post = new()
        //{
        //    new Post { Id = 1, Title = "My First Post", Content = "Hello world", CreatedAt = DateTime.UtcNow },
        //    new Post { Id = 2, Title = "Second Post", Content = "More content", CreatedAt = DateTime.UtcNow}
        //};

        // Provides post operations and removes related comments when posts are deleted.
        public PostsController(PostService postService, CommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        // Returns all posts.
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            return Ok(_postService.GetAll());
        }

        // Returns a post or 404 when it does not exist.
        [HttpGet("{id}")]
        public ActionResult<Post> GetById(int id)
        {
            var post = _postService.GetById(id);
            if (post is null) return NotFound();

            return Ok(post);
        }

        // Creates a post and returns its location.
        [HttpPost]
        public ActionResult<Post> Create(CreatePostRequest request)
        {
            var post = _postService.Add(request.Title, request.Content);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        // Updates a post or returns 404 when it does not exist.
        [HttpPut("{id}")]
        public ActionResult<Post> Update(int id, UpdatePostRequest request)
        {
            var post = _postService.Update(id, request.Title, request.Content);
            if (post is null) return NotFound();

            return Ok(post);
        }

        // Deletes a post and its comments, or returns 404 if missing.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_postService.Delete(id)) return NotFound();

            _commentService.DeleteByPostId(id);
            return NoContent();
        }
    }
}
