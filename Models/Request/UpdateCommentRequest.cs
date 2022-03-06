using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class UpdateCommentRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Text { get; set; }
    }
}
