using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Posts.Queries.GetPostDetails;
using Xunit;

namespace BlogEngine.Tests.Application.Posts
{
    [Collection("QueryCollection")]
    public class GetPostDetailsQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetPostDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPostDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPostDetailsQueryHandler(_context, _mapper);

            // Act
            var result = await handler.Handle(
                new GetPostDetailsQuery(PostTestData.PostIdA), 
                CancellationToken.None);

            // Assert
            Assert.Equal(result.Title, PostTestData.PostA.Title);
            Assert.Equal(result.Content, PostTestData.PostA.Content);

            // Assert that the Tags lists are equal using custom comparer
            Assert.True(PostTestData.PostA.Tags.Select(tag => tag.Title).SequenceEqual(result.Tags));
        }
    }
}
