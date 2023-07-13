using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Comments.Queries
{
    public class GetAllCommentsByPostIdQuery : IRequest<CommentsListVm>
    {
        public Guid PostId { get; set; }
    }
}
