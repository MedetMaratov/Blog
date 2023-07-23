using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Blogs.Queries.GetBlogDetails;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogEngine.Tests.Application.Blogs
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
        public async Task GetBlogDetailsQuerieHandler_Succces()
        {
            // Arrange
            var handler = new GetBlogDetailsQueryHandler(_context, _mapper);
            var blogForUpdate = BlogTestData.BlogA;
            // Act
            var result = await handler.Handle(new GetBlogDetailsQuery
            {
                BlogId = BlogTestData.BlogIdA
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogLookupDto>();
            result.Title.ShouldBe(BlogTestData.BlogA.Name);
            result.Description.ShouldBe(BlogTestData.BlogA.Description);
            result.Image.ShouldBe(BlogTestData.BlogA.Image);
            result.Created.ShouldBe(BlogTestData.BlogA.Created);
        }
    }
}
