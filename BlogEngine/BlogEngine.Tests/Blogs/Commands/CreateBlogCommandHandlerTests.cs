using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Blogs.Commands
{
    public class CreateBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateBlogCommandHandler(Context);
            var name = "blog name";
            var description = "description";

            // Act
            var blogId = await handler.Handle(
                new CreateBlogCommand
                {
                    Title = name,
                    Description = description,
                    CategoriesId = new List<Guid>(),
                    Image = "SourceA",
                    UserId = ContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Blogs.SingleOrDefaultAsync(blog =>
                blog.Id == blogId && blog.Name == name &&
                blog.Description == description));
        }      
    }
}
