using AutoMapper;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngine.Tests.Common.TestData;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCategory;
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
    public class GetBlogListByCategoryQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetBlogListByCategoryQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBlogListByCategoryQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBlogListByCategoryQueryHandler(_context, _mapper);
            const int expectedNumberOfBlogs = 1;

            // Act
            var result = await handler.Handle(new GetBlogListByCategoryQuery
            {
                IncludedCategories = CategoryTestData.CategoryA.Name
            }, CancellationToken.None);

            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }


        [Fact]
        public async Task GetBlogListByCategoryQueryHandler_ZeroBlogs()
        {
            // Arrange
            var handler = new GetBlogListByCategoryQueryHandler(_context, _mapper);
            const int expectedNumberOfBlogs = 0;

            // Act
            var result = await handler.Handle(new GetBlogListByCategoryQuery
            {
                ExcludedCategories = CategoryTestData.CategoryA.Name
            }, CancellationToken.None);

            result.ShouldBeOfType<BlogListVM>();
            result.Blogs.Count.ShouldBe(expectedNumberOfBlogs);
        }
    }
}
