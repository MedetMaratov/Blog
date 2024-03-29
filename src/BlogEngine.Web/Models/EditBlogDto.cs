﻿using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Blogs.Commands.EditBlog;
using BlogEngineApplication.Common.Mapping;

namespace BlogEngine.Web.Models
{
    public class EditBlogDto : IMapWith<EditBlogCommand>
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Category> Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditBlogDto, EditBlogCommand>()
          .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.BlogId))
          .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
          .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
          .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
          .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
        }
    }
}
