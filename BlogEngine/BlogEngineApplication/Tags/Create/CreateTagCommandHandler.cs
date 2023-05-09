using BlogEngine.Domain.Entities;
using BlogEngineApplication.Categories.Create;
using BlogEngineApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Tags.Create
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly IBlogDbContext _dbContext;
        public CreateTagCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var tag = new PostTag
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            _dbContext.PostTags.Add(tag);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
