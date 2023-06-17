using AutoMapper;
using BlogEngine.Domain.Entities;
using BlogEngineApplication.Categories.Create;
using BlogEngineApplication.Common.Mapping;

namespace BlogEngine.Web.Models
{
    public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>()
                .ForMember(category => category.Name, opt => opt.MapFrom(categoryDto => categoryDto.Name));
        }
    }
}
