using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Data.Context
{
    [ExcludeFromCodeCoverage]
    public partial class BlogDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public BlogDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("BlogDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.IdPost).HasColumnName("Id_Post");

                entity.Property(e => e.Text)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdPost)
                    .HasConstraintName("FK_Comments_Post");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.DatePassed)
                    .HasColumnType("date")
                    .HasColumnName("Date_Passed");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Posts_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Role)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
