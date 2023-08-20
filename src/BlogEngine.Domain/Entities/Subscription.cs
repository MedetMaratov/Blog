namespace BlogEngine.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }

        public Subscription(Guid userId, Guid blogId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            BlogId = blogId;
        }
    }
}
