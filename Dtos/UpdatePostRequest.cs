using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos
{
    public class UpdatePostRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; } = "";

        [Required]
        public string Content { get; set; } = "";
    }
}
