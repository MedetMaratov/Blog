using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Posts.Queries;
using BlogEngineApplication.Posts.Queries.GetSubscribedBlogPosts;
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

    public class GetSubscribedBlogPostsQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscribedBlogPostsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetSubscribedBlogPostsQueryHandler()
        {
            // Arrange
            var handler = new GetSubscribedBlogPostsQueryHandler(_context, _mapper);
            const int expectedNumberOfPosts = 1;

            // Act
            var result = await handler.Handle(new GetSubscribedBlogPostsQuery
            {
                UserId = ContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PostListVM>();
            result.Posts.Count.ShouldBe(expectedNumberOfPosts);
        }
    }
}
