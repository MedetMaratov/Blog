using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngine.Web.Models;
using BlogEngineApplication.Categories.Create;
using BlogEngineApplication.Categories.Get;
using BlogEngineApplication.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategoryDto);
            var categoryId = await _mediator.Send(command);
            return Ok(categoryId);
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var query = new GetAllCategoriesQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
    }
}
