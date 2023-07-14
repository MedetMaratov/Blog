using BlogEngine.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Categories.Get
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
    }
}
