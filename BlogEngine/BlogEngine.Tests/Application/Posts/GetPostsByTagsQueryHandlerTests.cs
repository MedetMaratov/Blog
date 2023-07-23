using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Posts.Queries;
using BlogEngineApplication.Posts.Queries.GetByTags;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Posts
{
    [Collection("QueryCollection")]
    public class GetPostsByTagsQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsByTagsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPostsByTagQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPostsByTagsQueryHandler(_context, _mapper);
            const int expectedNumberOfPosts = 2;

            // Act
            var result = await handler.Handle(new GetPostsByTagsQuery
            {
                IncludedTags = "tag1;tag2"
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PostListVM>();
            result.Posts.Count.ShouldBe(expectedNumberOfPosts);
        }
    }
}
