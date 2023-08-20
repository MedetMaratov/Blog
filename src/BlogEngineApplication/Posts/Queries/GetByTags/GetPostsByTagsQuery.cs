using MediatR;

namespace BlogEngineApplication.Posts.Queries.GetByTags
{
    public class GetPostsByTagsQuery : IRequest<PostListVM>
    {
        public string IncludedTags { get; set; } = "";
        public string ExcludedTags { get; set; } = "";

        public GetPostsByTagsQuery(string includedTags, string excludedTags)
        {
            IncludedTags = includedTags;
            ExcludedTags = excludedTags;
        }
    }
}
