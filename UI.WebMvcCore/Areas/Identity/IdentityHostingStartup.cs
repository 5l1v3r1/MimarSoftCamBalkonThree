using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(UI.WebMvcCore.Areas.Identity.IdentityHostingStartup))]

namespace UI.WebMvcCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}