using AutoFixture;
using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using BlogEngineApplication.Posts.Commands.Create;
using BlogEngineApplication.Posts.Commands.Edit;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Posts
{
    public class EditPostCommandHandlerTests : TestCommandBase
    {
        private readonly ITagService _tagService;
        private Fixture fixture;
        public EditPostCommandHandlerTests()
        {
            var tagServiceMock = new Mock<ITagService>();
            _tagService = tagServiceMock.Object;
            fixture= new Fixture();
        }
        [Fact]
        public async Task EditPostCommandHandler_Succes()
        {
            // Arrange
            var handler = new EditPostCommandHandler(Context, _tagService);
            var editCommand =Fixture.Build<EditPostCommand>()
                .With(p => p.PostId, PostTestData.PostIdB)
                .With(p => p.UserID, ContextFactory.UserBId)
                .Create();
            // Act
            await handler.Handle(editCommand, CancellationToken.None);

            // Assert
            var updatedPost = await Context.Posts.FindAsync(editCommand.PostId);

            Assert.NotNull(updatedPost);
            Assert.Equal(editCommand.Title, updatedPost.Title);
            Assert.Equal(editCommand.Content, updatedPost.Content);
            Assert.Equal(DateTime.Today, updatedPost.CreatedAt.Date);
            Assert.Equal(DateTime.Today, updatedPost.EditedAt?.Date);
        }

        [Fact]
        public async Task EditPostCommand_FailOnWrongPostId()
        {
            // Arrange
            var handler = new EditPostCommandHandler(Context, _tagService);

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
            var handler = new EditPostCommandHandler(Context, _tagService);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(new EditPostCommand
                {
                    UserID = Guid.NewGuid(),
                    PostId = PostTestData.PostIdB
                }, CancellationToken.None));
        }
    }
}
