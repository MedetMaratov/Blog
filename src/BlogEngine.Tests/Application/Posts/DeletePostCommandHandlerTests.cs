using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Posts.Commands.Delete;
using Xunit;

namespace BlogEngine.Tests.Application.Posts
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
                BlogId = BlogTestData.BlogIdB,
                UserId = ContextFactory.UserBId,
                PostId = PostTestData.PostIdB
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Posts.SingleOrDefault(post =>
            post.Id == PostTestData.PostIdB));
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
                    PostId = PostTestData.PostIdB
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
                    BlogId = BlogTestData.BlogIdB,
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
                    BlogId = BlogTestData.BlogIdB,
                    UserId = Guid.NewGuid(),
                    PostId = PostTestData.PostIdB
                }, CancellationToken.None));
        }
    }
}
