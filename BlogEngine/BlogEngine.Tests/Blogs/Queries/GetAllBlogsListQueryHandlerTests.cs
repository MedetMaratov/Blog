using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.All;
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
    public class GetAllBlogsListQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBlogsListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetAllBlogsListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllBlogListQuerieHandler(_context, _mapper);

            // Act
            var result = await handler.Handle(new GetAllBlogsListQuery { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(4);
        }
    }
}
