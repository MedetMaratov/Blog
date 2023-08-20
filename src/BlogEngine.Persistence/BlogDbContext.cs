using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Persistence
{
    public class BlogDbContext : DbContext, IBlogDbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subscription> Subsсriptions { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}