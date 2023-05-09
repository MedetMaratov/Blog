using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Interfaces
{
    public interface IBlogDbContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<BlogCategory> BlogCategories { get; set; }
        DbSet<PostTag> PostTags { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Subscription> Subsсription { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
