using AutoMapper;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.All;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByName;
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
    }
}
