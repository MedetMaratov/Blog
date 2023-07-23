using AutoFixture;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Comments.Commands.Create;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Comments
{
    public class CreateCommentCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCommentCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateCommentCommandHandler(Context);
            var commentText = Fixture.Create<string>();
            // Act
            var commentId = await handler.Handle(new CreateCommentCommand
            {
                Content = commentText,
                UserId = ContextFactory.UserAId,
                PostId = PostTestData.PostIdB
            }, CancellationToken.None);
            // Assert
            Assert.NotNull(await Context.Comments
                .SingleOrDefaultAsync(c => c.Id == commentId && c.Content == commentText && 
                c.CreatedAt.Date == DateTime.Today && c.UserId == ContextFactory.UserAId &&
                c.PostId == PostTestData.PostIdB));
        }
    }
}
