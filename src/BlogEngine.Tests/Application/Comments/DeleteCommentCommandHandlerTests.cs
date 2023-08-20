using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Comments.Commands.Delete;
using BlogEngineApplication.Common.Exeptions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogEngine.Tests.Application.Comments
{
    public class DeleteCommentCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCommentCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteCommentCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteCommentCommand
            {
                CommentId = CommentsTestData.CommentIdA,
                PostId = PostTestData.PostIdA,
                UserId = ContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Comments
                .SingleOrDefaultAsync(c => c.Id == CommentsTestData.CommentIdA));
        }

        [Fact]
        public async Task DeleteCommentCommandHandler_FailWhenTheUserWantDeleteNonOwnComment()
        {
            // Arrange
            var handler = new DeleteCommentCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(
                   new DeleteCommentCommand
                   {
                       CommentId = CommentsTestData.CommentIdA,
                       PostId = PostTestData.PostIdA,
                       UserId = ContextFactory.UserBId
                   }, CancellationToken.None));
        }
        [Fact]
        public async Task DeleteCommentCommandHandler_FailWhenCommentDoesNotExist()
        {
            // Arrange
            var handler = new DeleteCommentCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                   new DeleteCommentCommand
                   {
                       CommentId = Guid.NewGuid(),
                       PostId = PostTestData.PostIdA,
                       UserId = ContextFactory.UserAId
                   }, CancellationToken.None));
        }
    }
}
