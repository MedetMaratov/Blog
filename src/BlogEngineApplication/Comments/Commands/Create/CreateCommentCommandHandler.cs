    using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;

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
            var comment = new Comment(request.Content, request.UserId, request.PostId);
            await _dbContext.Comments.AddAsync(comment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }

    }
}
