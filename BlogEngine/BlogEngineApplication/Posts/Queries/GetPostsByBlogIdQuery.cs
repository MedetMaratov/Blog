using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Queries
{
    public class GetPostsByBlogIdQuery : IRequest<PostListVM>
    {
        public Guid BlogId { get; set; }
    }
}
