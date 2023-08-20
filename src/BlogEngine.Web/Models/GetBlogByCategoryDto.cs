namespace BlogEngine.Web.Models
{
    public class GetBlogByCategoryDto
    {
        public string IncludedCategories { get; set; } = "";
        public string ExcludedCategories { get; set; } = "";
    }
}
