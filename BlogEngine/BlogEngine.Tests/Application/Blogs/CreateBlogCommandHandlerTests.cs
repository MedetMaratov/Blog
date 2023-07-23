using AutoFixture;
using BlogEngine.Domain.Entities;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Blogs
{
    public class CreateBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateBlogCommandHandler(Context);
            var createBlogCommand = Fixture.Build<CreateBlogCommand>()
                .With(b => b.CategoriesId, new List<Guid> { CategoryTestData.FirstCategoryId, CategoryTestData.SecondCategoryId })
                .Create();

            // Act
            var blogId = await handler.Handle(createBlogCommand, CancellationToken.None);

            // Assert
            var blog = await Context.Blogs
                .Include(b => b.Categories)
                .SingleOrDefaultAsync(b => b.Id == blogId);

            Assert.NotNull(blog);
            Assert.Equal(createBlogCommand.Title, blog.Name);
            Assert.Equal(createBlogCommand.Description, blog.Description);
            Assert.Equal(createBlogCommand.Image, blog.Image);
            Assert.Equal(DateTime.Today, blog.Created.Date);

            var categoryIds = blog.Categories.Select(c => c.Id).ToList();
            Assert.True(createBlogCommand.CategoriesId.SequenceEqual(categoryIds));
        }
    }
}
