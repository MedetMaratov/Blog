using BlogEngine.Application.Subscriptions.Command;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Subscriptions.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Subscriptions.Commands
{
    public class UnsubscribeFromBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UnsubscribeFromBlogCommandHandler_Success()
        {
            // Arrange
            var unsubscribeHandler = new UnsubscribeFromBlogCommandHandler(Context);
            var createSubscriptionHandler = new SubscribeToBlogCommandHandler(Context);

            // Act

            var newSubcsriptionId = await createSubscriptionHandler.Handle(new SubscribeToBlogCommand
            {
                BlogId = ContextFactory.BlogIdForUpdate,
                UserId = ContextFactory.UserAId
            }, CancellationToken.None);

            await unsubscribeHandler.Handle(new UnsubscribeFromBlogCommand
            {
                BlogId = ContextFactory.BlogIdForUpdate,
                UserId = ContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Subsсriptions.SingleOrDefaultAsync(subscription =>
            subscription.Id == newSubcsriptionId));
        }
    }
}
