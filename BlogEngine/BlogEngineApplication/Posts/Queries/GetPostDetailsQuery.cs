using BlogEngine.Domain;
using BlogEngine.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Application.Posts.Queries
{
    public class GetPostDetailsQuery : IRequest<Post>
    {
        public Guid PostId { get; set; }
    }
}
