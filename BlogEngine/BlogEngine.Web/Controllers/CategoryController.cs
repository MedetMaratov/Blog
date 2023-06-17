using AutoMapper;
using BlogEngine.Web.Models;
using BlogEngineApplication.Categories.Create;
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
    }
}
