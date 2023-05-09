using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Tags.Create
{
    public class CreateTagCommand : IRequest
    {
        public string Name { get; set; }
    }
}
