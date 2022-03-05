using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class WritePostRequest
    {
        public string Content { get; set; } = null!;
    }
}
