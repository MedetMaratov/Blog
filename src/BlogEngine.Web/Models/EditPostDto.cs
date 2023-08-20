using AutoMapper;
using BlogEngineApplication.Common.Mapping;
using BlogEngineApplication.Posts.Commands.Edit;

namespace BlogEngine.Web.Models
{
    public class EditPostDto : IMapWith<EditPostCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditPostDto, EditPostCommand>()
                .ForMember(postCommand => postCommand.Title,
                opt => opt.MapFrom(postDto => postDto.Title))
                .ForMember(postCommand => postCommand.Content,
                opt => opt.MapFrom(postDto => postDto.Content))
                .ForMember(postCommand => postCommand.Tags,
                opt => opt.MapFrom(postDto => postDto.Tags));
        }
    }
}
