using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using BlogEngineApplication.Categories.Create;
using BlogEngineApplication.Tags.Commands.Create;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Category.Commands
{
    public class CreateCategoryCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreatePostTagCommandHandler_Succes()
        {
            // Arrange
            var handler = new CreateCategoryCommandHandler(Context);
            var name = "Test category";
            // Act
            var tagId = await handler.Handle(
                new CreateCategoryCommand
                {
                    Name = name,
                },
                CancellationToken.None);
            // Assert
            Assert.NotNull(await Context.BlogCategories.SingleOrDefaultAsync(category =>
            category.Id == tagId && category.Name == name));
        }
    }
}
