using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Application.Subscriptions.Command
{
    public class SubscribeCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
    }
}
