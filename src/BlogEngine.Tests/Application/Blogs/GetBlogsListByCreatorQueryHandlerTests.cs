using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCreator;
using Shouldly;
using Xunit;

namespace BlogEngine.Tests.Application.Blogs
{
    [Collection("QueryCollection")]
    public class GetBlogsListByCreatorQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogsListByCreatorQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBlogsListByCreatorQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBlogsListByCreatorQueryHandler(_context, _mapper);
            const int expectedNumberOfBlogs = 1;

            // Act
            var result = await handler.Handle(
                new GetBlogsListByCreatorQuery(ContextFactory.UserAId), 
                CancellationToken.None);

            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }

        [Fact]
        public async Task GetBlogsListByCreatorQueryHandler_ZeroBlogsWhenNonExictentCreator()
        {
            // Arrange
            var handler = new GetBlogsListByCreatorQueryHandler(_context, _mapper);
            const int expectedNumberOfBlogs = 0;

            // Act
            var result = await handler.Handle(
                new GetBlogsListByCreatorQuery(Guid.NewGuid()), 
                CancellationToken.None);

            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }
    }
}
