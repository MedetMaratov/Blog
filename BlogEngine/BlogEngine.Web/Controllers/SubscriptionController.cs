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

        /// <summary>
        /// Subscribes the current user to a blog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/subscription/subscribe
        /// {
        ///     "UserId":"b79df8b2-183e-4a32-98cd-3fc47e65f07a",
        ///     "BlogId: "cda8b3f6-5d43-4f9d-88bc-e49e9144e628"
        /// }
        /// </remarks>
        /// <param name="blogId">The ID of the blog to subscribe to</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
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

        /// <summary>
        /// Unsubscribes the current user from a blog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/subscription/unsubscribe
        /// {
        ///     "UserId":"b79df8b2-183e-4a32-98cd-3fc47e65f07a",
        ///     "BlogId: "cda8b3f6-5d43-4f9d-88bc-e49e9144e628"
        /// }
        /// </remarks>
        /// <param name="blogId">The ID of the blog to unsubscribe from.</param>
        /// <returns>Returns NoContent if successful.</returns>
        /// <response code="204">Success</response>
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
