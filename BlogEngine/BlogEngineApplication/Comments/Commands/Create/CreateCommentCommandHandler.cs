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
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                Content = request.Content,
                CreatedAt = DateTime.Now,
                UserId = request.UserId,
                PostId = request.PostId,
            };

            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }

    }
}
