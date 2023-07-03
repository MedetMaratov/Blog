using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using BlogEngineApplication.Tags.Commands.Create;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Tags.Commands.Create
{
    public class CreatePostTagCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreatePostTagCommandHandler_Succes()
        {
            // Arrange
            var handler = new CreatePostTagCommandHandler(Context);
            var title = "Test title";
            var postId = ContextFactory.PostAId;
            // Act
            var tagId = await handler.Handle(
                new CreatePostTagCommand
                {
                    PostId = postId,
                    Title = title
                },
                CancellationToken.None);
            // Assert
            Assert.NotNull(await Context.PostTags.SingleOrDefaultAsync(tag => tag.Id == tagId &&
            tag.Title == title && tag.PostId == postId));
        }
    }
}
