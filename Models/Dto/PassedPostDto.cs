using System.Diagnostics.CodeAnalysis;

namespace Models.Dto
{
    [ExcludeFromCodeCoverage]
    public class PassedPostDto
    {
        public string? Comment { get; set; }
        public string? Author { get; set; }
        public DateTime? ApprobalDate { get; set; }
    }
}
