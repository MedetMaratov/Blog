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
            var subscribedPosts = await _dbContext.Blogs
                .Where(b => b.Id == request.BlogId
                && b.Subscriptions.Any(sub => sub.UserId == request.UserId))
                .SelectMany(blog => blog.Posts)
                .ProjectTo<PostLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new PostListVM { Posts = subscribedPosts };
        }
    }
}
