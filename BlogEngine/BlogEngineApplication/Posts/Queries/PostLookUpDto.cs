using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Queries
{
    public class PostLookUpDto : IMapWith<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<PostTag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostLookUpDto>()
                .ForMember(postDto => postDto.Title, opt => opt.MapFrom(post => post.Title))
                .ForMember(postDto => postDto.Content, opt => opt.MapFrom(post => post.Content))
                .ForMember(postDto => postDto.Tags, opt => opt.MapFrom(post => post.Tags))
                .ForMember(postDto => postDto.Comments, opt => opt.MapFrom(post => post.Comments))
                .ForMember(postDto => postDto.CreatedAt, opt => opt.MapFrom(post => post.CreatedAt))
                .ForMember(postDto => postDto.EditedAt, opt => opt.MapFrom(post => post.EditedAt));
        }
    }
}
