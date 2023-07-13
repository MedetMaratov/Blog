using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Queries.GetSubscribedBlogPosts
{
    public class GetSubscribedBlogPostsQuery : IRequest<PostListVM>
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }

    }
}
