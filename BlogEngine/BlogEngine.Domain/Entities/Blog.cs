using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogEngine.Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public List<BlogCategory> Category { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Edited { get; set; }
        public List<Post> Posts { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}