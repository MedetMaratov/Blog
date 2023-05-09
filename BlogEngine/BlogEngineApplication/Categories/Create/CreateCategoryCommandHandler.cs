using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Categories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IBlogDbContext _dbContext;

        public CreateCategoryCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new BlogCategory
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            _dbContext.BlogCategories.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
