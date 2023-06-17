using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Mapping;
using BlogEngineApplication.Posts.Commands.Create;

namespace BlogEngine.Web.Models
{
    public class PostDto : IMapWith<CreatePostCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostDto, CreatePostCommand>()
                .ForMember(postCommand => postCommand.Title,
                opt => opt.MapFrom(postDto => postDto.Title))
                .ForMember(postCommand => postCommand.Content,
                opt => opt.MapFrom(postDto => postDto.Content))
                .ForMember(postCommand => postCommand.Tags,
                opt => opt.MapFrom(postDto => postDto.Tags));
        }
    }
}
