using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Tags.Commands.Create
{
    public class CreatePostTagCommandHandler : IRequestHandler<CreatePostTagCommand, Guid>
    {
        private readonly IBlogDbContext _dbContext;

        public CreatePostTagCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreatePostTagCommand request,
            CancellationToken cancellationToken)
        {
            var tag = new PostTag
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                PostId = request.PostId,
            };

            _dbContext.PostTags.Add(tag);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return tag.Id;

        }
    }
}
