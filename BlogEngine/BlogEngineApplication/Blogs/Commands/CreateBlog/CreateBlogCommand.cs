using BlogEngine.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogEngineApplication.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Guid> CategoriesId { get; set; }
    }
}