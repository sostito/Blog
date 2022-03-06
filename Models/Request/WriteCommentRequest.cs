using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class WriteCommentRequest
    {
        [Required]
        public string? Text { get; set; }
        [Required]
        public int IdPost { get; set; }
    }
}
