using AutoMapper;
using BlogEngineApplication.Comments.Commands.Create;
using BlogEngineApplication.Common.Mapping;

namespace BlogEngine.Web.Models
{
    public class CreateCommentDto : IMapWith<CreateCommentCommand>
    {
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentDto, CreateCommentCommand>()
                .ForMember(commentCommand => commentCommand.Content,
                opt => opt.MapFrom(commentDto => commentDto.Content));
        }
    }
}
