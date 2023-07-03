using BlogEngine.Application.Subscriptions.Command;
using BlogEngine.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Subscriptions.Commands
{
    public class SubscribeToBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task SubscribeToBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new SubscribeToBlogCommandHandler(Context);

            // Act
            var subscriptionId = await handler.Handle(new SubscribeToBlogCommand
            {
                UserId = ContextFactory.UserBId,
                BlogId = ContextFactory.BlogBId,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Subsсription.SingleOrDefaultAsync(subscription =>
            subscription.Id == subscriptionId && 
            subscription.BlogId == ContextFactory.BlogBId 
            && subscription.UserId == ContextFactory.UserBId));
        }
    }
}
