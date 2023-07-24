using AutoMapper;
using BlogEngine.Web.Models;
using BlogEngineApplication.Comments.Commands.Create;
using BlogEngineApplication.Comments.Commands.Delete;
using BlogEngineApplication.Comments.Queries;
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

        /// <summary>
        /// Creates a new comment for a specific post.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/comment/create
        /// {
        ///     "Content": "text"
        /// }
        /// </remarks>
        /// <param name="postId">The ID of the post.</param>
        /// <param name="createCommentDto">The data for creating the comment.</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost("{postId}")]
        public async Task<ActionResult<Guid>> Create(Guid postId, [FromBody] CreateCommentDto createCommentDto)
        {
            var command = _mapper.Map<CreateCommentCommand>(createCommentDto);
            command.UserId = UserId;
            command.PostId = postId;
            var commentId = await _mediator.Send(command);
            return Ok(commentId);
        }

        /// <summary>
        /// Deletes a comment from a specific post.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Delete /api/comment/delete/d7989641-fd26-4a88-a08f-55d639b7003f/a7a921e7-9fc1-4d1b-9ad0-b965fbaebb70
        /// </remarks>
        /// <param name="postId">The ID of the post.</param>
        /// <param name="commentId">The ID of the comment to delete.</param>
        /// <returns>Returns NoContent if successful.</returns>
        /// <response code="204">Success</response>
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

        /// <summary>
        /// Gets all comments for a specific post.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/comment/getall
        /// </remarks>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>Returns CommentsListVm.</returns>
        /// <response code="200">Success</response>
        [HttpGet("postId")]
        public async Task<ActionResult<CommentsListVm>> GetAll(Guid postId)
        {
            var query = new GetAllCommentsByPostIdQuery()
            {
                PostId = postId
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
    }
}
