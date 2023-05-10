﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Blogs.Queries.GetBlogsList.All
{
    public class GetAllBlogsListQuery : IRequest<BlogListVM>
    {
    }
}
