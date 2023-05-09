using BlogEngine.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Blogs.Queries.GetBlogDetails
{
    public class GetBlogDetailsQuery : IRequest<Blog>
    {
        public Guid BlogId { get; set; }
    }
}
