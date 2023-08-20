using MediatR;

namespace BlogEngineApplication.Posts.Queries.GetSubscribedBlogPosts
{
    public class GetSubscribedBlogPostsQuery : IRequest<PostListVM>
    {
        public Guid UserId { get; set; }

        public GetSubscribedBlogPostsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
