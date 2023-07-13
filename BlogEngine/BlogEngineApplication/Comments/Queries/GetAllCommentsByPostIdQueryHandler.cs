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

namespace BlogEngineApplication.Comments.Queries
{
    public class GetAllCommentsByPostIdQueryHandler
        : IRequestHandler<GetAllCommentsByPostIdQuery, CommentsListVm>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllCommentsByPostIdQueryHandler(IBlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        } 

        public async Task<CommentsListVm> Handle(GetAllCommentsByPostIdQuery request,
            CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Comments
                .Where(c => c.PostId == request.PostId)
                .ProjectTo<CommentLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new CommentsListVm { Comments = comments};
        }
    }
}
