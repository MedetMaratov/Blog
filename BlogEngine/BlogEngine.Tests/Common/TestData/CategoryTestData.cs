using BlogEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Tests.Common.TestData
{
    public static class CategoryTestData
    {
        public static Guid FirstCategoryId { get; } = Guid.NewGuid();
        public static Guid SecondCategoryId { get; } = Guid.NewGuid();
        public static Guid CategoryAId { get; } = Guid.NewGuid();

        public static Category FirstCategory => new Category { Id = FirstCategoryId, Name = "first" };
        public static Category SecondCategory => new Category { Id = SecondCategoryId, Name = "second" };
        public static Category CategoryA => new Category { Id = CategoryAId, Name = "test categoryA" };
    }
}
