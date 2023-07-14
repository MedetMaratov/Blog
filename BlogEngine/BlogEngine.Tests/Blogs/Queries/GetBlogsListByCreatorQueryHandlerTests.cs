using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCreator;
using BlogEngineApplication.Posts.Queries;
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
    public class GetBlogsListByCreatorQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogsListByCreatorQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBlogsListByCreatorQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBlogsListByCreatorQueryHandler(_context, _mapper);

            // Act
            var result = await handler.Handle(new GetBlogsListByCategoryQuery
            {
                CreatorId = ContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(3);
        }
    }
}
