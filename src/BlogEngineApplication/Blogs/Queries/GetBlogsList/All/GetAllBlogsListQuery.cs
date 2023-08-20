using MediatR;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.All
{
    public class GetAllBlogsListQuery : IRequest<BlogListVM>
    {
    }
}
