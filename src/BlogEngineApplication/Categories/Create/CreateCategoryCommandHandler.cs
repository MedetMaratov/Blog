using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;

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
            var category = new Category(request.Name);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
