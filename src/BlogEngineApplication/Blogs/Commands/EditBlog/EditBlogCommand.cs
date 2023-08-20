using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngineApplication.Blogs.Commands.EditBlog
{
    public class EditBlogCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Category> Categories { get; set; }
    }
}
