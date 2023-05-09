using BlogEngine.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Commands.Create
{
    public class CreatePostCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<PostTag> Tags { get; set; }
    }
}
