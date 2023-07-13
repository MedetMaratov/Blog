using BlogEngine.Domain;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                BlogId = request.BlogId,
                UserId = request.UserId
            };

            await _dbContext.Subsсriptions.AddAsync(subscription, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return subscription.Id;
        }
    }
}
