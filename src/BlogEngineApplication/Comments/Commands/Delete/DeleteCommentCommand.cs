using MediatR;

namespace BlogEngineApplication.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequest
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
