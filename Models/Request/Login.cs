using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
