using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public string Content { get; set; } = null!;
        public int Id { get; set; }
        public bool? Passed { get; set; }
        public int? IdUser { get; set; }
        public DateTime? DatePassed { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
