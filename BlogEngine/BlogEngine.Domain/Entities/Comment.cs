using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("Post")]
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
    }
}
