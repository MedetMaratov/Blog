﻿using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngine.Web.Models;
using BlogEngineApplication.Posts.Commands.Create;
using BlogEngineApplication.Posts.Commands.Delete;
using BlogEngineApplication.Posts.Commands.Edit;
using BlogEngineApplication.Posts.Queries;
using BlogEngineApplication.Posts.Queries.GetPostByBlogId;
using BlogEngineApplication.Posts.Queries.GetPostDetails;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(Guid id)
        {
            var query = new GetPostDetailsQuery()
            {
                PostId = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult> GetAllByBlogId(Guid blogId)
        {
            var query = new GetPostsByBlogIdQuery() { BlogId= blogId };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("{blogId}")]
        public async Task<ActionResult<Guid>> Create(Guid blogId, [FromBody] CreatePostDto createPostDto)
        {
            var command = _mapper.Map<CreatePostCommand>(createPostDto);
            command.UserId = UserId;
            command.BlogId = blogId;
            var postId = await _mediator.Send(command);
            return Ok(postId);
        }

        [HttpPut("{blogId}/{postId}")]
        public async Task<ActionResult> Edit(Guid postID,[FromBody] EditPostDto editPostDto)
        {
            var command = _mapper.Map<EditPostCommand>(editPostDto);
            command.UserID = UserId;
            command.PostId = postID;
            await _mediator.Send(command);
            return NoContent();
        }

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
