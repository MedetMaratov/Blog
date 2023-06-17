using BlogEngine.Application.Subscriptions.Command;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Subscriptions.Command
{
    public class UnsubscribeFromBlogCommandHandler : IRequestHandler<UnsubscribeFromBlogCommand>
    {
        private readonly IBlogDbContext _dbContext;

        public UnsubscribeFromBlogCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UnsubscribeFromBlogCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _dbContext.Subsсription
                .FirstOrDefaultAsync(s => s.BlogId == request.BlogId
                && s.UserId == request.UserId, cancellationToken);

            if (subscription != null)
            {
                _dbContext.Subsсription.Remove(subscription);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
