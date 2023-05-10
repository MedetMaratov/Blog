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

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.All
{
    public class GetAllBlogListQuerieHandler : IRequestHandler<GetAllBlogsListQuery,BlogListVM>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllBlogListQuerieHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BlogListVM> Handle(GetAllBlogsListQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _dbContext
                .Blogs
                .OrderByDescending(blog => blog.Created)
                .ProjectTo<BlogLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new BlogListVM { Blogs = blogs };
        }
    }
}
