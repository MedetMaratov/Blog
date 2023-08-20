using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineApplication.Interfaces
{
    public interface IBlogDbContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Subscription> Subsсriptions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
