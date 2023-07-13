using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
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
    public class GetBlogDetailsQueryHandler : IRequestHandler<GetBlogDetailsQuery, BlogLookupDto>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBlogDetailsQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BlogLookupDto> Handle(GetBlogDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var blog = await _dbContext
                .Blogs
                .Include(blog => blog.Categories)
                .Include(blog => blog.Posts)
                .ProjectTo<BlogLookupDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(blog => blog.Id == request.BlogId, cancellationToken);
            return blog;
        }
    }
}
