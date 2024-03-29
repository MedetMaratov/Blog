﻿using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Posts.Queries;
using BlogEngineApplication.Posts.Queries.GetPostByBlogId;
using Shouldly;
using Xunit;

namespace BlogEngine.Tests.Application.Posts
{
    [Collection("QueryCollection")]
    public class GetPostsByBlogIdQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsByBlogIdQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPostsByBlogIdQueryHandler_Succes()
        {
            // Arrange
            var handler = new GetPostsByBlogIdQueryHandler(_context, _mapper);
            const int expectedNumberOfPosts = 2;

            // Act
            var result = await handler.Handle(
                new GetPostsByBlogIdQuery(BlogTestData.BlogIdA),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PostListVM>();
            result.Posts.Count.ShouldBe(expectedNumberOfPosts);
        }
    }
}
