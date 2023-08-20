namespace BlogEngine.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        #pragma warning disable CS8618
        public Post() { }
        #pragma warning restore CS8618

        public Post(Guid creatorId, string title, string content, Guid blogId)
        {
            Id = Guid.NewGuid();
            CreatorId = creatorId;
            Title = title;
            Content = content;
            BlogId = blogId;
            Comments = new List<Comment>();
            CreatedAt = DateTime.Now;
            EditedAt = null;
            Tags = new List<Tag>();
        }

        public void Edit(string title, string content)
        {
            Title = title;
            Content = content;
            EditedAt = DateTime.Now;
        }
    }
}
