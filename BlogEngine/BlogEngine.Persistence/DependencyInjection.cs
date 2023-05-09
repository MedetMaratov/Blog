using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["\"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Blog;Integrated Security=SSPI;"];
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped(provider =>
                provider.GetService<BlogDbContext>());
            return services;
        }
    }
}
