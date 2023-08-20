using MediatR;

namespace BlogEngineApplication.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
