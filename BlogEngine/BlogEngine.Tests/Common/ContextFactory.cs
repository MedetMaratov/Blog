using AutoFixture;
using BlogEngine.Domain.Entities;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common.TestData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BlogEngine.Tests.Common
{
    public class ContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static BlogDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BlogDbContext(options);
            context.Database.EnsureCreated();
            AddTestData(context);

            return context;
        }

        public static void Destroy(BlogDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        private static void AddTestData(BlogDbContext context)
        {
            AddComments(context);
            AddPosts(context);
            AddBlogs(context);
            AddCategories(context);
            AddSubscriptions(context);
            context.SaveChanges();
        }

        private static void AddComments(BlogDbContext context)
        {
            context.Comments.AddRange(CommentsTestData.CommentA, CommentsTestData.CommentASecond,
                CommentsTestData.CommentB);
        }

        private static void AddPosts(BlogDbContext context)
        {
            context.Posts.AddRange(PostTestData.PostA, PostTestData.PostASecond, PostTestData.PostB);
        }

        private static void AddBlogs(BlogDbContext context)
        {
            context.Blogs.AddRange(BlogTestData.BlogA, BlogTestData.BlogB);
        }

        private static void AddCategories(BlogDbContext context)
        {
            context.Categories.AddRange(CategoryTestData.FirstCategory, CategoryTestData.SecondCategory);
        }

        private static void AddSubscriptions(BlogDbContext context)
        {
            var subscription = new Subscription { UserId = UserAId, BlogId = BlogTestData.BlogIdB };
            context.Subsсriptions.Add(subscription);
        }
    }
}
