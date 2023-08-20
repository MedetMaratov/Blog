namespace BlogEngine.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Blog>? Blogs { get; set; }
        
        #pragma warning disable CS8618
        public Category() { }
        #pragma warning restore CS8618

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
