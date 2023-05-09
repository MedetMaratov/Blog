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

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCreator
{
    public class GetBlogsListByCreatorQueryHandler
        : IRequestHandler<GetBlogsListByCreatorQuery, BlogListVM>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBlogsListByCreatorQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BlogListVM> Handle(GetBlogsListByCreatorQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _dbContext
                .Blogs
                .Where(blog => blog.CreatorId == request.CreatorId)
                .OrderByDescending(blog => blog.Created)
                .ProjectTo<BlogLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BlogListVM() { Blogs = blogs };
        }
    }
}
