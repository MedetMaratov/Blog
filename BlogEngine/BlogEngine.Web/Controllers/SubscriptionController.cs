using BlogEngine.Application.Subscriptions.Command;
using BlogEngineApplication.Subscriptions.Command;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class SubscriptionController : BaseController
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{blogId}")]
        public async Task<ActionResult> Subscribe(Guid blogId)
        {
            var command = new SubscribeToBlogCommand()
            {
                BlogId = blogId,
                UserId = UserId
            };

            await _mediator.Send(command);
            return NoContent();
        }


        [HttpPost("{blogId}")]
        public async Task<ActionResult> Unsubscribe(Guid blogId)
        {
            var command = new UnsubscribeFromBlogCommand()
            {
                BlogId = blogId,
                UserId = UserId
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
