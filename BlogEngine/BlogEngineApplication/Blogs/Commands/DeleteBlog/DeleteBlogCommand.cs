using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogEngineApplication.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest
    {
        public Guid BlogId;
        public Guid UserId;
    }
}