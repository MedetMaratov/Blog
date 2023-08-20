using MediatR;

namespace BlogEngineApplication.Categories.Create
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public String Name { get; set; }
    }
}
