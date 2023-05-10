using BlogEngine.Domain.Entities;
using BlogEngine.Persistence;
using BlogEngineApplication;
using BlogEngineApplication.Common.Mapping;
using BlogEngineApplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IBlogDbContext).Assembly));
});
services.AddApplication();
services.AddPersistence(builder.Configuration);
services.AddControllersWithViews();
services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<BlogDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
    }
}

app.UseRouting();
app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseCors("AllowAll");

app.Run();
