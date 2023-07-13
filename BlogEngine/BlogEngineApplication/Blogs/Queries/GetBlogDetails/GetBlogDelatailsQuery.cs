using BlogEngine.Domain.Entities;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Blogs.Queries.GetBlogDetails
{
    public class GetBlogDetailsQuery : IRequest<BlogLookupDto>
    {
        public Guid BlogId { get; set; }
    }
}
