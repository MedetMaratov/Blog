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
    [Produces("application/json")]
    public class BlogController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BlogController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the list of blogs
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/blog/getall
        /// </remarks>
        /// <returns>Returns BlogListVM</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        public async Task<ActionResult<BlogListVM>> GetAll()
        {
            var query = new GetAllBlogsListQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the blog by name
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/blog/getbyname/food_rescipes
        /// </remarks>
        /// <param name="blogName">Blog name (string)</param>
        /// <returns>Returns BlogListVM</returns>
        /// <response code="200">Success</response>
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

        /// <summary>
        /// Gets the list of blogs subscribed to by the current user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/blog/getsubscribed
        /// </remarks>
        /// <returns>Returns BlogListVM</returns>
        /// <response code="200">Success</response>
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

        /// <summary>
        /// Gets the list of blogs created by a specific user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/blog/getbycreator/2cb58782-9e80-41ce-b2d5-e9e5a4f0950e
        /// </remarks>
        /// <param name="CreatorId">Blog creator id (guid)</param>
        /// <returns>Returns BlogListVM</returns>
        /// <response code="200">Success</response>
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

        /// <summary>
        /// Returns a list of blogs with the included and excluded categories
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/blog/getbycategory
        /// {
        ///     "IncludedCategories": "category1;cateory2"
        ///     "ExcludedCategories": ""
        /// }
        /// </remarks>
        /// <param name="categoriesDto">categoriesDto object</param>
        /// <returns>Returns BlogListVM</returns>
        /// <response code="200">Success</response>
        [HttpGet()]
        public async Task<ActionResult<BlogListVM>> GetByCategory([FromBody] GetBlogByCategoryDto categoriesDto)
        {
            var query = new GetBlogListByCategoryQuery
            {
                IncludedCategories = categoriesDto.IncludedCategories,
                ExcludedCategories = categoriesDto.ExcludedCategories
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the details of a specific blog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/blog/getdetails
        /// </remarks>
        /// <param name="id">Specific blog id (guid)</param>
        /// <returns>Returns Blog</returns>
        /// <response code="200">Success</response>
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

        /// <summary>
        /// Creates a new blog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/blog/create
        /// {
        ///     "Title": "Blog Title",
        ///     "Description": "Blog description",
        ///     "Image": "https://image.jpg",
        ///     "Categories": [
        ///     "b79df8b2-183e-4a32-98cd-3fc47e65f07a",
        ///     "cda8b3f6-5d43-4f9d-88bc-e49e9144e628"
        ///     ]
        /// }
        /// </remarks>
        /// <param name="createBlogDto">CreateBlogDto object.</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateBlogDto createBlogDto)
        {
            var command = _mapper.Map<CreateBlogCommand>(createBlogDto);
            command.UserId = UserId;
            var blogId = await _mediator.Send(command);
            return Ok(blogId);
        }

        /// <summary>
        /// Edits the specified blog
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Put /api/blog/update
        /// {
        /// "UserId": "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p6",
        /// "BlogId": "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
        /// "Title": "Blog Title",
        /// "Description": "blog description.",
        /// "Image": "https://sample-image.jpg",
        /// "Categories": [
        ///   {
        ///     "Id": "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
        ///     "Name": "Category 1",
        ///   }
        ///  ]
        /// }
        /// </remarks>
        /// <param name="editeBlogDto">EditeBlogDto object.</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        public async Task<IActionResult> Update(EditBlogDto editeBlogDto)
        {
            var query = _mapper.Map<EditBlogCommand>(editeBlogDto);
            query.UserId = UserId;
            await _mediator.Send(query);
            return NoContent();
        }

        /// <summary>
        /// Deletes the blog by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Delete /api/blog/delete/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Blog id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
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
