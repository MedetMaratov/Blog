using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngineApplication.Posts.Queries.GetByTags
{
    public class GetPostsByTagsQuery :IRequest<PostListVM>
    {
        public string IncludedTags { get; set; } = "";
        public string ExcludedTags { get; set; } = "";
    }
}
