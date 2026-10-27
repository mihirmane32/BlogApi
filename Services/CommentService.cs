using BlogApi.Models;

namespace BlogApi.Services
{
    public class CommentService
    {
        private readonly List<Comment> _comment = new();
        private int _nextId = 1;

        // Returns comments belonging to the specified post.
        public IReadOnlyList<Comment> GetPostById(int postId)
        {
            return _comment.Where(c => c.PostId == postId).ToList();
        }

        // Creates and stores a comment with a new identifier.
        public Comment Add(int postId, string author, string text)
        {
            var comment = new Comment
            {
                Id = _nextId,
                PostId = postId,
                Author = author,
                Text = text,
                CreatedAt = DateTime.UtcNow
            };

            _comment.Add(comment);
            _nextId++;

            return comment;
        }

        // Removes comments for a post that has been deleted.
        public void DeleteByPostId(int postId)
        {
            _comment.RemoveAll(c => c.PostId == postId);
        }
    }
}
