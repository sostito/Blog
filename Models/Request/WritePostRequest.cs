using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class WritePostRequest
    {
        [Required]
        public string Content { get; set; } = null!;
    }
}
