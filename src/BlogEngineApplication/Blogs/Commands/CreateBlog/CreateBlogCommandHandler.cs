using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;

namespace BlogEngineApplication.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
    {
        private readonly IBlogDbContext _dbContext;

        public CreateBlogCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateBlogCommand request,
            CancellationToken cancellationToken)
        {
            var categories = _dbContext.Categories.Where(category =>
            request.CategoriesId.Contains(category.Id)).ToList();
            var blog = new Blog(request.Name, request.UserId, request.Description, request.Image);
            blog.Categories = categories;
            await _dbContext.Blogs.AddAsync(blog, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return blog.Id;
        }
    }
}
