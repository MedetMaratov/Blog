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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IBlogDbContext _dbContext;

        public CreateCategoryCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
