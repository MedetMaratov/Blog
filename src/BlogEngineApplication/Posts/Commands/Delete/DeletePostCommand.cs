using MediatR;

namespace BlogEngineApplication.Posts.Commands.Delete
{
    public class DeletePostCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public Guid BlogId { get; set; }
    }
}
