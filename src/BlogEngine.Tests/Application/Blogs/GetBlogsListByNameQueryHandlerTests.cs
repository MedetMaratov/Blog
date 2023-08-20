using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByName;
using Shouldly;
using Xunit;

namespace BlogEngine.Tests.Application.Blogs
{
    [Collection("QueryCollection")]

    public class GetBlogsListByNameQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogsListByNameQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetBlogsListByNameQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBlogsListByNameQueryHandler(_context, _mapper);
            const int expectedNumberOfBlogs = 1;

            // Act
            var result = await handler.Handle(
                new GetBlogsListBuNameQuery(BlogTestData.BlogA.Name), 
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }

        [Fact]
        public async Task GetBlogsListByNameQueryHandler_ZeroBlogsWhenNonExistentName()
        {
            // Arrange
            var handler = new GetBlogsListByNameQueryHandler(_context, _mapper);
            const int expectedNumberOfBlogs = 0;

            // Act
            var result = await handler.Handle(
                new GetBlogsListBuNameQuery(Guid.NewGuid().ToString()), 
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }
    }
}
