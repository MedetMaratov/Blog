namespace BlogEngine.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(BlogDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
