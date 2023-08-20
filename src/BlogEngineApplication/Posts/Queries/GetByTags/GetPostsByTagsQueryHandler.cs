using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogEngineApplication.Posts.Queries.GetByTags
{
    public class GetPostsByTagsQueryHandler : IRequestHandler<GetPostsByTagsQuery, PostListVM>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPostsByTagsQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PostListVM> Handle(GetPostsByTagsQuery request,
            CancellationToken cancellationToken)
        {
            var includedTags = request.IncludedTags.Split(';');
            var excludedTags = request.ExcludedTags.Split(';');

            var allPosts = await _dbContext.Posts
                .ProjectTo<PostLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var posts = allPosts
               .Where(p => p.Tags.Any(t => includedTags.Contains(t)))
               .Distinct()
               .ToList();

            posts = excludedTags.Aggregate(posts, (current, tag) =>
            current.Where(p => p.Tags.All(t => t != tag)).ToList());

            return new PostListVM { Posts = posts };
        }
    }
}

