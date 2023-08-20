using BlogEngine.Domain.Entities;

namespace BlogEngine.Tests.Common.TestData
{
    public static class PostTestData
    {
        public static Guid PostIdA { get; } = Guid.NewGuid();
        public static Guid PostIdASecond { get; } = Guid.NewGuid();
        public static Guid PostIdB { get; } = Guid.NewGuid();

        public static Post PostA => new()
        {
            Id = PostIdA,
            CreatorId = ContextFactory.UserAId,
            BlogId = BlogTestData.BlogIdA,
            Title = "Title A",
            Content = "Content A",
            Comments = new List<Comment>(),
            Tags = new List<Tag> { new Tag("tag1") },
            CreatedAt = DateTime.Today,
            EditedAt = null
        };

        public static Post PostB => new()
        {
            Id = PostIdB,
            CreatorId = ContextFactory.UserBId,
            BlogId = BlogTestData.BlogIdB,
            Title = "Title B",
            Content = "Content B",
            Comments = new List<Comment>(),
            Tags = new List<Tag> { new Tag("tag2") },
            CreatedAt = DateTime.Today,
            EditedAt = null
        };

        public static Post PostASecond => new()
        {
            Id = PostIdASecond,
            CreatorId = ContextFactory.UserAId,
            BlogId = BlogTestData.BlogIdA,
            Title = "Title A second",
            Content = "Content A second",
            Comments = new List<Comment>(),
            Tags = new List<Tag> { new Tag("tag3") },
            CreatedAt = DateTime.Today,
            EditedAt = null
        };
    }
}
