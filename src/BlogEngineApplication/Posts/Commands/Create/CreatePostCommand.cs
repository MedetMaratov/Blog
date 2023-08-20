using MediatR;

namespace BlogEngineApplication.Posts.Commands.Create
{
    public class CreatePostCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> TagTitles { get; set; }
    }
}
