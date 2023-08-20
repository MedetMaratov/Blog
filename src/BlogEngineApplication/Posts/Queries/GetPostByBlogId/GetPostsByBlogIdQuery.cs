using MediatR;

namespace BlogEngineApplication.Posts.Queries.GetPostByBlogId
{
    public class GetPostsByBlogIdQuery : IRequest<PostListVM>
    {
        public Guid BlogId { get; set; }

        public GetPostsByBlogIdQuery(Guid blogId)
        {
            BlogId = blogId;
        }
    }
}
