using BlogEngine.Tests.Common;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Posts.Commands.Delete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Posts.Commands
{
    public class DeletePostCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePostCommandHandler_Succes()
        {
            // Arrange
            var handler = new DeletePostCommandHandler(Context);

            // Act

            await handler.Handle(new DeletePostCommand
            {
                BlogId = ContextFactory.BlogBId,
                UserId = ContextFactory.UserBId,
                PostId = ContextFactory.PostIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Posts.SingleOrDefault(post =>
            post.Id == ContextFactory.PostIdForDelete));
        }

        [Fact]
        public async Task DeletePostCommand_FailOnWrongBlogId()
        {
            // Arrange
            var handler = new DeletePostCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new DeletePostCommand
                {
                    BlogId = Guid.NewGuid(),
                    UserId = ContextFactory.UserBId,
                    PostId = ContextFactory.PostIdForDelete
                }, CancellationToken.None));
        }

        [Fact]
        public async Task DeletePostCommand_FailOnWrongPostId()
        {
            // Arrange
            var handler = new DeletePostCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new DeletePostCommand
                {
                    BlogId = ContextFactory.BlogBId,
                    UserId = ContextFactory.UserBId,
                    PostId = Guid.NewGuid()
                }, CancellationToken.None));
        }


        [Fact]
        public async Task DeletePostCommand_FailOnWrongUserId()
        {
            // Arrange
            var handler = new DeletePostCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(new DeletePostCommand
                {
                    BlogId = ContextFactory.BlogBId,
                    UserId = Guid.NewGuid(),
                    PostId = ContextFactory.PostIdForDelete
                }, CancellationToken.None));
        }
    }
}
