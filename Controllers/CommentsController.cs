using BlogApi.Dtos;
using BlogApi.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("posts/{postId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly CommentService _commentService;

        // Provides comment operations after verifying the parent post exists.
        public CommentsController(PostService postService, CommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        // Returns a post's comments or 404 when the post does not exist.
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetAll(int postId)
        {
            if (_postService.GetById(postId) is null) return NotFound();

            return Ok(_commentService.GetPostById(postId));
        }

        // Adds a comment to an existing post.
        [HttpPost]
        public ActionResult<Comment> Create(int postId, CreateCommentRequest request)
        {
            if (_postService.GetById(postId) is null) return NotFound();

            var comment = _commentService.Add(postId, request.Author, request.Text);
            return CreatedAtAction(nameof(GetAll), new { postId }, comment);
        }
    }
}
