using AutoMapper;
using BlogEngineApplication.Common.Mapping;
using BlogEngineApplication.Posts.Commands.Create;

namespace BlogEngine.Web.Models
{
    public class CreatePostDto : IMapWith<CreatePostCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDto, CreatePostCommand>()
                .ForMember(postCommand => postCommand.Title,
                opt => opt.MapFrom(postDto => postDto.Title))
                .ForMember(postCommand => postCommand.Content,
                opt => opt.MapFrom(postDto => postDto.Content))
                .ForMember(postCommand => postCommand.TagTitles,
                opt => opt.MapFrom(postDto => postDto.Tags));
        }
    }
}
