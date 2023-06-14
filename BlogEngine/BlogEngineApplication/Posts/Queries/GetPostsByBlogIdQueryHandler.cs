using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Queries
{
    public class GetPostsByBlogIdQueryHandler : IRequestHandler<GetPostsByBlogIdQuery, PostListVM>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPostsByBlogIdQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PostListVM> Handle(GetPostsByBlogIdQuery request, 
            CancellationToken cancellationToken)
        {
            var posts = await _dbContext
                .Posts
                .Include(post => post.Comments)
                .Include(post => post.Tags)
                .Where(post => post.BlogId == request.BlogId)
                .OrderByDescending(post => post.CreatedAt)
                .ProjectTo<PostLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new PostListVM() { Posts = posts };
        }
    }
}
