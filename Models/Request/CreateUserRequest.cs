using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class CreateUserRequest
    {
        [Required]
        public string? UserName { get; set; } = null!;
        [Required]
        public string? Role { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
