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

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCategory
{
    public class GetBlogListByCategoryQueryHandler : 
        IRequestHandler<GetBlogListByCategoryQuery,BlogListVM>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBlogListByCategoryQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BlogListVM> Handle(GetBlogListByCategoryQuery request, CancellationToken cancellationToken)
        {

            var includedCategories = request.IncludedCategories.Split(';');
            var excludedCategories = request.ExcludedCategories.Split(';');
            var allBlogs = await _dbContext.Blogs
                .ProjectTo<BlogLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var blogs = allBlogs
                .Where(b => b.Categories.Any(category => includedCategories.Contains(category)))
                .Distinct()
                .ToList();
            blogs = excludedCategories
                .Aggregate(blogs, (current, category) => 
                current.Where(b => b.Categories.All(c => c != category)).ToList());
            return new BlogListVM { Blogs = blogs };
        }
    }
}
