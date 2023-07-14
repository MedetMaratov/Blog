using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngine.Web.Models;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using BlogEngineApplication.Blogs.Commands.DeleteBlog;
using BlogEngineApplication.Blogs.Commands.EditBlog;
using BlogEngineApplication.Blogs.Queries.GetBlogDetails;
using BlogEngineApplication.Blogs.Queries.GetBlogsList;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.All;
using BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCategory;
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
        public async Task<ActionResult<BlogListVM>> GetAll()
        {
            var query = new GetAllBlogsListQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{blogName}")]
        public async Task<ActionResult<BlogListVM>> GetByName(string blogName)
        {
            var query = new GetBlogsListBuNameQuery
            {
                Name = blogName
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<BlogListVM>> GetSubscribed()
        {
            var query = new GetListOfBlogSubscribedToQuery
            {
                UserId = UserId
            };
            var vm = await _mediator.Send(query);   
            return Ok(vm);
        }

        [HttpGet("{CreatorId}")]
        public async Task<ActionResult<BlogListVM>> GetByCreator(Guid CreatorId)
        {
            var query = new GetBlogsListByCreatorQuery
            {
                CreatorId = CreatorId
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet()]
        public async Task<ActionResult<BlogListVM>> GetByCategory([FromBody] GetBlogByCategoryDto categoriesDto)
        {
            var query = new GetBlogListByCategoryQuery
            {
                IncludedCategories = categoriesDto.IncludedCategories,
                ExcludedCategories= categoriesDto.ExcludedCategories
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetDetails(Guid id)
        {
            var query = new GetBlogDetailsQuery
            {
                BlogId = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateBlogDto createBlogDto)
        {
            var command = _mapper.Map<CreateBlogCommand>(createBlogDto);
            command.UserId = UserId;
            var blogId = await _mediator.Send(command);
            return Ok(blogId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditBlogDto editeBlogDto)
        {
            var query = _mapper.Map<EditeBlogCommand>(editeBlogDto);
            query.UserId = UserId;
            await _mediator.Send(query);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteBlogCommand
            {
                BlogId = id,
                UserId = UserId
            };
            await _mediator.Send(query);
            return NoContent();
        }
    }
}
