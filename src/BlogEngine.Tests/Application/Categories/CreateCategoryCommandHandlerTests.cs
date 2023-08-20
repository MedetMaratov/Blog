using AutoFixture;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Categories.Create;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogEngine.Tests.Application.Categories
{
    public class CreateCategoryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCategoryCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateCategoryCommandHandler(Context);
            var categoryName = Fixture.Create<string>();

            // Act
            var categoryId = await handler.Handle(new CreateCategoryCommand
            {
                Name = categoryName,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Categories
                .SingleOrDefaultAsync(c => c.Id == categoryId && c.Name == categoryName));
        }
    }
}
