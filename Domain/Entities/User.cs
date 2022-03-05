using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [ExcludeFromCodeCoverage]
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
        public string UserName { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
    }
}
