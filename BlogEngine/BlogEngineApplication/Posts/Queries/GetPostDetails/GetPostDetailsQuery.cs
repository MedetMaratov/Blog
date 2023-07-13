using BlogEngine.Domain;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Posts.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQuery : IRequest<PostLookUpDto>
    {
        public Guid PostId { get; set; }
    }
}
