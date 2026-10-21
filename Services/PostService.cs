using BlogApi.Models;

namespace BlogApi.Services
{
    public class PostService
    {
        private readonly List<Post> _posts = new();
        private int _nextId = 1;

        public IReadOnlyList<Post> GetAll() => _posts;
        public Post? GetById(int id) => _posts.FirstOrDefault(p => p.Id == id);

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

        public Post? Update(int id, string title, string content)
        {
            var post = GetById(id);
            if (post is null) return null;

            post.Title = title;
            post.Content = content;

            return post;
        }

        public bool Delete(int id)
        {
            var post = GetById(id);
            if (post is null) return false;

            _posts.Remove(post);
            return true;
        }
    }
}
