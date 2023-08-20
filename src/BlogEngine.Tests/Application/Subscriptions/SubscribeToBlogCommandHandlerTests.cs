using BlogEngine.Application.Subscriptions.Command;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogEngine.Tests.Application.Subscriptions
{
    public class SubscribeToBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task SubscribeToBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new SubscribeToBlogCommandHandler(Context);

            // Act
            var subId = await handler.Handle(
                new SubscribeToBlogCommand(ContextFactory.UserBId, BlogTestData.BlogIdA), 
                CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Subsсriptions
                .SingleOrDefaultAsync(s => s.Id == subId &&
                s.UserId == ContextFactory.UserBId && s.BlogId == BlogTestData.BlogIdA));
        }
    }
}
