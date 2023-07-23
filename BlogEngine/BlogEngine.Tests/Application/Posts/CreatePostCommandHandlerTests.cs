using AutoFixture;
using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using BlogEngineApplication.Posts.Commands.Create;
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
    public class CreatePostCommandHandlerTests : TestCommandBase
    {
        private readonly ITagService _tagService;
        public CreatePostCommandHandlerTests()
        {
            var tagServiceMock = new Mock<ITagService>();
            _tagService = tagServiceMock.Object;
        }
        [Fact]
        public async Task CreatePostCommandHandler_Success()
        {
            // Arrange
            var handler = new CreatePostCommandHandler(Context, _tagService);
            var createCommand = Fixture.Build<CreatePostCommand>()
                .With(p => p.BlogId, BlogTestData.BlogIdA)
                .With(p => p.UserId, ContextFactory.UserAId)
                .Create();
            // Act
            var postId = await handler.Handle(createCommand, CancellationToken.None);
            // Assert
            var createdPost = await Context.Posts.FindAsync(postId);

            Assert.NotNull(createdPost);
            Assert.Equal(createCommand.Title, createdPost.Title);
            Assert.Equal(createCommand.Content, createdPost.Content);
            Assert.Equal(DateTime.Today, createdPost.CreatedAt.Date);
        }

        [Fact]
        public async Task CreatePostCommand_FailOnNonExistentBlog()
        {
            // Arrange
            var handler = new CreatePostCommandHandler(Context, _tagService);

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
            var handler = new CreatePostCommandHandler(Context, _tagService);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(new CreatePostCommand
                {
                    BlogId = BlogTestData.BlogIdB,
                    UserId = ContextFactory.UserAId
                }, CancellationToken.None));

        }
    }
}
