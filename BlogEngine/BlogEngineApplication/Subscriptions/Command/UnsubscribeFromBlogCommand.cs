using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Subscriptions.Command
{
    public class UnsubscribeFromBlogCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
    }
}
