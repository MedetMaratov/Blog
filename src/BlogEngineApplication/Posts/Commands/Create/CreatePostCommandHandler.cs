using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineApplication.Posts.Commands.Create
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ITagService _tagService;

        public CreatePostCommandHandler(IBlogDbContext dbContext, ITagService tagService)
        {
            _dbContext = dbContext;
            _tagService = tagService;
        }

        public async Task<Guid> Handle(CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var blogToPost = await _dbContext.Blogs
                .FirstOrDefaultAsync(b => b.Id == request.BlogId, cancellationToken);
            
            if (blogToPost == null)
            {
                throw new NotFoundException(nameof(blogToPost), request.BlogId);
            }
            if (blogToPost.CreatorId != request.UserId)
            {
                throw new NotPermissionException("You do not have permission to perform this action.");
            }

            var post = new Post(request.UserId, request.Title, request.Content, request.BlogId);
            await _tagService.AddTags(post, request.TagTitles);
            await _dbContext.Posts.AddAsync(post, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return post.Id;
        }
    }
}
