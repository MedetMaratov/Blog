using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineApplication.Posts.Commands.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IBlogDbContext _dbContext;

        public DeletePostCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var blog = await _dbContext.Blogs.Include(b => b.Posts)
                .FirstOrDefaultAsync(b => b.Id == request.BlogId);
            if (blog == null)
            {
                throw new NotFoundException(nameof(Blog), request.BlogId);
            }
            var post = blog.Posts.FirstOrDefault(post => post.Id == request.PostId);

            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }
            if (blog.CreatorId != request.UserId)
            {
                throw new NotPermissionException("You do not have permission to perform this action.");
            }
            blog.Posts.Remove(post);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
