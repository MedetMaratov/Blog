using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Mapping;

namespace BlogEngineApplication.Comments.Queries
{
    public class CommentLookUpDto : IMapWith<Comment>
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentLookUpDto>()
                .ForMember(cDto => cDto.Content, opt => opt.MapFrom(c => c.Content))
                .ForMember(cDto => cDto.CreatedAt, opt => opt.MapFrom(c => c.CreatedAt));
        }
    }
}
