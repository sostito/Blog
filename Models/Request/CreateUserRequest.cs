using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class CreateUserRequest
    {
        public string UserName { get; set; } = null!;
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
