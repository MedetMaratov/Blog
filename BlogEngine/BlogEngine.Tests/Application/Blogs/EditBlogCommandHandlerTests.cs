using AutoFixture;
using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using BlogEngineApplication.Blogs.Commands.EditBlog;
using BlogEngineApplication.Common.Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Blogs
{
    public class EditBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task EditBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new EditBlogCommandHandler(Context);
            var editCommand = Fixture.Build<EditBlogCommand>()
                .With(c => c.BlogId, BlogTestData.BlogIdA)
                .With(c => c.UserId, ContextFactory.UserAId)
                .With(c => c.Categories, new List<Category>())
                .Create();

            // Act
            await handler.Handle(editCommand, CancellationToken.None);

            // Assert
            var updatedBlog = await Context.Blogs
                .Include(b => b.Categories)
                .FirstOrDefaultAsync(b => b.Id == BlogTestData.BlogIdA);
            Assert.NotNull(updatedBlog);
            Assert.Equal(editCommand.Title, updatedBlog.Name);
            Assert.Equal(editCommand.Description, updatedBlog.Description);
            Assert.Equal(editCommand.Image, updatedBlog.Image);
            Assert.Equal(DateTime.Today, updatedBlog.Created.Date);
            Assert.Equal(DateTime.Today, updatedBlog.Edited?.Date);
        }

        [Fact]
        public async Task EditBlogCommandHandler_FailOnWrongId()
        {
            var handler = new EditBlogCommandHandler(Context);


            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new EditBlogCommand
                {
                    BlogId = Guid.NewGuid(),
                    UserId = ContextFactory.UserAId,
                }, CancellationToken.None));
        }

        [Fact]
        public async Task EditBlogCommandHandler_FailOnWrongUserId()
        {
            var handler = new EditBlogCommandHandler(Context);

            await Assert.ThrowsAsync<NotPermissionException>(async () =>
                await handler.Handle(
                    new EditBlogCommand
                    {
                        BlogId = BlogTestData.BlogIdA,
                        UserId = Guid.NewGuid()
                    }, CancellationToken.None));
        }
    }
}
