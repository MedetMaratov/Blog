using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineApplication.Comments.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequest<DeleteCommentCommand>
    {
        private readonly IBlogDbContext _dbContext;

        public DeleteCommentCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteCommentCommand request,
            CancellationToken cancellationToken)
        {
            var postWithComment = await _dbContext
                .Posts
                .FirstOrDefaultAsync(post => post.Id == request.PostId, cancellationToken);
            var comment = _dbContext
                .Comments
                .FirstOrDefault(comment => comment.Id == request.CommentId);
            if (comment == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }
            if (comment.UserId != request.UserId)
            {
                throw new NotPermissionException("You do not have permission to perform this action.");
            }
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
