using MediatR;

namespace BlogEngineApplication.Comments.Queries
{
    public class GetAllCommentsByPostIdQuery : IRequest<CommentsListVm>
    {
        public Guid PostId { get; set; }

        public GetAllCommentsByPostIdQuery(Guid postId)
        {
            PostId = postId;
        }
    }
}
