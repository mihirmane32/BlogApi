using BlogApi.Models;

namespace BlogApi.Services
{
    public class CommentService
    {
        private readonly List<Comment> _comment = new();
        private int _nextId = 1;

        public IReadOnlyList<Comment> GetPostById(int postId)
        {
            return _comment.Where(c => c.PostId == postId).ToList();
        }

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

        public void DeleteByPostId(int postId)
        {
            _comment.RemoveAll(c => c.PostId == postId);
        }
    }
}
