using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Commands.Create
{
    public class CreatePostCommandHandler : IRequest<CreatePostCommand>
    {
        private readonly IBlogDbContext _dbContext;

        public CreatePostCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var blogToPost = await _dbContext.Blogs
                .FindAsync(new object[] { request.BlogId }, cancellationToken);
            if (blogToPost == null)
            {
                throw new NotFoundException(nameof(blogToPost), request.BlogId);
            }
            if (blogToPost.CreatorId != request.UserId)
            {
                throw new NotPermissionException("You do not have permission to perform this action.");
            }
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                CreatorId = request.UserId,
                CreatedAt = DateTime.UtcNow,
                Comments = new List<Comment>(),
                BlogId = request.BlogId,
                Tags = request.Tags
            };
            blogToPost.Posts.Add(post);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
