using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngine.Persistence;
using BlogEngine.Tests.Common;
using BlogEngineApplication.Categories.Get;
using Shouldly;
using Xunit;

namespace BlogEngine.Tests.Application.Categories
{
    [Collection("QueryCollection")]

    public class GetAllCategoriesQueryHandlerTests
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandlerTests(QueryTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public async Task GetAllCategoriesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllCategoriesQueryHandler(_context);
            const int expectedCategoriesNumber = 3;

            // Act
            var result = await handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<Category>>();
            result.Count.ShouldBe(expectedCategoriesNumber);
        }
    }
}
