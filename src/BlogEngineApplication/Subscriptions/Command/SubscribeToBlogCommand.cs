using MediatR;

namespace BlogEngine.Application.Subscriptions.Command
{
    public class SubscribeToBlogCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }

        public SubscribeToBlogCommand(Guid userId, Guid blogId)
        {
            UserId = userId;
            BlogId = blogId;
        }
    }
}
