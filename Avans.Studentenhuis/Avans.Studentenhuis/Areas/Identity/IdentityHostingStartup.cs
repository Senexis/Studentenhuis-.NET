using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Avans.Studentenhuis.Areas.Identity.IdentityHostingStartup))]
namespace Avans.Studentenhuis.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}