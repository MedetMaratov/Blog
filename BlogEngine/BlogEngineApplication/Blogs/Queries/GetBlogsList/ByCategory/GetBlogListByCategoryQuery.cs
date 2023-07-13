using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCategory
{
    public class GetBlogListByCategoryQuery : IRequest<BlogListVM>
    {
        public string IncludedCategories { get; set; } = "";
        public string ExcludedCategories { get; set; } = "";
    }
}
