using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        [ForeignKey("Blog")]
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
        public List<PostTag> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
    }
}
