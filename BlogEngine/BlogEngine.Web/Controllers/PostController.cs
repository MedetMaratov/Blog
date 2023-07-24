using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngine.Web.Models;
using BlogEngineApplication.Posts.Commands.Create;
using BlogEngineApplication.Posts.Commands.Delete;
using BlogEngineApplication.Posts.Commands.Edit;
using BlogEngineApplication.Posts.Queries;
using BlogEngineApplication.Posts.Queries.GetByTags;
using BlogEngineApplication.Posts.Queries.GetPostByBlogId;
using BlogEngineApplication.Posts.Queries.GetPostDetails;
using BlogEngineApplication.Posts.Queries.GetSubscribedBlogPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class PostController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PostController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the details of a specific post.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/post/get/b79df8b2-183e-4a32-98cd-3fc47e65f07a
        /// </remarks>
        /// <param name="id">Specific post id (guid)</param>
        /// <returns>Returns PostLookUpDto</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<PostLookUpDto>> Get(Guid id)
        {
            var query = new GetPostDetailsQuery()
            {
                PostId = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets all posts associated with a specific blog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/post/getallbyblogid/b79df8b2-183e-4a32-98cd-3fc47e65f07a
        /// </remarks>
        /// <param name="blogId">The ID of the blog.</param>
        /// <returns>Returns PostListVM</returns>
        /// <response code="200">Success</response>
        [HttpGet("{blogId}")]
        public async Task<ActionResult<PostListVM>> GetAllByBlogId(Guid blogId)
        {
            var query = new GetPostsByBlogIdQuery() { BlogId = blogId };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets all posts from blogs subscribed to by the current user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/post/getsubscribed
        /// </remarks>
        /// <param name="blogId">The ID of the blog.</param>
        /// <returns>Returns PostListVM</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        public async Task<ActionResult<PostListVM>> GetSubscribed()
        {
            var query = new GetSubscribedBlogPostsQuery()
            {
                UserId = UserId
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets posts by specified tags.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/post/getbytags
        /// {
        ///     "IncludedTags": "tag1;tag2"
        ///     "ExcludedTags": "tag3"
        /// }
        /// </remarks>
        /// <param name="tagsDto">The tags to include/exclude.</param>
        /// <returns>Returns PostListVM</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        public async Task<ActionResult<PostListVM>> GetByTags([FromBody] GetPostsByTagsDto tagsDto)
        {
            var query = new GetPostsByTagsQuery()
            {
                IncludedTags = tagsDto.IncludedTags,
                ExcludedTags = tagsDto.ExcludedTags
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates a new post for a specific blog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/post/create
        /// {
        ///     "Title": "Post title",
        ///     "Content": "Post content",
        ///     "Tags": [ "tag1;tag2"]
        /// }
        /// </remarks>
        /// <param name="blogId">The ID of the blog.</param>
        /// <param name="createPostDto">The data for creating the post.</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost("{blogId}")]
        public async Task<ActionResult<Guid>> Create(Guid blogId, [FromBody] CreatePostDto createPostDto)
        {
            var command = _mapper.Map<CreatePostCommand>(createPostDto);
            command.UserId = UserId;
            command.BlogId = blogId;
            var postId = await _mediator.Send(command);
            return Ok(postId);
        }

        /// <summary>
        /// Edits the specified post.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Put /api/post/edit
        /// {
        ///     "Title": "Post title",
        ///     "Content": "Post content",
        ///     "Tags": [ "tag1;tag2"]
        /// }
        /// </remarks>
        /// <param name="postID">The ID of the post.</param>
        /// <param name="editPostDto">The data for updating the post.</param>
        /// <returns>Returns NoContent if successful.</returns>
        /// <response code="204">Success</response>
        [HttpPut("{blogId}/{postId}")]
        public async Task<ActionResult> Edit(Guid postID,[FromBody] EditPostDto editPostDto)
        {
            var command = _mapper.Map<EditPostCommand>(editPostDto);
            command.UserID = UserId;
            command.PostId = postID;
            await _mediator.Send(command);
            return NoContent();
        }


        /// <summary>
        /// Deletes a post from a specific blog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Delete /api/post/delete/c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r/a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p6
        /// </remarks>
        /// <param name="blogId">The ID of the blog.</param>
        /// <param name="postId">The ID of the post to delete.</param>
        /// <returns>Returns NoContent if successful.</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{blogId}/{postId}")]
        public async Task<ActionResult> Delete(Guid blogId, Guid postId)
        {
            var query = new DeletePostCommand()
            {
                BlogId = blogId,
                UserId = UserId,
                PostId = postId
            };
            await _mediator.Send(query);
            return NoContent();
        }
    }
}
