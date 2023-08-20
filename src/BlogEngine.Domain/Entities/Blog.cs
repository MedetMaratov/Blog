namespace BlogEngine.Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Edited { get; set; }
        public List<Post> Posts { get; set; }
        public List<Subscription> Subscriptions { get; set; }

        #pragma warning disable CS8618
        public Blog() { }
        #pragma warning restore CS8618

        public Blog(string name, Guid creatorId, string description, string image)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatorId = creatorId;
            Description = description;
            Created = DateTime.Now;
            Edited = null;
            Image = image;
            Posts = new List<Post>();
            Subscriptions = new List<Subscription>();
        }

        public void Edit(string name, string description, string image, List<Category> categories)
        {
            Name = name;
            Description = description;
            Edited = DateTime.Now;
            Image = image;
            Categories = categories;
        }
    }
}