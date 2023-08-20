using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Domain.Entities
{
    public class Tag
    {
        [Key]
        public string Title { get; set; }
        public List<Post>? Posts { get; set; }

        public Tag(string title)
        {
            Title = title;
        }
    }
}
