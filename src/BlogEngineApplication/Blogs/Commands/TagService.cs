using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineApplication.Blogs.Commands
{
    public class TagService : ITagService
    {
        private readonly IBlogDbContext _dbContext;

        public TagService(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddTags(Post post, IEnumerable<string> tags)
        {
            foreach (var tag in tags)
            {
                var existingTag = await _dbContext.Tags.FirstOrDefaultAsync(t => t.Title == tag);
                if (existingTag != null)
                {
                    post.Tags.Add(existingTag);
                }
                else
                {
                    var newTag = new Tag(tag);
                    post.Tags.Add(newTag);
                }
            }
        }
    }
}
