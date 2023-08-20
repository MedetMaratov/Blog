using BlogEngine.Domain.Entities;
using MediatR;

namespace BlogEngineApplication.Categories.Get
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
    }
}
