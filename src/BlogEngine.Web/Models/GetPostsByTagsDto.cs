namespace BlogEngine.Web.Models
{
    public class GetPostsByTagsDto
    {
        public string IncludedTags { get; set; } = "";
        public string ExcludedTags { get; set; } = "";
    }
}
