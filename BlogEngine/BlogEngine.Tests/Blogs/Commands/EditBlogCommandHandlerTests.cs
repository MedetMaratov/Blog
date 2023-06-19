using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Commands.EditBlog;
using BlogEngineApplication.Common.Exeptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Blogs.Commands
{
    public class EditBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task EditBlogCommandHandler_Succes()
        {
            // Arrange
            var handler = new EditBlogCommandHandler(Context);
            var updatedTitle = "new title";
            var updatedDescription = "new description";

            // Act
            await handler.Handle(new EditeBlogCommand
            {
                BlogId = ContextFactory.BlogIdForUpdate,
                UserId = ContextFactory.UserAId,
                Title = updatedTitle,
                Description = updatedDescription,
                Categories = new List<BlogCategory>()
            }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Blogs.SingleOrDefaultAsync(blog =>
                blog.Id == ContextFactory.BlogIdForUpdate &&
                blog.Name == updatedTitle && blog.Description == updatedDescription));
        }

        [Fact]
        public async Task EditBlogCommandHandler_FailOnWrongId()
        {
            var handler = new EditBlogCommandHandler(Context);


            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new EditeBlogCommand
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
                    new EditeBlogCommand
                    {
                        BlogId = ContextFactory.BlogIdForWrongUserIdTest,
                        UserId = ContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
