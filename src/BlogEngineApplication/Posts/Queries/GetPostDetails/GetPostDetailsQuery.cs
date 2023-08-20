using MediatR;

namespace BlogEngineApplication.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQuery : IRequest<PostLookUpDto>
    {
        public Guid PostId { get; set; }

        public GetPostDetailsQuery(Guid postId)
        {
            PostId = postId;
        }
    }
}
