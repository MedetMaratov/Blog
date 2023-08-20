using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Mapping;

namespace BlogEngineApplication.Posts.Queries
{
    public class PostLookUpDto : IMapWith<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostLookUpDto>()
                .ForMember(postDto => postDto.Title, opt => opt.MapFrom(post => post.Title))
                .ForMember(postDto => postDto.Content, opt => opt.MapFrom(post => post.Content))
                .ForMember(postDto => postDto.Tags, opt => opt.MapFrom(post => post.Tags.Select(tag => tag.Title).ToList()))
                .ForMember(postDto => postDto.CreatedAt, opt => opt.MapFrom(post => post.CreatedAt))
                .ForMember(postDto => postDto.EditedAt, opt => opt.MapFrom(post => post.EditedAt));
        }
    }
}
