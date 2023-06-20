using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogDetails;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Blogs.Queries
{
    [Collection("QueryCollection")]
    public class GetBlogDetailsQuerieHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogDetailsQuerieHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBlogDetailsQuerieHandler_Succes()
        {
            // Arrange
            var handler = new GetBlogDetailsQueryHandler(_context);

            // Act
            var result = await handler.Handle(new GetBlogDetailsQuery
            {
                BlogId = ContextFactory.BlogBId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<Blog>();
            result.Name.ShouldBe("Name2");
            result.Description.ShouldBe("DescriptionA");
            result.Image.ShouldBe("SourceA");
        }
    }
}
