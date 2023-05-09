using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogEngineApplication.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
    {
        private readonly IBlogDbContext _dbContext;

        public CreateBlogCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateBlogCommand request,
            CancellationToken cancellationToken)
        {
            var blog = new Blog
            {
                Id = Guid.NewGuid(),
                Name = request.Title,
                CreatorId = request.UserId,
                Description = request.Description,
                Created = DateTime.Now,
                Edited = null,
                Image = request.Image,
                Posts = new List<Post>(),
                Subscriptions = new List<Subscription>(),
                Category = request.Categories
            };

            await _dbContext.Blogs.AddAsync(blog, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return blog.Id;
        }
    }
}
