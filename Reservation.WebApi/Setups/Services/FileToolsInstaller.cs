using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Reservation.WebApi.Setups.Factory.Services;

namespace Reservation.WebApi.Setups.Services
{
    public class FileToolsInstaller : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddHttpContextAccessor();
        }
    }
}
