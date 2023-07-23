﻿using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Subscriptions.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Subscriptions
{
    public class UnsubscribeFromBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UnsubscribeFromBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new UnsubscribeFromBlogCommandHandler(Context);

            // Act
            await handler.Handle(new UnsubscribeFromBlogCommand
            {
                UserId = ContextFactory.UserAId,
                BlogId = BlogTestData.BlogIdB
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Subsсriptions.SingleOrDefaultAsync(s =>
            s.UserId == ContextFactory.UserAId && s.BlogId == BlogTestData.BlogIdB));
        }

    }
}
