using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using MediatR;

namespace BlogEngineApplication.Blogs.Queries.GetBlogDetails
{
    public class GetBlogDetailsQuery : IRequest<BlogLookupDto>
    {
        public Guid BlogId { get; set; }

        public GetBlogDetailsQuery(Guid blogId)
        {
            BlogId = blogId;
        }
    }
}
