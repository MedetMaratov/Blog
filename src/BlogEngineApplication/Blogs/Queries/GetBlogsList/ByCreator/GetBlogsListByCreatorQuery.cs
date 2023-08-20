using MediatR;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.ByCreator
{
    public class GetBlogsListByCreatorQuery : IRequest<BlogListVM>
    {
        public Guid CreatorId { get; set; }

        public GetBlogsListByCreatorQuery(Guid creatorId)
        {
            CreatorId = creatorId;
        }
    }
}
