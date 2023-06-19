using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using BlogEngineApplication.Blogs.Commands.DeleteBlog;
using BlogEngineApplication.Common.Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Blogs.Commands
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
                BlogId = ContextFactory.BlogIdForDelete,
                UserId = ContextFactory.UserAId,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Blogs.SingleOrDefault(blog =>
            blog.Id == ContextFactory.BlogIdForDelete));
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
                        BlogId = ContextFactory.BlogIdForWrongUserIdTest,
                        UserId = ContextFactory.UserBId,
                    }
                , CancellationToken.None));
        }
    }
}
