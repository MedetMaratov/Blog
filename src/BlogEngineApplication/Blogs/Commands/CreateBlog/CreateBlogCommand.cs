using MediatR;

namespace BlogEngineApplication.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Guid> CategoriesId { get; set; }
    }
}