using BlogEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Tests.Common.TestData
{
    public static class BlogTestData
    {
        public static Guid BlogIdA { get; } = Guid.NewGuid();
        public static Guid BlogIdB { get; } = Guid.NewGuid();

        public static Blog BlogA => new()
        {
            Id = BlogIdA,
            Name = "Blog for update",
            Description = "For update",
            Image = "SourceB",
            Created = DateTime.Today,
            Edited = null,
            Categories = new List<Category> { CategoryTestData.CategoryA },
            CreatorId = ContextFactory.UserAId,
            Posts = new List<Post>()
        };

        public static Blog BlogB => new Blog
        {
            Id = BlogIdB,
            Name = "Blog for delete",
            Description = "For delete",
            Image = "SourceA",
            Created = DateTime.Today,
            Edited = null,
            Categories = new List<Category>(),
            CreatorId = ContextFactory.UserBId,
            Posts = new List<Post>()
        };
    }
}
