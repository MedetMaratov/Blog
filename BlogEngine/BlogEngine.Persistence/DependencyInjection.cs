using BlogEngineApplication.Interfaces;
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
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                     b => b.MigrationsAssembly("BlogEngine.Persistence"));
            });
            services.AddScoped<IBlogDbContext>(provider =>
                provider.GetService<BlogDbContext>());
            return services;
        }
    }
}
