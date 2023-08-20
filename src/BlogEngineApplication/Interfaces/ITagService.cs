using BlogEngine.Domain.Entities;

namespace BlogEngineApplication.Interfaces
{
    public interface ITagService
    {
        Task AddTags(Post post, IEnumerable<string> tags);
    }
}
