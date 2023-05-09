using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.Subscribed
{
    public class GetListOfBlogSubscribedToQuery : IRequest<BlogListVM>
    {
        public Guid UserId { get; set; }
    }
}
