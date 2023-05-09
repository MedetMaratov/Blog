using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Commands.Delete
{
    public class DeletePostCommand
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public Guid BlogId { get; set; }
    }
}
