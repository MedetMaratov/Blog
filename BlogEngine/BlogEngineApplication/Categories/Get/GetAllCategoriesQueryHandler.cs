using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Categories.Get
{
    public class GetAllCategoriesQueryHandler :
        IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly IBlogDbContext _dbContext;

        public GetAllCategoriesQueryHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await _dbContext.Categories.ToListAsync(cancellationToken);
            return categories;
        }
    }
}
