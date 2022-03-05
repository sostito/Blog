using System.Diagnostics.CodeAnalysis;

namespace Models.Request
{
    [ExcludeFromCodeCoverage]
    public class WriteCommentRequest
    {
        public string? Text { get; set; }
        public int IdPost { get; set; }
    }
}
