using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Domain.Entities
{
    public class Tag
    {
        [Key]
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}
