using BlogEngine.Domain.Entities;
using BlogEngine.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace BlogEngine.Tests.Common
{
    public class ContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid BlogBId = Guid.Parse("4014D72B-4B32-44F2-93E1-1A38AEE9C959");
        public static Guid BlogIdForDelete = Guid.NewGuid();
        public static Guid BlogIdForUpdate = Guid.NewGuid();
        public static Guid BlogIdForWrongUserIdTest = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825");
        public static Guid PostIdForDelete = Guid.NewGuid();
        public static Guid PostIdForUpdate = Guid.NewGuid();

        public static Guid CommentIdForDelete = Guid.NewGuid();

        public static BlogDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new BlogDbContext(options);
            context.Database.EnsureCreated();

            var blogA = new Blog
            {
                Created = DateTime.Today,
                Description = "DescriptionA",
                Edited = null,
                Id = BlogIdForWrongUserIdTest,
                Name = "Name1",
                Posts = new List<Post>(),
                Category = new List<BlogCategory>(),
                Image = "SourceA",
                CreatorId = UserAId
            };
            var blogB = new Blog
            {
                Created = DateTime.Today,
                Description = "DescriptionA",
                Edited = null,
                Id = BlogBId,
                Name = "Name2",
                Posts = new List<Post>(),
                Category = new List<BlogCategory>(),
                Image = "SourceA",
                CreatorId = UserBId
            };
            var blogForDelete = new Blog
            {
                Created = DateTime.Today,
                Description = "For delete",
                Edited = null,
                Id = BlogIdForDelete,
                Name = "Blog for delete",
                Category = new List<BlogCategory>(),
                Image = "SourceA",
                CreatorId = UserAId
            };
            var blogForUpdate = new Blog
            {
                Created = DateTime.Today,
                Description = "For update",
                Edited = null,
                Id = BlogIdForUpdate,
                Name = "Blog for update",
                Category = new List<BlogCategory>(),
                Image = "SourceB",
                CreatorId = UserAId
            };
            var postA = new Post
            {
                Id = Guid.Parse("45A3FA76-C5D5-4FDF-90BC-2DDC75FE0A6B"),
                CreatorId = UserAId,
                BlogId = blogA.Id,
                Title = "TitleA",
                Content = "ContentA",
                Comments = new List<Comment>(),
                Tags = new List<PostTag>(),
                CreatedAt = DateTime.Today,
                EditedAt = null
            };
            var postB = new Post
            {
                Id = Guid.Parse("4C33202F-E096-4B5D-A004-97F0D39561FC"),
                CreatorId = UserBId,
                BlogId = blogB.Id,
                Title = "TitleB",
                Content = "ContentB",
                Comments = new List<Comment>(),
                Tags = new List<PostTag>(),
                CreatedAt = DateTime.Today,
                EditedAt = null
            };
            var tagA = new PostTag
            {
                Id = Guid.Parse("D2D701C8-A58F-45DB-B526-E638E824E68F"),
                PostId = postA.Id,
                Title = "tagA"
            };
            var tagB = new PostTag
            {
                Id = Guid.Parse("0B899867-4B78-4667-A427-62971041040A"),
                PostId = postB.Id,
                Title = "tagB"
            };
            var commentA = new Comment
            {
                Id = Guid.Parse("0EED6C87-DD65-43C0-8F5F-D5EBC76E5ECC"),
                Content = "ContentA",
                UserId = UserAId,
                PostId = postA.Id,
                CreatedAt = DateTime.Today,
            };
            var commentB = new Comment
            {
                Id = Guid.Parse("D78CBDC8-C03F-44DB-98A4-BB30AD61E00B"),
                Content = "ContentB",
                UserId = UserBId,
                PostId = postB.Id,
                CreatedAt = DateTime.Today,
            };

            var categoryA = new BlogCategory
            {
                Id = Guid.Parse("972C27B9-1E48-4A1A-9081-87F2F534CED9"),
                Name = "CategoryA",
            };
            var categoryB = new BlogCategory
            {
                Id = Guid.Parse("A3BB25C6-9898-4728-B618-5EA9C6350522"),
                Name = "CategoryB",
            };

            var subscription1 = new Subscription { UserId = UserAId, BlogId = blogA.Id };
            var subscription2 = new Subscription { UserId = UserAId, BlogId = blogB.Id };
            postA.Comments.Add(commentA);
            postA.Tags.Add(tagA);
            postB.Comments.Add(commentB);
            postB.Tags.Add(tagB);
            blogA.Posts.Add(postA);
            blogA.Category.Add(categoryA);
            blogB.Posts.Add(postB);
            blogB.Category.Add(categoryB);
            context.Blogs.AddRange(blogA, blogB, blogForDelete, blogForUpdate);
            context.Subsсription.AddRange(subscription1, subscription2);
            context.SaveChanges();
            return context;
        }

        public static void Destroy(BlogDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
