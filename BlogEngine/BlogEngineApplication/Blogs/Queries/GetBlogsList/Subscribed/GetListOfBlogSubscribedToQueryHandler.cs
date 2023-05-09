using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.Subscribed
{
    public class GetListOfBlogSubscribedToQueryHandler
       : IRequestHandler<GetListOfBlogSubscribedToQuery, BlogListVM>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListOfBlogSubscribedToQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BlogListVM> Handle(GetListOfBlogSubscribedToQuery request,
            CancellationToken cancellationToken)
        {
            var subscriptions = await _dbContext
            .Subsсription
            .Where(s => s.UserId == request.UserId)
            .ToListAsync();
            var blogIds = subscriptions
                .Select(s => s.BlogId)
                .Distinct()
                .ToList();
            var blogs = await _dbContext
                .Blogs
                .Where(b => blogIds.Contains(b.Id))
                .ProjectTo<BlogLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new BlogListVM { Blogs = blogs };
        }
    }
}
