using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByName;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.Subscribed;
using Shouldly;

namespace BlogEngine.Tests.Application.Blogs
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
            const int expectedNumberOfBlogs = 1;

            // Act
            var result = await handler.Handle(new GetListOfBlogSubscribedToQuery
            {
                UserId = ContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }
    }
}
