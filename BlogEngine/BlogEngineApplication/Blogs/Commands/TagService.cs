using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    var newTag = new Tag
                    {
                        Title = tag
                    };
                    post.Tags.Add(newTag);
                }
            }
        }
    }
}
