using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.All;
using Shouldly;
using Xunit;

namespace BlogEngine.Tests.Application.Blogs
{
    [Collection("QueryCollection")]
    public class GetAllBlogsListQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBlogsListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllBlogsListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllBlogListQuerieHandler(_context, _mapper);
            const int expectedNumberOfBlogs = 2;
            // Act
            var result = await handler.Handle(new GetAllBlogsListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }
    }
}
