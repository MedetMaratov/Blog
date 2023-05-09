using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (postWithComment != null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }
            var comment = _dbContext
                .Comments
                .Where(comment => comment.UserId == request.UserId)
                .FirstOrDefault(comment => comment.Id == request.CommentId);
            postWithComment.Comments.Remove(comment);
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
