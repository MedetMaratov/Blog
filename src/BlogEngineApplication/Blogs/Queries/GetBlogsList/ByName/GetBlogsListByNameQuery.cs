using MediatR;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.ByName
{
    public class GetBlogsListBuNameQuery : IRequest<BlogListVM>
    {
        public string Name { get; set; }

        public GetBlogsListBuNameQuery(string name)
        {
            Name = name;
        }
    }
}
