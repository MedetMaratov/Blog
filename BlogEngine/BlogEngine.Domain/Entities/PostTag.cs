using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Domain.Entities
{
    public class PostTag
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Title { get; set; }
    }
}
