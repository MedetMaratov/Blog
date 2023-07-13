using AutoMapper;
using BlogEngine.Domain;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Interfaces;
using BlogEngineApplication.Posts.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlogEngineApplication.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, PostLookUpDto>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPostDetailsQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PostLookUpDto> Handle(GetPostDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var post = await _dbContext.Posts
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(post => post.Id == request.PostId, cancellationToken: cancellationToken);
            var dto = _mapper.Map<PostLookUpDto>(post);
            return dto;
        }
    }
}
