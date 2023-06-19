using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Tags.Commands.Create
{
    public class CreatePostTagCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public Guid PostId { get; set; }
    }
}
