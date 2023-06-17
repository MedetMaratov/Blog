using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Categories.Create
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public String Name { get; set; }
    }
}
