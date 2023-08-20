using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;

namespace BlogEngine.Application.Subscriptions.Command
{
    public class SubscribeToBlogCommandHandler : IRequestHandler<SubscribeToBlogCommand, Guid>
    {
        private readonly IBlogDbContext _dbContext;

        public SubscribeToBlogCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(SubscribeToBlogCommand request, CancellationToken cancellationToken)
        {
            var subscription = new Subscription(request.UserId, request.BlogId);
            
            await _dbContext.Subsсriptions.AddAsync(subscription, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return subscription.Id;
        }
    }
}
