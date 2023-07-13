using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Posts.Commands.Create;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogEngine.Tests.Posts.Commands
{
    public class CreatePostCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePostCommandHandler_Success()
        {
            // Arrange
            var handler = new CreatePostCommandHandler(Context);
            var title = "title";
            var postContent = "Content";
            var tags = new List<string>();

            // Act
            var postId = await handler.Handle(new CreatePostCommand
            {
                BlogId = ContextFactory.BlogBId,
                Title = title,
                Content = postContent,
                TagTitles = tags,
                UserId = ContextFactory.UserBId
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Posts.SingleOrDefaultAsync(post =>
                post.Id == postId && post.Title == title && post.Content == postContent));
        }

        [Fact]
        public async Task CreatePostCommand_FailOnNonExistentBlog()
        {
            // Arrange
            var handler = new CreatePostCommandHandler(Context);

            // Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreatePostCommand
                    {
                        BlogId = Guid.NewGuid(),
                        UserId = ContextFactory.UserBId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task CreatePostCommand_FailOnWrongUserId()
        {
            // Arrange
            var handler = new CreatePostCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(new CreatePostCommand
                {
                    BlogId = ContextFactory.BlogBId,
                    UserId = ContextFactory.UserAId
                }, CancellationToken.None));

        }
    }
}
