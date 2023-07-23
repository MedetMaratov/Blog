using BlogEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Tests.Common.TestData
{
    public static class CommentsTestData
    {
        public static Guid CommentIdA { get; } = Guid.NewGuid();
        public static Guid CommentIdASecond { get; } = Guid.NewGuid();
        public static Guid CommentIdB { get; } = Guid.NewGuid();

        public static Comment CommentA => new()
        {
            Id = CommentIdA,
            Content = "Content A",
            UserId = ContextFactory.UserAId,
            PostId = PostTestData.PostIdA,
            CreatedAt = DateTime.Today,
        };

        public static Comment CommentASecond => new()
        {
            Id = CommentIdASecond,
            Content = "Content A second",
            UserId = ContextFactory.UserAId,
            PostId = PostTestData.PostIdA,
            CreatedAt = DateTime.Today,
        };

        public static Comment CommentB => new()
        {
            Id = CommentIdB,
            Content = "Content B",
            UserId = ContextFactory.UserBId,
            PostId = PostTestData.PostIdB,
            CreatedAt = DateTime.Today,
        };
    }
}
