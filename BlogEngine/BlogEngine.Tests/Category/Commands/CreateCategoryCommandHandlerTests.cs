using BlogEngine.Tests.Common;
using BlogEngineApplication.Categories.Create;
using Microsoft.EntityFrameworkCore;
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
            var caregoryId = await handler.Handle(
                new CreateCategoryCommand
                {
                    Name = name,
                },
                CancellationToken.None);
            // Assert
            Assert.NotNull(await Context.BlogCategories.SingleOrDefaultAsync(category =>
            category.Id == caregoryId && category.Name == name));
        }
    }
}
