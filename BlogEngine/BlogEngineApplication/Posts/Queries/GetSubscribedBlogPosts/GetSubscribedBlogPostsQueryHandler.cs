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

namespace BlogEngineApplication.Posts.Queries.GetSubscribedBlogPosts
{
    public class GetSubscribedBlogPostsQueryHandler :
        IRequestHandler<GetSubscribedBlogPostsQuery, PostListVM>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSubscribedBlogPostsQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PostListVM> Handle(GetSubscribedBlogPostsQuery request,
            CancellationToken cancellationToken)
        {
            var subscribedBlogIds = await _dbContext.Subsсriptions
           .Where(s => s.UserId == request.UserId)
           .Select(s => s.BlogId)
           .ToListAsync(cancellationToken);

            var posts = await _dbContext.Posts
                .Where(p => subscribedBlogIds.Contains(p.BlogId))
                .ProjectTo<PostLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PostListVM { Posts = posts };
        }
    }
}
