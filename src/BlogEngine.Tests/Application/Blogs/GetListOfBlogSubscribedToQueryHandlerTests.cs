using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.Subscribed;
using Shouldly;
using Xunit;

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
            var result = await handler.Handle(
                new GetListOfBlogSubscribedToQuery(ContextFactory.UserAId), 
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }
    }
}
