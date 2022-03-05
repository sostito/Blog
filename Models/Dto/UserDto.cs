using System.Diagnostics.CodeAnalysis;

namespace Models.Dto
{
    [ExcludeFromCodeCoverage]
    public class UserDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
