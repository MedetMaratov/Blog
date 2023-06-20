using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByName;
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
    public class GetBlogsListByNameQueryHandlerTests 
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogsListByNameQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBlogsListByNameQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBlogsListByNameQueryHandler(_context, _mapper);
            var blogName = "Name1";

            // Act
            var result = await handler.Handle(new GetBlogsListBuNameQuery
            {
                Name = blogName
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(1);
        }
    }
}
