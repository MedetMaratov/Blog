using MediatR;

namespace BlogEngineApplication.Posts.Commands.Edit
{
    public class EditPostCommand : IRequest
    {
        public Guid PostId { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
    }
}
