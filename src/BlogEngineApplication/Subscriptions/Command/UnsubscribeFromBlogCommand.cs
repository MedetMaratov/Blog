using MediatR;

namespace BlogEngineApplication.Subscriptions.Command
{
    public class UnsubscribeFromBlogCommand : IRequest
    {
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }


        public UnsubscribeFromBlogCommand(Guid blogId, Guid userId)
        {
            BlogId = blogId;
            UserId = userId;
        }
    }
}
