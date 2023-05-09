using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("Blog")]
        public Guid BlogId { get; set; }
        public Post Blog { get; set; }
    }
}
