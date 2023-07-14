using BlogEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Interfaces
{
    public interface ITagService
    {
        Task AddTags(Post post, IEnumerable<string> tags);
    }
}
