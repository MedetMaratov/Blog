using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Blogs.Queries.GetBlogDetails
{
    public class GetBlogDetailsQueryHandler : IRequestHandler<GetBlogDetailsQuery, Blog>
    {
        private readonly IBlogDbContext _dbContext;

        public GetBlogDetailsQueryHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Blog> Handle(GetBlogDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var blog = await _dbContext
                .Blogs
                .Include(blog => blog.Posts)
                .FirstOrDefaultAsync(blog => blog.Id == request.BlogId, cancellationToken);
            return blog;
        }
    }
}
