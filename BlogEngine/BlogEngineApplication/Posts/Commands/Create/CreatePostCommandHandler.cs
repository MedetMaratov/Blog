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

        public CreatePostCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
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

            var post = new Post
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                CreatorId = request.UserId,
                CreatedAt = DateTime.UtcNow,
                Comments = new List<Comment>(),
                Blog = blogToPost,
                Tags = new List<Tag>()
            };

            foreach (var tag in request.TagTitles)
            {
                var existingTag = await _dbContext.Tags.FirstOrDefaultAsync(t => t.Title == tag);
                if (existingTag != null)
                {
                    post.Tags.Add(existingTag); 
                }
                else
                {
                    var newTag = new Tag
                    {
                        Title = tag
                    };
                    post.Tags.Add(newTag); 
                }
            }
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return post.Id;
        }
    }
}
