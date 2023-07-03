using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Posts.Commands.Delete;
using BlogEngineApplication.Posts.Commands.Edit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Posts.Commands
{
    public class EditPostCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task EditPostCommandHandler_Succes()
        {
            // Arrange
            var handler = new EditPostCommandHandler(Context);
            var newTags = new List<PostTag>();
            var newContent = "Edited";
            var newTitle = "New title";
            // Act
            await handler.Handle(new EditPostCommand
            {
                PostId = ContextFactory.PostIdForUpdate,
                Tags = newTags,
                Content = newContent,
                Title = newTitle,
                UserID = ContextFactory.UserBId

            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Posts.SingleOrDefaultAsync(post =>
                post.Id == ContextFactory.PostIdForUpdate && post.Content == newContent &&
                post.Title == newTitle));
        }

        [Fact]
        public async Task EditPostCommand_FailOnWrongPostId()
        {
            // Arrange
            var handler = new EditPostCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new EditPostCommand
                {
                    PostId = Guid.NewGuid(),
                    UserID = ContextFactory.UserBId,
                }, CancellationToken.None));
        }

        [Fact]
        public async Task EditPostCommand_FailOnWrongUserId()
        {
            // Arrange
            var handler = new EditPostCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(new EditPostCommand
                {
                    UserID = Guid.NewGuid(),
                    PostId = ContextFactory.PostIdForUpdate
                }, CancellationToken.None));
        }
    }
}
