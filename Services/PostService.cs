using BlogApi.Models;

namespace BlogApi.Services
{
    public class PostService
    {
        private readonly List<Post> _posts = new();
        private int _nextId = 1;

        // Returns all stored posts.
        public IReadOnlyList<Post> GetAll() => _posts;

        // Finds a post by its identifier.
        public Post? GetById(int id) => _posts.FirstOrDefault(p => p.Id == id);

        // Creates and stores a post with a new identifier.
        public Post Add(string title, string content)
        {
            var post = new Post
            {
                Id = _nextId,
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            _posts.Add(post);
            _nextId++;

            return post;
        }

        // Updates an existing post, or returns null if it is missing.
        public Post? Update(int id, string title, string content)
        {
            var post = GetById(id);
            if (post is null) return null;

            post.Title = title;
            post.Content = content;

            return post;
        }

        // Removes a post and reports whether it existed.
        public bool Delete(int id)
        {
            var post = GetById(id);
            if (post is null) return false;

            _posts.Remove(post);
            return true;
        }
    }
}
