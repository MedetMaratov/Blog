using AutoMapper;
using BlogEngine.Web.Models;
using BlogEngineApplication.Comments.Commands.Create;
using BlogEngineApplication.Comments.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("{postId}")]
        public async Task<ActionResult<Guid>> Create(Guid postId, [FromBody] CreateCommentDto createCommentDto)
        {
            var command = _mapper.Map<CreateCommentCommand>(createCommentDto);
            command.UserId = UserId;
            command.PostId = postId;
            var commentId = await _mediator.Send(command);
            return Ok(commentId);
        }

        [HttpDelete("{postId}/{commentId}")]
        public async Task<ActionResult> Delete(Guid postId, Guid commentId)
        {
            var command = new DeleteCommentCommand()
            {
                CommentId = commentId,
                UserId = UserId,
                PostId = postId
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
