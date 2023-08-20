using MediatR;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.Subscribed
{
    public class GetListOfBlogSubscribedToQuery : IRequest<BlogListVM>
    {
        public Guid UserId { get; set; }

        public GetListOfBlogSubscribedToQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
