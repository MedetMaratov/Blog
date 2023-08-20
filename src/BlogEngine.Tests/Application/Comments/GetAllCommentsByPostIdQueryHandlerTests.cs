﻿using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Comments.Queries;
using Shouldly;
using Xunit;

namespace BlogEngine.Tests.Application.Comments
{
    [Collection("QueryCollection")]
    public class GetAllCommentsByPostIdQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCommentsByPostIdQueryHandlerTests(QueryTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public async Task GetAllCommentsByPostIdQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllCommentsByPostIdQueryHandler(_context, _mapper);
            const int expectedCategoriesNumber = 2;

            // Act
            var result = await handler.Handle(
                new GetAllCommentsByPostIdQuery(PostTestData.PostIdA), 
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CommentsListVm>();
            result.Comments.Count.ShouldBe(expectedCategoriesNumber);
        }
    }
}