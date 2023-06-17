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

namespace BlogEngineApplication.Comments.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly IBlogDbContext _dbContext;

        public CreateCommentCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateCommentCommand request,
            CancellationToken cancellationToken)
        {
            var post = await _dbContext
                .Posts
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == request.PostId, cancellationToken);

            if (post == null)
            {
                throw new NotFoundException(nameof(post), request.PostId);
            }

            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                Content = request.Content,
                CreatedAt = DateTime.Now,
                UserId = request.UserId,
                PostId = request.PostId,
            };

            post.Comments.Add(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }

    }
}
