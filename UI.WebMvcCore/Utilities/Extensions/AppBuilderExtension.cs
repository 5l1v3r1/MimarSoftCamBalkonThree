using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Business;

namespace UI.WebMvcCore.Utilities.Extensions
{
    public static class AppBuilderExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetService<ApplicationContext>();
            dbContext.Database.Migrate();
        }
    }
}