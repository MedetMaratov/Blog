using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Posts.Queries;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Posts.Queries
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

            // Act
            var result = await handler.Handle(new GetPostsByBlogIdQuery
            {
                BlogId = ContextFactory.BlogBId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PostListVM>();
            result.Posts.Count.ShouldBe(3);
        }
    }
}
