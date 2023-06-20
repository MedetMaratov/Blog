using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.Subscribed;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Blogs.Queries
{
    [Collection("QueryCollection")]
    public class GetListOfBlogSubscribedToQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetListOfBlogSubscribedToQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetListOfBlogSubscribedToQueryHandler_Success()
        {
            // Arrange
            var handler = new GetListOfBlogSubscribedToQueryHandler(_context, _mapper);

            // Act
            var result = await handler.Handle(new GetListOfBlogSubscribedToQuery
            {
                UserId = ContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(2);
        }
    }
}
