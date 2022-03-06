using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class UpdateCommentRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Text { get; set; }
    }
}
