using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos
{
    public class CreateCommentRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Author { get; set; } = "";

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Text { get; set; } = "";
    }
}
