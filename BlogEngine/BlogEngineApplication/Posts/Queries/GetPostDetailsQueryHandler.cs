using BlogEngine.Domain;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Application.Posts.Queries
{
    public class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, Post>
    {
        private readonly IBlogDbContext _dbContext;

        public GetPostDetailsQueryHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> Handle(GetPostDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var post = await _dbContext
                .Posts
                .Include(post => post.Comments)
                .FirstOrDefaultAsync(post => post.Id == request.PostId, cancellationToken);
            return post;
        }
    }
}
