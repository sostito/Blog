using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? IdPost { get; set; }

        public virtual Post? IdPostNavigation { get; set; }
    }
}
