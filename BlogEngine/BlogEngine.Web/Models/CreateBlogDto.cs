using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Blogs.Commands.CreateBlog;
using BlogEngineApplication.Common.Mapping;

namespace BlogEngine.Web.Models
{
    public class CreateBlogDto : IMapWith<CreateBlogCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<BlogCategory> Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBlogDto, CreateBlogCommand>()
                .ForMember(blogCommand => blogCommand.Title,
                opt => opt.MapFrom(blogDto => blogDto.Title))
                .ForMember(blogCommand => blogCommand.Description,
                opt => opt.MapFrom(blogDto => blogDto.Description))
                .ForMember(blogCommand => blogCommand.Image,
                opt => opt.MapFrom(blogDto => blogDto.Image))
                .ForMember(blogCommand => blogCommand.Categories,
                opt => opt.MapFrom(blogDto => blogDto.Categories));              
        }
    }
}
