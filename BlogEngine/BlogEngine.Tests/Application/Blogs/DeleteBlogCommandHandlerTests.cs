using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Blogs.Commands.DeleteBlog;
using BlogEngineApplication.Common.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Blogs
{
    public class DeleteBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteBlogCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteBlogCommand
            {
                BlogId = BlogTestData.BlogIdB,
                UserId = ContextFactory.UserBId,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Blogs.SingleOrDefault(blog =>
            blog.Id == BlogTestData.BlogIdB));
        }

        [Fact]
        public async Task DeleteBlogCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteBlogCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteBlogCommand
                    {
                        BlogId = Guid.NewGuid(),
                        UserId = ContextFactory.UserAId,
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteBlogCommandHandler_FailOnWrongUserId()
        {
            var handler = new DeleteBlogCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(
                    new DeleteBlogCommand
                    {
                        BlogId = BlogTestData.BlogIdB,
                        UserId = Guid.NewGuid(),
                    }
                , CancellationToken.None));
        }
    }
}
