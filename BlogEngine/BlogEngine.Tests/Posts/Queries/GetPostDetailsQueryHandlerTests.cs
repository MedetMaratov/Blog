using AutoMapper;
using BlogEngine.Application.Posts.Queries;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
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
        public async Task GetPostDetailsQueryHandler_Succes()
        {
            // Arrange
            var handler = new GetPostDetailsQueryHandler(_context);

            // Act
            var result = await handler.Handle(new GetPostDetailsQuery
            {
                PostId = ContextFactory.PostAId
            }, CancellationToken.None);

            // Assert
            result.Content.ShouldBe("ContentA");
            result.Title.ShouldBe("TitleA");
            result.CreatedAt.ShouldBe(DateTime.Today);
            result.EditedAt.ShouldBe(null);

        }
    }
}
