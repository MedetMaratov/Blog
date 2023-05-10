using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList
{
    public class BlogLookupDto : IMapWith<Blog>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Blog, BlogLookupDto>()
                .ForMember(blogDto => blogDto.Id, opt => opt.MapFrom(blog => blog.Id))
                .ForMember(blogDto => blogDto.Title, opt => opt.MapFrom(blog => blog.Name))
                .ForMember(blogDto => blogDto.Created, opt => opt.MapFrom(blog => blog.Created));
        }
    }
}
