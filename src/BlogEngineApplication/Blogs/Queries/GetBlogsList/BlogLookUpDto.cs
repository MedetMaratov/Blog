using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Mapping;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList
{
    public class BlogLookupDto : IMapWith<Blog>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public List<string> Categories { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Blog, BlogLookupDto>()
                .ForMember(blogDto => blogDto.Id, opt => opt.MapFrom(blog => blog.Id))
                .ForMember(blogDto => blogDto.Title, opt => opt.MapFrom(blog => blog.Name))
                .ForMember(blogDto => blogDto.Description, opt => opt.MapFrom(blog => blog.Description))
                .ForMember(blogDto => blogDto.Image, opt => opt.MapFrom(blog => blog.Image))
                .ForMember(blogDto => blogDto.Created, opt => opt.MapFrom(blog => blog.Created))
                .ForMember(blogDto => blogDto.Categories, opt => opt.MapFrom(blog => blog.Categories.Select(c => c.Name).ToList()));
        }
    }
}
