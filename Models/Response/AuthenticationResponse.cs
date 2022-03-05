using System.Diagnostics.CodeAnalysis;

namespace Models.Response
{
    [ExcludeFromCodeCoverage]
    public  class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime expiracion { get; set; }
    }
}
