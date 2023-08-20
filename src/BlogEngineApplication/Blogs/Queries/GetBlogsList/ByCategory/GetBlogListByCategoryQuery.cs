using MediatR;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCategory
{
    public class GetBlogListByCategoryQuery : IRequest<BlogListVM>
    {
        public string IncludedCategories { get; set; } = "";
        public string ExcludedCategories { get; set; } = "";

        public GetBlogListByCategoryQuery(string includedCategories, string excludedCategories)
        {
            IncludedCategories = includedCategories;
            ExcludedCategories = excludedCategories;
        }
    }
}
