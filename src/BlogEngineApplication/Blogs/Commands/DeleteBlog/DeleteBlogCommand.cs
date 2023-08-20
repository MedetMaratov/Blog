using MediatR;

namespace BlogEngineApplication.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest
    {
        public Guid BlogId;
        public Guid UserId;
    }
}