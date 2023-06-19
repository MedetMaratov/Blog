using BlogEngine.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Commands.Edit
{
    public class EditPostCommand : IRequest
    {
        public Guid PostId { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<PostTag> Tags { get; set; }
    }
}
