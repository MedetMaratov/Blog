using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngine.Web.Models;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using BlogEngineApplication.Blogs.Queries.GetBlogDetails;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.All;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCreator;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByName;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.Subscribed;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BlogController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBlogsListQuery();
            var vm = await _mediator.Send(query);
            return View(vm);
        }

        [HttpGet("{blogName}")]
        public async Task<IActionResult> GetByName(string blogName)
        {
            var query = new GetBlogsListBuNameQuery
            {
                Name = blogName
            };
            var vm = await _mediator.Send(query);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubscribed()
        {
            var query = new GetListOfBlogSubscribedToQuery
            {
                UserId = UserId
            };
            var vm = await _mediator.Send(query);
            return View(vm);
        }

        [HttpGet("CreatorId")]
        public async Task<IActionResult> GetByCreator(Guid CreatorId)
        {
            var query = new GetBlogsListByCreatorQuery
            {
                CreatorId = UserId
            };
            var vm = await _mediator.Send(query);
            return View(vm);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var query = new GetBlogDetailsQuery
            {
                BlogId = id
            };
            var vm = await _mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            var command = _mapper.Map<CreateBlogCommand>(createBlogDto);
            command.UserId = UserId;
            await _mediator.Send(command);
            return RedirectToAction("Index");
            
        }
    }
}
