namespace BlogEngine.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public Post? Post { get; set; }
        public DateTime CreatedAt { get; set; }

        #pragma warning disable CS8618
        public Comment() { }
        #pragma warning restore CS8618

        public Comment(string content, Guid userId, Guid postId)
        {
            Id = Guid.NewGuid();
            Content = content;
            CreatedAt= DateTime.Now;
            UserId = userId;
            PostId = postId;
        }
    }
}
