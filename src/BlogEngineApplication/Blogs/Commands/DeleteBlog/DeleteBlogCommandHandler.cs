using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;

namespace BlogEngineApplication.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
    {
        private readonly IBlogDbContext _dbContext;

        public DeleteBlogCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blogForDelete = await _dbContext.Blogs.
                FindAsync(new object[] { request.BlogId }, cancellationToken);

            if (blogForDelete == null)
            {
                throw new NotFoundException(nameof(blogForDelete), request.BlogId);
            }
            if (blogForDelete.CreatorId != request.UserId)
            {
                throw new NotPermissionException("You do not have permission to perform this action.");
            }

            _dbContext.Blogs.Remove(blogForDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
